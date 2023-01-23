using System.Net;
using Its.Jenuiue.Cli.Options;
using Its.Jenuiue.Core.Commands;
using Its.Jenuiue.Core.Utils;
using System.Collections;
using Its.Jenuiue.Core.ModelsViews;
using System.Text.Json;

namespace Its.Jenuiue.Cli.Actions
{
    public abstract class BaseAction : IAction
    {
        protected CommandParam param = new CommandParam();
        protected abstract Hashtable GetActionMap();

        private BaseModelView? GetBodyData(ActionCfg cfg, BaseOptions options)
        {
            //Need to get from --data instead
            var data = "{}";
            var convertOption = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var obj = (BaseModelView?) JsonSerializer.Deserialize(data, cfg.DataClassType, convertOption);
            return obj;
        }

        private CommandResult RunAction(BaseOptions options)
        {
            var map = GetActionMap();
            var result = new CommandResult();
            string actName = String.IsNullOrEmpty(options.Action) ? "error":options.Action;

            ActionCfg? cfg = (ActionCfg?) map[actName];
            if (cfg != null)
            {
                if (cfg.NeedBody)
                {
                    param.BodyData = GetBodyData(cfg, options);
                }

                ICommand? cmd = (ICommand?) Activator.CreateInstance(cfg.ActionClassType);
                if (cmd != null)
                {
                    result = (cmd as ICommand).Run(param);
                }
            }
            else
            {
                Console.WriteLine("Type is null");
            }

            return result;
        }

        private void PopulateParam()
        {
            var cfg = UtilsAction.GetConfiguration();

            param = new CommandParam()
            {
                Organization = ConfigUtils.GetConfig(cfg, "backend:organization"),
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