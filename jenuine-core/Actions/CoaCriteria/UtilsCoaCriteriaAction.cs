using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.CoaCriteria
{
    public static class UtilsCoaCriteriaAction
    {
        public static FilterDefinition<T> GetQueryFilter<T>(T model)
        {
            if (model == null)
            {
                return FilterDefinition<T>.Empty;
            }

            var m = model as MCoaCriteria;
            List<FilterDefinition<T>> filters = new List<FilterDefinition<T>>();

            if (!String.IsNullOrEmpty(m.CriteriaId))
            {
                var filter1 = Builders<T>.Filter.Where(p => (p as MCoaCriteria).CriteriaId.Contains(m.CriteriaId));
                filters.Add(filter1);
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
