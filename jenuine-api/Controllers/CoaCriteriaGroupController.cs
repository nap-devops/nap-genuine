using System;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Its.Jenuiue.Core.ModelsViews;
using Its.Jenuiue.Core.ModelsViews.Organization;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Services.CoaCriteria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace Its.Jenuiue.Api.Controllers
{
    [ApiController]
    [Route("/api/coa_criteria_group")]
    [Authorize]
    public class CoaCriteriaGroupController : ControllerBase
    {
        private const int RefType = 2; //CriteriaGroup
        private readonly ICoaCriteriaService service;
        private readonly IMapper mapper;
        private readonly IConfiguration cfg;

        public CoaCriteriaGroupController(ICoaCriteriaService svc, IMapper mppr, IConfiguration configuration)
        {
            service = svc;
            mapper = mppr;
            cfg = configuration;
        }

        [HttpPost]
        [Route("org/{id}/action/GetCoaCriteriaGroup")]
        public IEnumerable<MVCoaCriteria> GetCoaCriteriaGroup(string id, [FromBody] MVCoaCriteriaQuery data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCoaCriteriaQuery, MCoaCriteria>(data);
            model.RefType = RefType;
            var arr = service.GetCoaCriteria(model, data.QueryParam);

            var result = mapper.Map<IEnumerable<MCoaCriteria>, IEnumerable<MVCoaCriteria>>(arr);
            return result;
        }

        [HttpPost]
        [Route("org/{id}/action/GetCoaCriteriaGroupCount")]
        public IActionResult GetCoaCriteriaGroupCount(string id, [FromBody] MVCoaCriteriaQuery data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCoaCriteriaQuery, MCoaCriteria>(data);
            model.RefType = RefType;
            long cnt = service.GetCoaCriteriaCount(model);

            return Ok(new MVCountResult(cnt));
        }

        [HttpGet]
        [Route("org/{id}/action/GetCoaCriteriaGroupById/{objectId}")]
        public IActionResult GetCoaCriteriaGroupById(string id, string objectId)
        {
            MCoaCriteria m = new MCoaCriteria();
            m.Id = objectId;

            service.SetOrgId(id);
            var model = service.GetCoaCriteriaById(m);
            var result = mapper.Map<MCoaCriteria, MVCoaCriteria>(model);

            return Ok(result);
        }        

        [HttpPost]
        [Route("org/{id}/action/AddCoaCriteriaGroup")]
        public IActionResult AddCoaCriteriaGroup(string id, [FromBody] MVCoaCriteria data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCoaCriteria, MCoaCriteria>(data);
            model.RefType = RefType;

            var addedObj = service.AddCoaCriteria(model);
            var result = mapper.Map<MCoaCriteria, MVCoaCriteria>(addedObj);

            var status = result.LastActionStatus;
            if (string.IsNullOrEmpty(status))
            {
                return Ok(result);
            }

            return BadRequest(status);
        }

        [HttpDelete]
        [Route("org/{id}/action/DeleteCoaCriteriaGroupById/{objectId}")]
        public IActionResult DeleteCoaCriteriaGroupById(string id, string objectId)
        {
            MCoaCriteria m = new MCoaCriteria();
            m.Id = objectId;

            service.SetOrgId(id);
            var deletedObj = service.DeleteCoaCriteria(m);

            var result = mapper.Map<MCoaCriteria, MVCoaCriteria>(deletedObj);

            return Ok(result);
        }

        [HttpPut]
        [Route("org/{id}/action/UpdateCoaCriteriaGroupById/{objectId}")]
        public IActionResult UpdateCoaCriteriaGroupById(string id, string objectId, [FromBody] MVCoaCriteria data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCoaCriteria, MCoaCriteria>(data);
            model.Id = objectId;
            model.RefType = RefType;

            var updateObj = service.UpdateCoaCriteria(model);
            var result = mapper.Map<MCoaCriteria, MVCoaCriteria>(updateObj);

            return Ok(result);
        }
    }
}
