using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.CoaCriteriaGroup
{
    public class CommandAddCoaCriteriaGroup : BaseCommandNoId
    {
        protected override string GetServiceName()
        {
            return "coa_criteria_group";
        }

        protected override string GetActionName()
        {
            return "AddCoaCriteriaGroup";
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
