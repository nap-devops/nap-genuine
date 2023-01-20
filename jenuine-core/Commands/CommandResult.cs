
using System.Net;
using System.Net.Http;

namespace Its.Jenuiue.Core.Commands
{
    public class CommandResult
    {
        public string ResponseText {get; set;}
        public string ErrorText {get; set;}
        public HttpStatusCode StatusCode {get; set;}
        public HttpResponseMessage Response {get; set;}
    }
}
