using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Its.Jenuiue.Api.ModelsViews;
using Its.Jenuiue.Api.ModelsViews.Organization;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Services.Products;
using AutoMapper;

namespace Its.Jenuiue.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService service;
        private readonly IMapper mapper;

        public ProductsController(IProductsService svc, IMapper mppr)
        {
            service = svc;
            mapper = mppr;
        }

        [HttpGet]
        [Route("org/{id}/action/GetProducts")]
        public IEnumerable<MVProduct> GetProducts(string id) //[FromBody] MVProduct data
        {
            service.SetOrgId(id);
            var products = service.GetProducts(null, new QueryParam());

            var result = mapper.Map<IEnumerable<MProduct>, IEnumerable<MVProduct>>(products);
            return result;
        }

        [HttpGet]
        [Route("org/{id}/action/GetProductsCount")]
        public IActionResult GetProductsCount(string id)
        {
            service.SetOrgId(id);
            long cnt = service.GetProductsCount();

            return Ok(new MVCountResult(cnt));
        }

        [HttpGet]
        [Route("org/{id}/action/GetProductById/{objectId}")]
        public IActionResult GetProductById(string id, string objectId)
        {
            MProduct m = new MProduct();
            m.Id = objectId;

            service.SetOrgId(id);
            var product = service.GetProductById(m);
            var result = mapper.Map<MProduct, MVProduct>(product);

            return Ok(result);
        }

        [HttpPost]
        [Route("org/{id}/action/AddProduct")]
        public IActionResult AddProduct(string id, [FromBody] MVProduct data)
        {
            service.SetOrgId(id);
            var product = mapper.Map<MVProduct, MProduct>(data);

            var addedProduct = service.AddProduct(product);
            var result = mapper.Map<MProduct, MVProduct>(addedProduct);

            return Ok(result);
        }

        [HttpDelete]
        [Route("org/{id}/action/DeleteProductById/{objectId}")]
        public IActionResult DeleteProductById(string id, string objectId)
        {
            MProduct m = new MProduct();
            m.Id = objectId;

            service.SetOrgId(id);
            var deletedObj = service.DeleteProduct(m);

            var result = mapper.Map<MProduct, MVProduct>(deletedObj);

            return Ok(result);
        }

        [HttpPut]
        [Route("org/{id}/action/UpdateProductById/{objectId}")]
        public IActionResult UpdateProductById(string id, string objectId, [FromBody] MVProduct data)
        {
            service.SetOrgId(id);
            var product = mapper.Map<MVProduct, MProduct>(data);
            product.Id = objectId;

            var updateObj = service.UpdateProduct(product);

            var result = mapper.Map<MProduct, MVProduct>(updateObj);

            return Ok(result);
        }        
    }
}
