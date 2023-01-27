using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Services.Configs
{
    public interface IConfigsService
    {
        public void SetOrgId(string id);
        public MConfig AddConfig(MConfig param);
        public List<MConfig> GetConfigs(MConfig param, QueryParam queryParam);
        public MConfig UpdateConfig(MConfig param);
    }
}
