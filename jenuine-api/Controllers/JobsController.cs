using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Its.Jenuiue.Api.ModelsViews;
using Its.Jenuiue.Api.ModelsViews.Organization;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Services.Jobs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Its.Jenuiue.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService service;
        private readonly IMapper mapper;

        public JobsController(IJobsService svc, IMapper mppr)
        {
            service = svc;
            mapper = mppr;
        }

        [HttpGet]
        [Route("org/{id}/action/GetJobs")]
        public IEnumerable<MVJob> GetJobs(string id) //[FromBody] MVJob data
        {
            service.SetOrgId(id);
            var jobs = service.GetJobs(null, new QueryParam());

            var result = mapper.Map<IEnumerable<MJob>, IEnumerable<MVJob>>(jobs);
            return result;
        }

        [HttpGet]
        [Route("org/{id}/action/GetJobsCount")]
        public IActionResult GetJobsCount(string id)
        {
            service.SetOrgId(id);
            long cnt = service.GetJobsCount();

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
        [Route("org/{id}/action/AddJob")]
        public IActionResult AddJob(string id, [FromBody] MVJob data)
        {
            service.SetOrgId(id);
            var job = mapper.Map<MVJob, MJob>(data);

            var addedJob = service.AddJob(job);
            var result = mapper.Map<MJob, MVJob>(addedJob);

            return Ok(result);
        }
    }
}
