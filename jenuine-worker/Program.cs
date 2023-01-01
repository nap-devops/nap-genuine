using Serilog;
using Its.Jenuiue.Worker.Processors;

namespace Its.Jenuiue.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            Log.Logger = log;
            
            var processor = new PubSubProcessor();
            processor.Run();            
        }
    }
}
