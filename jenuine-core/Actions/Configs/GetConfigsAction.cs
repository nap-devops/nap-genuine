using System;
using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;
using System.Collections.Generic;

namespace Its.Jenuiue.Core.Actions.Configs
{
    public class GetConfigsAction : BaseActionQuery
    {
        public GetConfigsAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        
        protected override string GetCollectionName()
        {
            return "configs";
        }

        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = UtilsConfigAction.GetQueryFilter<T>(model);
            return filter;
        }
    }
}
