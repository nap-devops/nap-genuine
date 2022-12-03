using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Global;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Services.Organizes
{
    public interface IOrganizesService
    {
        public MOrganize AddOrganize(MOrganize param);
        public List<MOrganize> GetOrganizes(MOrganize param, QueryParam queryParam);
        public MOrganize GetOrganizeById(MOrganize param);
        public long GetOrganizeCount();
        public MOrganize UpdateOrganize(MOrganize param);
        public MOrganize DeleteOrganize(MOrganize param);
    }
}
