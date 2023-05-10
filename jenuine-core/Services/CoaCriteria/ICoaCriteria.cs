using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Services.Configs
{
    public interface ICoaCriteria
    {
        public void SetOrgId(string id);
        public MCoaCriteria AddCoaCriteria(MCoaCriteria param);
        public List<MCoaCriteria> GetCoaCriterias(MCoaCriteria param, QueryParam queryParam);
        public MCoaCriteria UpdateCoaCriteria(MCoaCriteria param);
    }
}
