using System;
using Serilog;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Worker.Executors
{
    public class CreateAssetExector : BaseExecutor
    {
        protected override void Init()
        {
            var bnHost = configuration["backend:url"];

            Log.Information($"Started CreateAsset job [{jobParam.JobId}]");
            Log.Information($"Generating [{jobParam.Quantity}] assets");
            Log.Information($"Backend host -> [{bnHost}]");
        }

        protected override void ThreadExecutor()
        {
            int quantity = 1; //jobParam.Quantity;
            string url = configuration["backend:url"];
            string org = "napbiotec";
            
            var client = new HttpClient();
            Uri baseUri = new Uri(url);
            client.BaseAddress = baseUri;
            client.Timeout = TimeSpan.FromMinutes(0.05);

            //Basic Authentication
            var user = "james";
            var passwd = "ThisxIsPassw0rd";
            var authenticationString = $"{user}:{passwd}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"/api/assets/org/{org}/action/AddAsset");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

            MAsset asset = new MAsset()
            {
                ProductId = "638b1360a853c317ed000b77",
                //IsRegistered = false,
                AssetName = ""
            };

            for (int i=0; i<quantity; i++)
            {
                asset.PinNo = $"P000000{i}";
                asset.SerialNo = $"S000000{i}";

                var json = JsonSerializer.Serialize(asset);
                var ctn = new StringContent(json, Encoding.Default, "application/json");

                requestMessage.Content = ctn;

                //make the request
                var task = client.SendAsync(requestMessage);
                var response = task.Result;
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                finally
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(responseBody);
                }
                
                //Log.Information($"Processing CreateAsset job [{jobParam.JobId}]...");
                Thread.Sleep(100);
            }
        }
    }
}
