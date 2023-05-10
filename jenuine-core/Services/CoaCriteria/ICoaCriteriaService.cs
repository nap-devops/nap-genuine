using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Services.CoaCriteria
{
    public interface ICoaCriteriaService
    {
        public void SetOrgId(string id);
        public MCoaCriteria AddCoaCriteria(MCoaCriteria param);
        public List<MCoaCriteria> GetCoaCriteria(MCoaCriteria param, QueryParam queryParam);
        public MCoaCriteria UpdateCoaCriteria(MCoaCriteria param);
        public MCoaCriteria DeleteCoaCriteria(MCoaCriteria param);
        public MCoaCriteria GetCoaCriteriaById(MCoaCriteria param);
        public long GetCoaCriteriaCount(MCoaCriteria param);
    }
}
