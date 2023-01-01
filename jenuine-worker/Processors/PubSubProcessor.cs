using System;
using Serilog;

namespace Its.Jenuiue.Worker.Processors
{
    public class PubSubProcessor : BaseProcessor
    {
        protected override void Init()
        {
            Log.Information("Started Pub/Sub processor");
        }

        protected override void ThreadProcess()
        {
            while (true)
            {
                //Log.Information("Hello world");
                Thread.Sleep(10000);                
            }
        }
    }
}
