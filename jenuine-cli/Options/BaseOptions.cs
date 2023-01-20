using CommandLine;

namespace Its.Jenuiue.Cli.Options
{
    public class BaseOptions
    {
        [Option('v', "verbosity", Required = false, HelpText = "Set output to verbose messages.")]
        public string? Verbosity { get; set; }
    }
}