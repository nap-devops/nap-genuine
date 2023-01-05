using Serilog;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Utils;
using Its.Jenuiue.Worker.Utils;

namespace Its.Jenuiue.Worker.Executors
{
    public class CreateAssetExector : BaseExecutor
    {
        private readonly IConfiguration? configuration;
        private string url = "";
        private string user = "";
        private string dummyProductId = "";
        private string password = "";
        private int failedCount = 0;
        private int succeedCount = 0;

        public CreateAssetExector(IConfiguration? cfg)
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
            Log.Information($"[{jobParam.JobId}] - Started CreateAsset job");
            Log.Information($"[{jobParam.JobId}] - Generating [{jobParam.Quantity}] assets");
            Log.Information($"[{jobParam.JobId}] - Backend host -> [{url}]");
        }

        private void Final()
        {
            Log.Information($"[{jobParam.JobId}] - Finished CreateAsset job Total=[{jobParam.Quantity}], Succeed=[{succeedCount}], Failed=[{failedCount}]");
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

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"/api/assets/org/{org}/action/AddAsset");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

            return requestMessage;
        }

        protected override void ThreadExecutor()
        {
            int quantity = jobParam.Quantity;
            string org = jobParam.Organization;

            var client = GetHttpClient();

            MAsset asset = new MAsset()
            {
                ProductId = dummyProductId, //jobParam.ProductId,
                IsRegistered = false,
                AssetName = "",
                AssetId = "DUMMY"
            };

            for (int i=0; i<quantity; i++)
            {
                asset.PinNo = RandomUtil.RandomNumber(1, 9999999).ToString("0000000");
                asset.SerialNo = RandomUtil.RandomString(7, false);
                asset.AssetName = "Dummy asset name";

                var json = JsonSerializer.Serialize(asset);
                var ctn = new StringContent(json, Encoding.Default, "application/json");

                var requestMessage = GetRequestMessage(org);
                requestMessage.Content = ctn;

                //make the request
                var task = client.SendAsync(requestMessage);
                var response = task.Result;
                try
                {
                    response.EnsureSuccessStatusCode();
                    Log.Information($"[{jobParam.JobId}] - Added asset Pin=[{asset.PinNo}], Serial=[{asset.SerialNo}]");
                    succeedCount++;
                }
                catch (Exception e)
                {
                    failedCount++;

                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    Log.Error(responseBody);
                    Log.Error(e.Message);
                }

                //Thread.Sleep(100);
            }

            Final();
        }
    }
}
