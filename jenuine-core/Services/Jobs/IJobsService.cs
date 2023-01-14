using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Services.Jobs
{
    public interface IJobsService
    {
        public void SetOrgId(string id);
        public List<MJob> GetJobs(MJob param, QueryParam queryParam);

        public MJob GetJobById(MJob param);

        public long GetJobsCount();

        public MJob AddJob(MJob param, string projectId, string topicName);
    }
}
