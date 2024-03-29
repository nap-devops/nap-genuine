using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Its.Jenuiue.Core.ModelsViews;
using Its.Jenuiue.Core.ModelsViews.Organization;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Services.Jobs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace Its.Jenuiue.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService service;
        private readonly IMapper mapper;
        private readonly IConfiguration cfg = null;

        public JobsController(IJobsService svc, IMapper mppr, IConfiguration configuration)
        {
            service = svc;
            mapper = mppr;
            cfg = configuration;
        }

        [HttpPost]
        [Route("org/{id}/action/GetJobs")]
        public IEnumerable<MVJob> GetJobs(string id, [FromBody] MVJobQuery data)
        {
            service.SetOrgId(id);
            var job = mapper.Map<MVJobQuery, MJob>(data);
            var jobs = service.GetJobs(job, data.QueryParam);

            var result = mapper.Map<IEnumerable<MJob>, IEnumerable<MVJob>>(jobs);
            return result;
        }

        [HttpPost]
        [Route("org/{id}/action/GetJobsCount")]
        public IActionResult GetJobsCount(string id, [FromBody] MVJobQuery data)
        {
            service.SetOrgId(id);
            var job = mapper.Map<MVJobQuery, MJob>(data);
            long cnt = service.GetJobsCount(job);

            return Ok(new MVCountResult(cnt));
        }

        [HttpGet]
        [Route("org/{id}/action/GetJobById/{objectId}")]
        public IActionResult GetJobById(string id, string objectId)
        {
            MJob m = new MJob();
            m.Id = objectId;

            service.SetOrgId(id);
            var job = service.GetJobById(m);
            var result = mapper.Map<MJob, MVJob>(job);

            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/CreateAssets")]
        public IActionResult CreateAssets(string id, [FromBody] MVJob data)
        {
            service.SetOrgId(id);
            var job = mapper.Map<MVJob, MJob>(data);
            job.Type = "CreateAsset";

            string projectId = cfg["Pubsub:ProjectId"];
            string topic = cfg["Pubsub:Topic"];

            var addedJob = service.AddJob(job, projectId, topic);
            var result = mapper.Map<MJob, MVJob>(addedJob);

            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/ExportAssets")]
        public IActionResult ExportAssets(string id, [FromBody] MVJob data)
        {
            service.SetOrgId(id);
            var job = mapper.Map<MVJob, MJob>(data);
            job.Type = "ExportAsset";

            string projectId = cfg["Pubsub:ProjectId"];
            string topic = cfg["Pubsub:Topic"];

            var addedJob = service.AddJob(job, projectId, topic);
            var result = mapper.Map<MJob, MVJob>(addedJob);

            return Ok(result);
        }

        [HttpPut]
        [Route("org/{id}/action/UpdateJobProgressById/{objectId}")]
        public IActionResult UpdateJobProgressById(string id, string objectId, [FromBody] MVJob data)
        {
            service.SetOrgId(id);
            var job = mapper.Map<MVJob, MJob>(data);
            job.Id = objectId;

            var updateObj = service.UpdateJobProgressById(job);
            if (updateObj.UpdatedCount <= 0)
            {
                return BadRequest("No record match for the update!!!");
            }

            var result = mapper.Map<MJob, MVJob>(updateObj);
            return Ok(result);
        }

        [HttpPut]
        [Route("org/{id}/action/UpdateJobStatusById/{objectId}")]
        public IActionResult UpdateJobStatusById(string id, string objectId, [FromBody] MVJob data)
        {
            service.SetOrgId(id);
            var job = mapper.Map<MVJob, MJob>(data);
            job.Id = objectId;

            var updateObj = service.UpdateJobStatusById(job);
            if (updateObj.UpdatedCount <= 0)
            {
                return BadRequest("No record match for the update!!!");
            }

            var result = mapper.Map<MJob, MVJob>(updateObj);
            return Ok(result);
        }
    }
}
