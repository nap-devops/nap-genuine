using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.CoaDocs
{
    public class CommandGetCoaDocCount : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "coa_docs";
        }

        protected override string GetActionName()
        {
            return "GetCoaDocCount";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVCoaDocQuery mvObj = (MVCoaDocQuery) param.BodyData;
            var json = JsonSerializer.Serialize(mvObj);

            return json;
        }
    }
}
