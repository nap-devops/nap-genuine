using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Its.Jenuiue.Core.ModelsViews.Organization;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Services.Configs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Its.Jenuiue.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/api/[controller]")]
    public class ConfigsController : ControllerBase
    {
        private readonly IConfigsService service;
        private readonly IMapper mapper;

        public ConfigsController(IConfigsService svc, IMapper mppr)
        {
            service = svc;
            mapper = mppr;
        }

        [HttpPost]
        [Route("org/{id}/action/GetConfigs")]
        public IEnumerable<MVConfig> GetConfigs(string id, [FromBody] MVConfigQuery data)
        {
            //There should be 0 or only 1 records returned

            service.SetOrgId(id);
            var config = mapper.Map<MVConfigQuery, MConfig>(data);
            var configs = service.GetConfigs(config, data.QueryParam);

            var result = mapper.Map<IEnumerable<MConfig>, IEnumerable<MVConfig>>(configs);
            return result;
        }

        [HttpPost]
        [Route("org/{id}/action/AddConfig")]
        public IActionResult AddProduct(string id, [FromBody] MVConfig data)
        {
            service.SetOrgId(id);
            var config = mapper.Map<MVConfig, MConfig>(data);

            var addedConfig = service.AddConfig(config);
            var result = mapper.Map<MConfig, MVConfig>(addedConfig);

            return Ok(result);
        }

        [HttpPut]
        [Route("org/{id}/action/UpdateConfigById/{objectId}")]
        public IActionResult UpdateConfigById(string id, string objectId, [FromBody] MVConfig data)
        {
            service.SetOrgId(id);
            var config = mapper.Map<MVConfig, MConfig>(data);
            config.Id = objectId;

            var updateObj = service.UpdateConfig(config);
            if (updateObj.UpdatedCount <= 0)
            {
                return BadRequest("No record match for the update!!!");
            }

            var result = mapper.Map<MConfig, MVConfig>(updateObj);
            return Ok(result);
        }
    }
}
