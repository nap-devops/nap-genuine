using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Actions.Jobs;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Services.Jobs
{
    public class JobsService : IJobsService
    {
        private readonly IDatabase database;
        private string orgId = "";

        public JobsService(IDatabase db)
        {
            database = db;
        }

        public void SetOrgId(string id)
        {
            orgId = id;
        }

        public List<MJob> GetJobs(MJob param, QueryParam queryParam)
        {
            var act = new GetJobsAction(database, orgId);            
            var results = act.Apply<MJob>(param, queryParam);

            return results;
        }

        public MJob GetJobById(MJob param)
        {
            var act = new GetJobByIdAction(database, orgId);            
            var Job = act.Apply<MJob>(param);

            return Job;
        }

        public long GetJobsCount()
        {
            var m = new MJob();

            var act = new GetJobCountAction(database, orgId);
            var cnt = act.Apply<MJob>(m);

            return cnt;
        }

        public MJob AddJob(MJob param)
        {
            var act = new AddJobAction(database, orgId);

            param.JobDate = DateTime.Now;
            var result = act.Apply<MJob>(param);

            return result;
        }
    }
}
