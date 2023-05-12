using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.CoaDocs
{
    public class CommandAddCoaDoc : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "coa_docs";
        }

        protected override string GetActionName()
        {
            return "AddCoaDoc";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVCoaDoc data = (MVCoaDoc) param.BodyData;
            var json = JsonSerializer.Serialize(data);

            return json;
        }
    }
}
