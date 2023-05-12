using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Actions.CoaDocs;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Services.CoaDocs
{
    public class CoaDocService : ICoaDocService
    {
        private readonly IDatabase database;
        private string orgId = "";

        public CoaDocService(IDatabase db)
        {
            database = db;
        }

        public void SetOrgId(string id)
        {
            orgId = id;
        }

        public List<MCoaDoc> GetCoaDoc(MCoaDoc param, QueryParam queryParam)
        {
            var act = new GetCoaDocAction(database, orgId);
            var results = act.Apply<MCoaDoc>(param, queryParam);

            return results;
        }

        public MCoaDoc AddCoaDoc(MCoaDoc param)
        {
            string regId = param.DocumentId;
            if (string.IsNullOrEmpty(regId))
            {
                //Create if if not provided by caller
                Guid guid = Guid.NewGuid();
                regId = guid.ToString();
            }

            var act = new AddCoaDocAction(database, orgId);
            param.DocumentId = regId;
            var result = act.Apply<MCoaDoc>(param);

            return result;
        }

        public MCoaDoc UpdateCoaDoc(MCoaDoc param)
        {
            var act = new UpdateCoaDocByIdAction(database, orgId);
            var result = act.Apply<MCoaDoc>(param);

            return result;
        }

        public MCoaDoc DeleteCoaDoc(MCoaDoc param)
        {
            var act = new DeleteCoaDocByIdAction(database, orgId);
            var result = act.Apply<MCoaDoc>(param.Id);

            return result;
        }

        public MCoaDoc GetCoaDocById(MCoaDoc param)
        {
            var act = new GetCoaDocByIdAction(database, orgId);            
            var result = act.Apply<MCoaDoc>(param);

            return result;
        }

        public long GetCoaDocCount(MCoaDoc param)
        {
            var act = new GetCoaDocCountAction(database, orgId);
            var cnt = act.Apply<MCoaDoc>(param);

            return cnt;
        }
    }
}
