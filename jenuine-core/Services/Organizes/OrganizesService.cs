using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Models.Global;
using Its.Jenuiue.Core.Actions.Organizes;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Services.Organizes
{
    public class OrganizesService : IOrganizesService
    {
        private readonly IDatabase database;
        private string orgId = "";

        public OrganizesService(IDatabase db)
        {
            database = db;
        }
        public void SetOrgId(string org)
        {
            orgId = org;
        }


        public List<MOrganize> GetOrganizes(MOrganize param, QueryParam queryParam)
        {
            var act = new GetOrganizesAction(database, orgId);
            var results = act.Apply<MOrganize>(param, queryParam);

            return results;
        }

        public MOrganize AddOrganize(MOrganize param)
        {
            var act = new AddOrganizesAction(database, orgId);

            param.OrganizeId = string.Format("{0}-{1}", param.PinNo, param.SerialNo);
            var result = act.Apply<MOrganize>(param);

            return result;
        }

        public MOrganize GetOrganizeById(MOrganize param)
        {
            var act = new GetOrganizesByIdAction(database, orgId);            
            var organizes = act.Apply<MOrganize>(param);

            return organizes;            
        }

        public long GetOrganizeCount()
        {
            var m = new MOrganize();

            var act = new GetOrganizesCountAction(database, orgId);
            var cnt = act.Apply<MOrganize>(m);

            return cnt;
        }

        public MOrganize UpdateOrganize(MOrganize param)
        {
            var act = new UpdateOrganizesByIdAction(database, orgId);
            var result = act.Apply<MOrganize>(param);

            return result;
        }

        public MOrganize DeleteOrganize(MOrganize param)
        {
            var act = new DeleteOrganizesByIdAction(database, orgId);
            var result = act.Apply<MOrganize>(param.Id);

            return result;
        }
    }
}
