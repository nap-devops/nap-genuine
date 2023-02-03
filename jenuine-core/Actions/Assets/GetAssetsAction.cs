using System;
using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;
using System.Collections.Generic;

namespace Its.Jenuiue.Core.Actions.Assets
{
    public class GetAssetsAction : BaseActionQuery
    {
        public GetAssetsAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        
        protected override string GetCollectionName()
        {
            return "assets";
        }

        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = UtilsAssetAction.GetQueryFilter<T>(model);
            return filter;
        }
    }
}
