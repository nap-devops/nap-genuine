using System;
using System.Threading;
using Serilog;

namespace Its.Jenuiue.Worker.Executors
{
    public class ExectorFactory
    {
        public static IExecutor GetExecutor(string type)
        {
            return new CreateAssetExector();
        }
    }
}
