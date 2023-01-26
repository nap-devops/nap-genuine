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

        public long GetJobsCount(MJob job);

        public MJob AddJob(MJob param, string projectId, string topicName);

        public MJob UpdateJobProgressById(MJob job);
        public MJob UpdateJobStatusById(MJob job);
    }
}
