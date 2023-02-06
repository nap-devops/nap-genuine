using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Services.Customers
{
    public interface ICustomersService
    {
        public void SetOrgId(string id);
        public MCustomer AddCustomer(MCustomer param);
        public List<MCustomer> GetCustomers(MCustomer param, QueryParam queryParam);
        public MCustomer UpdateCustomer(MCustomer param);
        public MCustomer DeleteCustomer(MCustomer param);
        public MCustomer GetCustomerById(MCustomer param);
        public long GetCustomersCount(MCustomer param);
    }
}
