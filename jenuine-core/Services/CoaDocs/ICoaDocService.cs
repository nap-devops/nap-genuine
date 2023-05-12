using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Services.CoaDocs
{
    public interface ICoaDocService
    {
        public void SetOrgId(string id);
        public MCoaDoc AddCoaDoc(MCoaDoc param);
        public List<MCoaDoc> GetCoaDoc(MCoaDoc param, QueryParam queryParam);
        public MCoaDoc UpdateCoaDoc(MCoaDoc param);

        public MCoaDoc DeleteCoaDoc(MCoaDoc param);
        public MCoaDoc GetCoaDocById(MCoaDoc param);
        public long GetCoaDocCount(MCoaDoc param);

    }
}
