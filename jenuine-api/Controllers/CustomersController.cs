using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Its.Jenuiue.Core.ModelsViews;
using Its.Jenuiue.Core.ModelsViews.Organization;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Services.Customers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Its.Jenuiue.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService service;
        private readonly IMapper mapper;

        public CustomersController(ICustomersService svc, IMapper mppr)
        {
            service = svc;
            mapper = mppr;
        }

        [HttpPost]
        [Route("org/{id}/action/GetCustomers")]
        public IEnumerable<MVCustomer> GetCustomers(string id, [FromBody] MVCustomerQuery data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCustomerQuery, MCustomer>(data);
            var models = service.GetCustomers(model, data.QueryParam);

            var result = mapper.Map<IEnumerable<MCustomer>, IEnumerable<MVCustomer>>(models);
            return result;
        }

        [HttpPost]
        [Route("org/{id}/action/GetCustomerCount")]
        public IActionResult GetCustomersCount(string id, [FromBody] MVCustomerQuery data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCustomerQuery, MCustomer>(data);
            long cnt = service.GetCustomersCount(model);

            return Ok(new MVCountResult(cnt));
        }

        [HttpGet]
        [Route("org/{id}/action/GetCustomerById/{objectId}")]
        public IActionResult GetCustomerById(string id, string objectId)
        {
            MCustomer m = new MCustomer();
            m.Id = objectId;

            service.SetOrgId(id);
            var model = service.GetCustomerById(m);
            var result = mapper.Map<MCustomer, MVCustomer>(model);

            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/AddCustomer")]
        public IActionResult AddCustomer(string id, [FromBody] MVCustomer data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCustomer, MCustomer>(data);

            var addedModel = service.AddCustomer(model);
            var result = mapper.Map<MCustomer, MVCustomer>(addedModel);

            return Ok(result);
        }

        [HttpDelete]
        [Route("org/{id}/action/DeleteCustomerById/{objectId}")]
        public IActionResult DeleteCustomerById(string id, string objectId)
        {
            MCustomer m = new MCustomer();
            m.Id = objectId;

            service.SetOrgId(id);
            var deletedObj = service.DeleteCustomer(m);

            var result = mapper.Map<MCustomer, MVCustomer>(deletedObj);

            return Ok(result);
        }

        [HttpPut]
        [Route("org/{id}/action/UpdateCustomerById/{objectId}")]
        public IActionResult UpdateProductById(string id, string objectId, [FromBody] MVCustomer data)
        {
            service.SetOrgId(id);
            var model = mapper.Map<MVCustomer, MCustomer>(data);
            model.Id = objectId;

            var updateObj = service.UpdateCustomer(model);
            if (updateObj.UpdatedCount <= 0)
            {
                return BadRequest("No record match for the update!!!");
            }

            var result = mapper.Map<MCustomer, MVCustomer>(updateObj);
            return Ok(result);
        }
    }
}
