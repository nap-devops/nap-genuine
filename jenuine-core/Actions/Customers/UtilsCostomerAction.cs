using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using MongoDB.Driver;

namespace Its.Jenuiue.Core.Actions.Customers
{
    public static class UtilsCostomerAction
    {
        public static FilterDefinition<T> GetQueryFilter<T>(T model)
        {
            if (model == null)
            {
                return FilterDefinition<T>.Empty;
            }

            var m = model as MCustomer;
            List<FilterDefinition<T>> filters = new List<FilterDefinition<T>>();

            if (!String.IsNullOrEmpty(m.CustomerId))
            {
                var filter1 = Builders<T>.Filter.Where(p => (p as MCustomer).CustomerId.Contains(m.CustomerId));
                filters.Add(filter1);
            }

            if (!String.IsNullOrEmpty(m.Name))
            {
                var filter1 = Builders<T>.Filter.Where(p => (p as MCustomer).Name.Contains(m.Name));
                filters.Add(filter1);
            }

            if (!String.IsNullOrEmpty(m.LastName))
            {
                var filter1 = Builders<T>.Filter.Where(p => (p as MCustomer).LastName.Contains(m.LastName));
                filters.Add(filter1);
            }

            if (!String.IsNullOrEmpty(m.PhoneNo))
            {
                var filter1 = Builders<T>.Filter.Where(p => (p as MCustomer).PhoneNo.Contains(m.PhoneNo));
                filters.Add(filter1);
            }

            if (!String.IsNullOrEmpty(m.Email))
            {
                var filter1 = Builders<T>.Filter.Where(p => (p as MCustomer).Email.Contains(m.Email));
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
