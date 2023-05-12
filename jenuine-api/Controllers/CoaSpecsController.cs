using System;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Its.Jenuiue.Core.ModelsViews.Organization;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Services.CoaSpecs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Its.Jenuiue.Core.ModelsViews;

namespace Its.Jenuiue.Api.Controllers
{
    [ApiController]
    [Route("/api/coa_specs")]
    [Authorize]
    public class CoaSpecsController : ControllerBase
    {
        private readonly ICoaSpecService service;
        private readonly IMapper mapper;
        private readonly IConfiguration cfg;

        public CoaSpecsController(ICoaSpecService svc, IMapper mppr, IConfiguration configuration)
        {
            service = svc;
            mapper = mppr;
            cfg = configuration;
        }

        [HttpPost]
        [Route("org/{id}/action/GetCoaSpec")]
        public IEnumerable<MVCoaSpec> GetCoaSpec(string id, [FromBody] MVCoaSpecQuery data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCoaSpecQuery, MCoaSpec>(data);
            var arr = service.GetCoaSpec(model, data.QueryParam);

            var result = mapper.Map<IEnumerable<MCoaSpec>, IEnumerable<MVCoaSpec>>(arr);
            return result;
        }

        [HttpPost]
        [Route("org/{id}/action/AddCoaSpec")]
        public IActionResult AddCoaSpec(string id, [FromBody] MVCoaSpec data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCoaSpec, MCoaSpec>(data);

            var addedObj = service.AddCoaSpec(model);
            var result = mapper.Map<MCoaSpec, MVCoaSpec>(addedObj);
            
            var status = result.LastActionStatus;
            if (string.IsNullOrEmpty(status))
            {
                return Ok(result);
            }

            return BadRequest(status);
        }

        [HttpPut]
        [Route("org/{id}/action/UpdateCoaSpecById/{objectId}")]
        public IActionResult UpdateCoaSpecById(string id, string objectId, [FromBody] MVCoaSpec data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCoaSpec, MCoaSpec>(data);
            model.Id = objectId;

            var updateObj = service.UpdateCoaSpec(model);
            var result = mapper.Map<MCoaSpec, MVCoaSpec>(updateObj);

            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/GetCoaSpecCount")]
        public IActionResult GetCoaSpecCount(string id, [FromBody] MVCoaSpecQuery data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCoaSpecQuery, MCoaSpec>(data);
            long cnt = service.GetCoaSpecCount(model);

            return Ok(new MVCountResult(cnt));
        }

        [HttpGet]
        [Route("org/{id}/action/GetCoaSpecById/{objectId}")]
        public IActionResult GetCoaSpecById(string id, string objectId)
        {
            MCoaSpec m = new MCoaSpec();
            m.Id = objectId;

            service.SetOrgId(id);
            var model = service.GetCoaSpecById(m);
            var result = mapper.Map<MCoaSpec, MVCoaSpec>(model);

            return Ok(result);
        }        

        [HttpDelete]
        [Route("org/{id}/action/DeleteCoaSpecById/{objectId}")]
        public IActionResult DeleteCoaSpecById(string id, string objectId)
        {
            MCoaSpec m = new MCoaSpec();
            m.Id = objectId;

            service.SetOrgId(id);
            var deletedObj = service.DeleteCoaSpec(m);

            var result = mapper.Map<MCoaSpec, MVCoaSpec>(deletedObj);

            return Ok(result);
        }
    }
}
