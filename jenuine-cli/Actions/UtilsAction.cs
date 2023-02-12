using Its.Jenuiue.Cli.Options;
using Microsoft.Extensions.Configuration;

namespace Its.Jenuiue.Cli.Actions
{
    public enum ActionType
    {
        Job,
        Asset,
        Product,
        Config,
        Customer
    }

    public static class UtilsAction
    {
        private static IAction jobAction = new ActionJob();
        private static IAction assetAction = new ActionAsset();
        private static IAction productAction = new ActionProduct();
        private static IAction configAction = new ActionConfig();
        private static IAction customerAction = new ActionCustomer();

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
            else if (type == ActionType.Product)
            {
                productAction = action;
            }
            else if (type == ActionType.Config)
            {
                configAction = action;
            }
            else if (type == ActionType.Customer)
            {
                customerAction = action;
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

        public static void RunProductAction(BaseOptions o)
        {
            productAction.Run(o);
        }

        public static void RunConfigAction(BaseOptions o)
        {
            configAction.Run(o);
        }

        public static void RunCustomerAction(BaseOptions o)
        {
            customerAction.Run(o);
        }
    }
}
