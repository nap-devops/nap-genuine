
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Database;
using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Actions.Registration;

namespace Its.Jenuiue.Core.Services.Registration
{
    public class RegistrationService : IRegistrationService
    {
        private string orgId = "";
        private readonly IDatabase database;
        public RegistrationService(IDatabase db)
        {
            database = db;
        }

        public void SetOrgId(string setorgid)
        {
            orgId = setorgid;
        }

        public MRegistration AddRegistration(MRegistration param)
        {
            var act = new AddRegistrationAction(database, orgId);
            var result = act.Apply<MRegistration>(param);

            //TODO : Update Asset.IsRegistered using Asset.AssetId as a selected key
            return result;
        }

        public List<MRegistration> GetRegistration(MRegistration param, QueryParam queryParam)
        {
            var act = new GetRegistrationAction(database, orgId);            
            var results = act.Apply<MRegistration>(param, queryParam);

            return results;
        }

        public MRegistration GetRegistrationById(MRegistration param)
        {
            var act = new GetRegistrationByIdAction(database, orgId);            
            var registration = act.Apply<MRegistration>(param);

            return registration;  
        }

        public long GetRegistrationCount()
        {
            var m = new MRegistration();

            var act = new GetRegistrationCountAction(database, orgId);
            var cnt = act.Apply<MRegistration>(m);

            return cnt;
        }

        public MRegistration DeleteRegistrationById(MRegistration param)
        {
            var act = new DeleteRegistrationByIdAction(database, orgId);
            var result = act.Apply<MRegistration>(param.Id);

            return result;
        }
    }
        
}
