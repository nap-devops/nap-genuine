using CommandLine;

namespace Its.Jenuiue.Cli.Options
{
    public class BaseOptions
    {
        [Option('v', "verbosity", Required = false, HelpText = "Set output to verbose messages.")]
        public string? Verbosity { get; set; }

        [Option('a', "action", Required = true, HelpText = "Set action of the event")]
        public string? Action { get; set; }

        [Option('d', "data", Required = false, HelpText = "File name contains JSON input data")]
        public string? DataFile { get; set; }

        [Option('i', "id", Required = false, HelpText = "Object ID")]
        public string? Id { get; set; }        
    }
}