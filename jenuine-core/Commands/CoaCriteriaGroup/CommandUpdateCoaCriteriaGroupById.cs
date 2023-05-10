using System;
using System.Net.Http;
using System.Text.Json;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Core.Commands.CoaCriteriaGroup
{
    public class UpdateCommandCoaCriteriaGroupById : BaseCommandWithId
    {
        protected override string GetServiceName()
        {
            return "coa_criteria_group";
        }

        protected override string GetActionName()
        {
            return "UpdateCoaCriteriaGroupById";
        }

        protected override HttpMethod GetMethod()
        {
            return HttpMethod.Put;
        }

        protected override string GetBodyText(CommandParam param)        
        {
            MVCoaCriteriaQuery data = (MVCoaCriteriaQuery) param.BodyData;
            var json = JsonSerializer.Serialize(data);

            return json;
        }
    }
}
