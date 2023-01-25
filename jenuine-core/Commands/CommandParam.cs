
using Its.Jenuiue.Core.ModelsViews;

namespace Its.Jenuiue.Core.Commands
{
    public class CommandParam
    {
        public string Id {get; set;}
        public string Host {get; set;}
        public string UserAgent {get; set;}
        public string UserAgentVersion {get; set;}

        public string Organization {get; set;}
        public string BasicAuthUser {get; set;}
        public string BasicAuthPassword {get; set;}
        public BaseModelView BodyData {get; set;}
    }
}
