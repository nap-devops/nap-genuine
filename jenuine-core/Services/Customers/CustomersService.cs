using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Actions.Customers;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Services.Customers
{
    public class CustomersService : ICustomersService
    {
        private readonly IDatabase database;
        private string orgId = "";

        public CustomersService(IDatabase db)
        {
            database = db;
        }

        public void SetOrgId(string id)
        {
            orgId = id;
        }

        public List<MCustomer> GetCustomers(MCustomer param, QueryParam queryParam)
        {
            var act = new GetCustomersAction(database, orgId);
            var results = act.Apply<MCustomer>(param, queryParam);

            return results;
        }

        public MCustomer AddCustomer(MCustomer param)
        {
            string regId = param.CustomerId;
            if (string.IsNullOrEmpty(regId))
            {
                //Create if if not provided by caller
                Guid guid = Guid.NewGuid();
                regId = guid.ToString();
            }
            
            var act = new AddCustomerAction(database, orgId);
            param.CustomerId = regId;
            var result = act.Apply<MCustomer>(param);

            return result;
        }

        public MCustomer UpdateCustomer(MCustomer param)
        {
            var act = new UpdateCustomerByIdAction(database, orgId);
            var result = act.Apply<MCustomer>(param);

            return result;
        }

        public MCustomer DeleteCustomer(MCustomer param)
        {
            var act = new DeleteCustomerByIdAction(database, orgId);
            var result = act.Apply<MCustomer>(param.Id);

            return result;
        }

        public MCustomer GetCustomerById(MCustomer param)
        {
            var act = new GetCustomerByIdAction(database, orgId);            
            var customer = act.Apply<MCustomer>(param);

            return customer;
        }

        public long GetCustomersCount(MCustomer param)
        {
            var act = new GetCustomerCountAction(database, orgId);
            var cnt = act.Apply<MCustomer>(param);

            return cnt;
        }        
    }
}
