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
