using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Its.Jenuiue.Api.ModelsViews;
using Its.Jenuiue.Api.ModelsViews.Organization;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Services.Assets;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Its.Jenuiue.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetsService service;
        private readonly IMapper mapper;

        public AssetsController(IAssetsService svc, IMapper mppr)
        {
            service = svc;
            mapper = mppr;
        }

        [HttpGet]
        [Route("org/{id}/action/GetAssets")]
        public IEnumerable<MVAsset> GetAssets(string id) //[FromBody] MVAsset data
        {
            service.SetOrgId(id);
            var assets = service.GetAssets(null, new QueryParam());

            var result = mapper.Map<IEnumerable<MAsset>, IEnumerable<MVAsset>>(assets);
            return result;
        }

        [HttpGet]
        [Route("org/{id}/action/GetAssetsCount")]
        public IActionResult GetAssetsCount(string id)
        {
            service.SetOrgId(id);
            long cnt = service.GetAssetsCount();

            return Ok(new MVCountResult(cnt));
        }

        [HttpGet]
        [Route("org/{id}/action/GetAssetById/{objectId}")]
        public IActionResult GetAssetById(string id, string objectId)
        {
            MAsset m = new MAsset();
            m.Id = objectId;

            service.SetOrgId(id);
            var asset = service.GetAssetById(m);
            var result = mapper.Map<MAsset, MVAsset>(asset);

            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/AddAsset")]
        public IActionResult AddAsset(string id, [FromBody] MVAsset data)
        {
            service.SetOrgId(id);
            var asset = mapper.Map<MVAsset, MAsset>(data);

            var addedAsset = service.AddAsset(asset);
            var result = mapper.Map<MAsset, MVAsset>(addedAsset);
            
            var status = result.LastActionStatus;
            if (string.IsNullOrEmpty(status))
            {
                return Ok(result);
            }

            return BadRequest(status);
        }

        [HttpDelete]
        [Route("org/{id}/action/DeleteAssetById/{objectId}")]
        public IActionResult DeleteAssetById(string id, string objectId)
        {
            MAsset m = new MAsset();
            m.Id = objectId;

            service.SetOrgId(id);
            var deletedObj = service.DeleteAsset(m);

            var result = mapper.Map<MAsset, MVAsset>(deletedObj);

            return Ok(result);
        }

        [HttpPut]
        [Route("org/{id}/action/UpdateAssetById/{objectId}")]
        public IActionResult UpdateAssetById(string id, string objectId, [FromBody] MVAsset data)
        {
            service.SetOrgId(id);
            var asset = mapper.Map<MVAsset, MAsset>(data);
            asset.Id = objectId;

            var updateObj = service.UpdateAsset(asset);

            var result = mapper.Map<MAsset, MVAsset>(updateObj);

            return Ok(result);
        }    

        [HttpPut]
        [Route("org/{id}/action/UpdateAssetRegisterFlagById/{objectId}")]
        public IActionResult UpdateAssetRegisterFlagById(string id, string objectId, [FromBody] MVAsset data)
        {
            service.SetOrgId(id);
            var asset = mapper.Map<MVAsset, MAsset>(data);
            asset.Id = objectId;

            var updateObj = service.UpdateAssetRegisterFlag(asset);

            var result = mapper.Map<MAsset, MVAsset>(updateObj);

            return Ok(result);
        }

        [HttpGet]
        [Route("org/{id}/action/RegisterAsset/{serialNo}/{pinNo}")]
        public IActionResult RegisterAsset(string id, string serialNo, string pinNo)
        {
            service.SetOrgId(id);

            var asset = new MAsset();
            asset.PinNo = pinNo;
            asset.SerialNo = serialNo;

            var updateObj = service.RegisterAsset(asset);
            var result = mapper.Map<MAsset, MVAsset>(updateObj);

            var status = result.LastActionStatus;
            if (string.IsNullOrEmpty(status))
            {
                return Ok(result);
            }

            return BadRequest(status);
        }        
    }
}
