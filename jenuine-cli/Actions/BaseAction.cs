using System.Net;
using Its.Jenuiue.Cli.Options;
using Its.Jenuiue.Core.Commands;
using Its.Jenuiue.Core.Utils;

namespace Its.Jenuiue.Cli.Actions
{
    public abstract class BaseAction : IAction
    {
        protected CommandParam param = new CommandParam();

        protected abstract CommandResult RunAction(BaseOptions options);

        private void PopulateParam()
        {
            var cfg = UtilsAction.GetConfiguration();

            param = new CommandParam()
            {
                Organization = "napbiotec",
                BasicAuthUser = ConfigUtils.GetConfig(cfg, "backend:user"),
                BasicAuthPassword = ConfigUtils.GetConfig(cfg, "backend:password"),
                Host = ConfigUtils.GetConfig(cfg, "backend:url"),
                UserAgent = ConfigUtils.GetConfig(cfg, "backend:userAgent"),
                UserAgentVersion = ConfigUtils.GetConfig(cfg, "backend:userAgentVersion")
            };
        }

        public CommandResult Run(BaseOptions options)
        {
            PopulateParam();

            var result = RunAction(options);

            if (result.StatusCode.Equals(HttpStatusCode.OK))
            {
                Console.WriteLine(result.ResponseText);
            }
            else
            {
                Console.WriteLine(result.ErrorText);
            }

            return result;
        }
    }
}