using Its.Jenuiue.Core.Commands.Customers;
using System.Collections;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Cli.Actions
{
    public class ActionCustomer : BaseAction
    {
        protected override Hashtable GetActionMap()
        {
            Hashtable map = new Hashtable();

            map["GetCustomers"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCustomers),
                DataClassType = typeof(MVCustomerQuery),
                NeedBody = true
            };

            map["AddProduct"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandAddCustomer),
                DataClassType = typeof(MVCustomer),
                NeedBody = true
            };

            map["DeleteCustomerById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandDeleteCustomerById),
                NeedId = true
            };

            map["UpdateCustomerById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandUpdateCustomerById),
                DataClassType = typeof(MVCustomer),
                NeedId = true,
                NeedBody = true
            };

            map["GetCustomerById"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCustomerById),
                NeedId = true
            };            

            map["GetCustomersCount"] = new ActionCfg()
            {
                ActionClassType = typeof(CommandGetCustomerCount),
                DataClassType = typeof(MVCustomerQuery),
                NeedBody = true
            };

            return map;
        }
    }
}