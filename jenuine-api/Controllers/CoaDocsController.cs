using System;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Its.Jenuiue.Core.ModelsViews.Organization;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Services.CoaDocs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Its.Jenuiue.Core.ModelsViews;

namespace Its.Jenuiue.Api.Controllers
{
    [ApiController]
    [Route("/api/coa_docs")]
    [Authorize]
    public class CoaDocsController : ControllerBase
    {
        private readonly ICoaDocService service;
        private readonly IMapper mapper;
        private readonly IConfiguration cfg;

        public CoaDocsController(ICoaDocService svc, IMapper mppr, IConfiguration configuration)
        {
            service = svc;
            mapper = mppr;
            cfg = configuration;
        }

        [HttpPost]
        [Route("org/{id}/action/GetCoaDoc")]
        public IEnumerable<MVCoaDoc> GetCoaDoc(string id, [FromBody] MVCoaDocQuery data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCoaDocQuery, MCoaDoc>(data);
            var arr = service.GetCoaDoc(model, data.QueryParam);

            var result = mapper.Map<IEnumerable<MCoaDoc>, IEnumerable<MVCoaDoc>>(arr);
            return result;
        }

        [HttpPost]
        [Route("org/{id}/action/AddCoaDoc")]
        public IActionResult AddCoaDoc(string id, [FromBody] MVCoaDoc data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCoaDoc, MCoaDoc>(data);

            var addedObj = service.AddCoaDoc(model);
            var result = mapper.Map<MCoaDoc, MVCoaDoc>(addedObj);
            
            var status = result.LastActionStatus;
            if (string.IsNullOrEmpty(status))
            {
                return Ok(result);
            }

            return BadRequest(status);
        }

        [HttpPut]
        [Route("org/{id}/action/UpdateCoaDocById/{objectId}")]
        public IActionResult UpdateCoaDocById(string id, string objectId, [FromBody] MVCoaDoc data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCoaDoc, MCoaDoc>(data);
            model.Id = objectId;

            var updateObj = service.UpdateCoaDoc(model);
            var result = mapper.Map<MCoaDoc, MVCoaDoc>(updateObj);

            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/GetCoaDocCount")]
        public IActionResult GetCoaDocCount(string id, [FromBody] MVCoaDocQuery data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCoaDocQuery, MCoaDoc>(data);
            long cnt = service.GetCoaDocCount(model);

            return Ok(new MVCountResult(cnt));
        }

        [HttpGet]
        [Route("org/{id}/action/GetCoaDocById/{objectId}")]
        public IActionResult GetCoaDocById(string id, string objectId)
        {
            MCoaDoc m = new MCoaDoc();
            m.Id = objectId;

            service.SetOrgId(id);
            var model = service.GetCoaDocById(m);
            var result = mapper.Map<MCoaDoc, MVCoaDoc>(model);

            return Ok(result);
        }        

        [HttpDelete]
        [Route("org/{id}/action/DeleteCoaDocById/{objectId}")]
        public IActionResult DeleteCoaDocById(string id, string objectId)
        {
            MCoaDoc m = new MCoaDoc();
            m.Id = objectId;

            service.SetOrgId(id);
            var deletedObj = service.DeleteCoaDoc(m);

            var result = mapper.Map<MCoaDoc, MVCoaDoc>(deletedObj);

            return Ok(result);
        }
    }
}
