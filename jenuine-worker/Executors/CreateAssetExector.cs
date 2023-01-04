using System;
using Serilog;

namespace Its.Jenuiue.Worker.Executors
{
    public class CreateAssetExector : BaseExecutor
    {
        protected override void Init()
        {
            var bnHost = configuration["backend:url"];

            Log.Information($"Started CreateAsset job [{jobParam.JobId}]");            
            Log.Information($"Backend host -> [{bnHost}]");
        }

        protected override void ThreadExecutor()
        {
            for (int i=0; i<10; i++)
            {
                //Log.Information($"Processing CreateAsset job [{jobParam.JobId}]...");
                Thread.Sleep(10000);
            }
        }
    }
}
