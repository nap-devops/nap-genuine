using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Jobs
{
    public static class UtilsJobAction
    {
        public static FilterDefinition<T> GetQueryFilter<T>(T model)
        {
            if (model == null)
            {
                return FilterDefinition<T>.Empty;
            }
            
            var m = model as MJob;
            List<FilterDefinition<T>> filters = new List<FilterDefinition<T>>();

            if (!String.IsNullOrEmpty(m.Type))
            {
                var typeFilter = Builders<T>.Filter.Where(p => (p as MJob).Type.Contains(m.Type));
                filters.Add(typeFilter);
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
