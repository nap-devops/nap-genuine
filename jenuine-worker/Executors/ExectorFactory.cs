using Microsoft.Extensions.Configuration;

namespace Its.Jenuiue.Worker.Executors
{
    public class ExectorFactory
    {
        public static IExecutor GetExecutor(string type, IConfiguration cfg)
        {
            if (type.Equals("CreateAsset"))
            {
                return new CreateAssetExector(cfg);
            }

            return new ExportAssetExector(cfg);
        }
    }
}
