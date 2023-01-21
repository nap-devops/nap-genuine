using Its.Jenuiue.Cli.Options;
using Microsoft.Extensions.Configuration;

namespace Its.Jenuiue.Cli.Actions
{
    public enum ActionType
    {
        Job,
        Asset,
    }

    public static class UtilsAction
    {
        private static IAction jobAction = new ActionJob();
        private static IAction assetAction = new ActionAsset();
        public static IConfiguration? configuration;

        public static void SetConfiguration(IConfiguration cfg)
        {
            configuration = cfg;
        }

        public static IConfiguration? GetConfiguration()
        {
            return configuration;
        }

        public static void SetAction(ActionType type, IAction action)
        {
            if (type == ActionType.Job)
            {
                jobAction = action;
            }
            else if (type == ActionType.Asset)
            {
                assetAction = action;
            }            
        }

        public static void RunJobAction(BaseOptions o)
        {
            jobAction.Run(o);
        }

        public static void RunAssetAction(BaseOptions o)
        {
            assetAction.Run(o);
        }        
    }
}
