using Microsoft.Extensions.Configuration;

namespace Its.Jenuiue.Worker.Executors
{
    public class ExectorFactory
    {
        public static IExecutor GetExecutor(string type, IConfiguration cfg)
        {
            return new CreateAssetExector(cfg);
        }
    }
}
