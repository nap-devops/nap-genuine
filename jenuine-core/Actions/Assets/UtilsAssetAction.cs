using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Assets
{
    public static class UtilsAssetAction
    {
        public static FilterDefinition<T> GetQueryFilter<T>(T model)
        {
            if (model == null)
            {
                return FilterDefinition<T>.Empty;
            }

            var m = model as MAsset;
            List<FilterDefinition<T>> filters = new List<FilterDefinition<T>>();

            if (!String.IsNullOrEmpty(m.PinNo))
            {
                var pinNOfilter = Builders<T>.Filter.Where(p => (p as MAsset).PinNo.Contains(m.PinNo));
                filters.Add(pinNOfilter);
            }

            if (!String.IsNullOrEmpty(m.SerialNo))
            {
                var serialNofilter = Builders<T>.Filter.Where(p => (p as MAsset).SerialNo.Contains(m.SerialNo));
                filters.Add(serialNofilter);
            }

            if (!String.IsNullOrEmpty(m.JobId))
            {
                var jobIdfilter = Builders<T>.Filter.Where(p => (p as MAsset).JobId.Contains(m.JobId));
                filters.Add(jobIdfilter);
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
