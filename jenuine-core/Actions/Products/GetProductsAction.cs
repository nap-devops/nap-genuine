using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;
using System.Collections.Generic;
using System;

namespace Its.Jenuiue.Core.Actions.Products
{
    public class GetProductsAction : BaseActionQuery
    {
        public GetProductsAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }
        
        protected override string GetCollectionName()
        {
            return "products";
        }
        
        protected override FilterDefinition<T> GetFilter<T>(T model)
        {
            var filter = UtilsProductAction.GetQueryFilter<T>(model);
            return filter;
        }
    }
}
