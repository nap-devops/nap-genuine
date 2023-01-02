using System;
using Serilog;
using Its.Jenuiue.Worker.Executors;

namespace Its.Jenuiue.Worker.Executors
{
    public class CreateAssetExector : BaseExecutor
    {
        protected override void Init()
        {
            Log.Information($"Started CreateAsset job [{jobParam.JobId}]");
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
