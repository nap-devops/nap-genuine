using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Actions.CoaCriteria;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Services.CoaCriteria
{
    public class CoaCriteriaService : ICoaCriteria
    {
        private readonly IDatabase database;
        private string orgId = "";

        public CoaCriteriaService(IDatabase db)
        {
            database = db;
        }

        public void SetOrgId(string id)
        {
            orgId = id;
        }

        public List<MCoaCriteria> GetCoaCriteria(MCoaCriteria param, QueryParam queryParam)
        {
            var act = new GetCoaCriteriaAction(database, orgId);
            var results = act.Apply<MCoaCriteria>(param, queryParam);

            return results;
        }

        public MCoaCriteria AddCoaCriteria(MCoaCriteria param)
        {
            string regId = param.CriteriaId;
            if (string.IsNullOrEmpty(regId))
            {
                //Create if if not provided by caller
                Guid guid = Guid.NewGuid();
                regId = guid.ToString();
            }

            var act = new AddCoaCriteriaAction(database, orgId);
            param.CriteriaId = regId;
            var result = act.Apply<MCoaCriteria>(param);

            return result;
        }

        public MCoaCriteria UpdateCoaCriteria(MCoaCriteria param)
        {
            var act = new UpdateCoaCriteriaByIdAction(database, orgId);
            var result = act.Apply<MCoaCriteria>(param);

            return result;
        }

        public MCoaCriteria DeleteCoaCriteria(MCoaCriteria param)
        {
            var act = new DeleteCoaCriteriaByIdAction(database, orgId);
            var result = act.Apply<MCoaCriteria>(param.Id);

            return result;
        }

        public MCoaCriteria GetCoaCriteriaById(MCoaCriteria param)
        {
            var act = new GetCoaCriteriaByIdAction(database, orgId);            
            var customer = act.Apply<MCoaCriteria>(param);

            return customer;
        }

        public long GetCoaCriteriaCount(MCoaCriteria param)
        {
            var act = new GetCoaCriteriaCountAction(database, orgId);
            var cnt = act.Apply<MCoaCriteria>(param);

            return cnt;
        }        
    }
}
