using Serilog;
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

        private void VerifyIdField(BaseOptions options)
        {
            if (String.IsNullOrEmpty(options.Id))
            {
                Log.Error("ID is required, please provide option --id or -i");
                Environment.Exit(1);
            }
        }

        private void VerifyPinSerialFields(AssetOptions options)
        {
            if (String.IsNullOrEmpty(options.Pin))
            {
                Log.Error("Pin is required, please provide option --pin or -p");
                Environment.Exit(1);
            }

            if (String.IsNullOrEmpty(options.Pin))
            {
                Log.Error("Serial is required, please provide option --serial or -s");
                Environment.Exit(1);
            }
        }        

        private string GetFileContent(BaseOptions options)
        {
            var fname = options.DataFile;

            if (String.IsNullOrEmpty(fname))
            {
                Log.Error($"File name is empty, please provide option --data or -d");
                Environment.Exit(1);
            }

            if (!File.Exists(fname))
            {
                Log.Error($"File not found - [{fname}]");
                Environment.Exit(1);
            }

            var data = File.ReadAllText(fname);

            return data;
        }

        private BaseModelView? GetBodyData(ActionCfg cfg, BaseOptions options)
        {
            var data = GetFileContent(options);
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

                if (cfg.NeedId)
                {
                    VerifyIdField(options);
                    param.Id = options.Id;
                }        

                if (cfg.NeedPinSerial)
                {
                    var assetOption = (AssetOptions) options;
                    VerifyPinSerialFields(assetOption);
                    param.Serial = assetOption.Serial;
                    param.Pin = assetOption.Pin;
                }                

                ICommand? cmd = (ICommand?) Activator.CreateInstance(cfg.ActionClassType);
                if (cmd != null)
                {
                    result = (cmd as ICommand).Run(param);
                }
            }
            else
            {
                Console.WriteLine($"Action [{actName}] not found!!!");
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
                if (!String.IsNullOrEmpty(result.ResponseText))
                {
                    Console.WriteLine(result.ResponseText);
                }
            }

            return result;
        }
    }
}