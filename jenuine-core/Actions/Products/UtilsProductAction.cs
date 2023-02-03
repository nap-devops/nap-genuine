using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Products
{
    public static class UtilsProductAction
    {
        public static FilterDefinition<T> GetQueryFilter<T>(T model)
        {
            if (model == null)
            {
                return FilterDefinition<T>.Empty;
            }
            
            var m = model as MProduct;
            List<FilterDefinition<T>> filters = new List<FilterDefinition<T>>();

            if (!String.IsNullOrEmpty(m.ProductId))
            {
                var idfilter = Builders<T>.Filter.Where(p => (p as MProduct).ProductId.Contains(m.ProductId));
                filters.Add(idfilter);
            }

            if (!String.IsNullOrEmpty(m.ProductName))
            {
                var namefilter = Builders<T>.Filter.Where(p => (p as MProduct).ProductName.Contains(m.ProductName));
                filters.Add(namefilter);
            }

            if (!String.IsNullOrEmpty(m.RedirectUrl))
            {
                var urlfilter = Builders<T>.Filter.Where(p => (p as MProduct).RedirectUrl.Contains(m.RedirectUrl));
                filters.Add(urlfilter);
            }


            if (filters.Count <= 0)
            {
                return FilterDefinition<T>.Empty;
            }

            var filter = Builders<T>.Filter.And(filters);
            return filter;
        }
    }
}
