using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Services.Registration
{
    public interface IRegistrationService
    {
        public void SetOrgId(string id);
        public MRegistration AddRegistration(MRegistration param);
        public List<MRegistration> GetRegistration(MRegistration param, QueryParam queryParam);
        public MRegistration GetRegistrationById(MRegistration param);
        public long GetRegistrationCount();
        public MRegistration DeleteRegistrationById(MRegistration param);
    }
}
