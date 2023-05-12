using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Actions.CoaSpecs;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Services.CoaSpecs
{
    public class CoaSpecService : ICoaSpecService
    {
        private readonly IDatabase database;
        private string orgId = "";

        public CoaSpecService(IDatabase db)
        {
            database = db;
        }

        public void SetOrgId(string id)
        {
            orgId = id;
        }

        public List<MCoaSpec> GetCoaSpec(MCoaSpec param, QueryParam queryParam)
        {
            var act = new GetCoaSpecAction(database, orgId);
            var results = act.Apply<MCoaSpec>(param, queryParam);

            return results;
        }

        public MCoaSpec AddCoaSpec(MCoaSpec param)
        {
            string regId = param.SpecificationId;
            if (string.IsNullOrEmpty(regId))
            {
                //Create if if not provided by caller
                Guid guid = Guid.NewGuid();
                regId = guid.ToString();
            }

            var act = new AddCoaSpecAction(database, orgId);
            param.SpecificationId = regId;
            var result = act.Apply<MCoaSpec>(param);

            return result;
        }

        public MCoaSpec UpdateCoaSpec(MCoaSpec param)
        {
            var act = new UpdateCoaSpecByIdAction(database, orgId);
            var result = act.Apply<MCoaSpec>(param);

            return result;
        }

        public MCoaSpec DeleteCoaSpec(MCoaSpec param)
        {
            var act = new DeleteCoaSpecByIdAction(database, orgId);
            var result = act.Apply<MCoaSpec>(param.Id);

            return result;
        }

        public MCoaSpec GetCoaSpecById(MCoaSpec param)
        {
            var act = new GetCoaSpecByIdAction(database, orgId);            
            var result = act.Apply<MCoaSpec>(param);

            return result;
        }

        public long GetCoaSpecCount(MCoaSpec param)
        {
            var act = new GetCoaSpecCountAction(database, orgId);
            var cnt = act.Apply<MCoaSpec>(param);

            return cnt;
        }
    }
}
