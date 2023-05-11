using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Services.CoaSpecs
{
    public interface ICoaSpecService
    {
        public void SetOrgId(string id);
        public MCoaSpec AddCoaSpec(MCoaSpec param);
        public List<MCoaSpec> GetCoaSpec(MCoaSpec param, QueryParam queryParam);
/*
        public MCoaSpec UpdateCoaSpec(MCoaSpec param);
        public MCoaSpec DeleteCoaSpec(MCoaSpec param);
        public MCoaSpec GetCoaSpecById(MCoaSpec param);
        public long GetCoaSpecCount(MCoaSpec param);
*/
    }
}
