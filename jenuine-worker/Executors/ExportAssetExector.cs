using Serilog;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Utils;
using Its.Jenuiue.Worker.Utils;
using Its.Jenuiue.Api.ModelsViews.Organization;

namespace Its.Jenuiue.Worker.Executors
{
    public class ExportAssetExector : BaseExecutor
    {
        private readonly IConfiguration? configuration;
        private string url = "";
        private string user = "";
        private string dummyProductId = "";
        private string password = "";
        private int failedCount = 0;
        private int succeedCount = 0;

        public ExportAssetExector(IConfiguration? cfg)
        {
            if (cfg == null)
            {
                Log.Error("Configuration variable is null in [CreateAssetExector]");
            }

            if (cfg != null)
            {
                configuration = cfg;
                url = ConfigUtils.GetConfig(configuration, "backend:url");
                user = ConfigUtils.GetConfig(configuration, "backend:user");
                password = ConfigUtils.GetConfig(configuration, "backend:password");
                dummyProductId = ConfigUtils.GetConfig(configuration, "backend:dummyProductId");
            }
        }

        protected override void Init()
        {
            Log.Information($"[{jobParam.Type}:{jobParam.JobId}] - Started ExtractAsset job");
            Log.Information($"[{jobParam.Type}:{jobParam.JobId}] - Generating [{jobParam.Quantity}] assets");
            Log.Information($"[{jobParam.Type}:{jobParam.JobId}] - Backend host -> [{url}]");
        }

        private void Final()
        {
            Log.Information($"[{jobParam.Type}:{jobParam.JobId}] - Finished ExtractAsset job Total=[{jobParam.Quantity}], Succeed=[{succeedCount}], Failed=[{failedCount}]");
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            Uri baseUri = new Uri(url);
            client.BaseAddress = baseUri;
            client.Timeout = TimeSpan.FromMinutes(0.05);

            return client;
        }

        private HttpRequestMessage GetRequestMessage(string org)
        {
            //Basic Authentication
            var authenticationString = $"{user}:{password}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"/api/assets/org/{org}/action/GetAssets");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

            var productValue = new ProductInfoHeaderValue("genuine-worker", "1.0");
            requestMessage.Headers.UserAgent.Add(productValue);

            return requestMessage;
        }

        private void ExportAssets(string json)
        {
            Console.WriteLine(json);
        }

        protected override void ThreadExecutor()
        {
            int pageSize = 100;
            int quantity = jobParam.Quantity;

            int pageCount = quantity/pageSize;
            if (quantity % pageSize != 0)
            {
                pageCount++;
            }
            
            string org = jobParam.Organization;
            var client = GetHttpClient();

            MVAssetQuery asset = new MVAssetQuery()
            {
                Id = "",
                JobId = jobParam.JobId,
                ProductId = "",
                PinNo = "",
                SerialNo = "",
                LastActionStatus = "",
                QueryParam = new Core.Models.QueryParam()
            };
            asset.QueryParam.Limit = pageSize;
            
            for (int i=0; i<pageCount; i++)
            {
                int offset = i * pageSize;
                asset.QueryParam.Offset = offset;

                var json = JsonSerializer.Serialize(asset);
                var ctn = new StringContent(json, Encoding.Default, "application/json");
Console.WriteLine(json);
                var requestMessage = GetRequestMessage(org);
                requestMessage.Content = ctn;

                var task = client.SendAsync(requestMessage);
                var response = task.Result;

                try
                {
                    response.EnsureSuccessStatusCode();
                    succeedCount++;

                    string result = response.Content.ReadAsStringAsync().Result;
                    ExportAssets(result);
                }
                catch (Exception e)
                {
                    failedCount++;

                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    Log.Error(responseBody);
                    Log.Error(e.Message);
                }
            }

            Final();
        }
    }
}
