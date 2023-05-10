using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.CoaCriteria
{
    public class CommandAddCoaCriteria : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "coa_criteria";
        }

        protected override string GetActionName()
        {
            return "AddCoaCriteria";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Post;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVCoaCriteria data = (MVCoaCriteria) param.BodyData;
            var json = JsonSerializer.Serialize(data);

            return json;
        }
    }
}
