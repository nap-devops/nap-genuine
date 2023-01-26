using CommandLine;

namespace Its.Jenuiue.Cli.Options
{
    [Verb("asset", HelpText = "Calling commands relate to Asset.")]
    public class AssetOptions : BaseOptions
    {
        [Option('p', "pin", Required = false, HelpText = "Pin number")]
        public string? Pin { get; set; }

        [Option('s', "serial", Required = false, HelpText = "Serial number")]
        public string? Serial { get; set; }        
    }    
}
