using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.CoaDocs
{
    public static class UtilsCoaDocAction
    {
        public static FilterDefinition<T> GetQueryFilter<T>(T model)
        {
            if (model == null)
            {
                return FilterDefinition<T>.Empty;
            }

            var m = model as MCoaSpec;
            List<FilterDefinition<T>> filters = new List<FilterDefinition<T>>();
/*
            if (!String.IsNullOrEmpty(m.SpecificationId))
            {
                var filter1 = Builders<T>.Filter.Where(p => (p as MCoaSpec).SpecificationId.Equals(m.SpecificationId));
                filters.Add(filter1);
            }

            if (!String.IsNullOrEmpty(m.SpecificationName))
            {
                var filter2 = Builders<T>.Filter.Where(p => (p as MCoaSpec).SpecificationName.Contains(m.SpecificationName));
                filters.Add(filter2);
            }

            if (!String.IsNullOrEmpty(m.SpecificationDesc))
            {
                var filter3 = Builders<T>.Filter.Where(p => (p as MCoaSpec).SpecificationDesc.Contains(m.SpecificationDesc));
                filters.Add(filter3);
            }
*/
            if (filters.Count <= 0)
            {
                return FilterDefinition<T>.Empty;
            }

            var filter = Builders<T>.Filter.And(filters);
            return filter;
        }
    }
}
