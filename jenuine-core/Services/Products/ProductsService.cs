using System.Collections.Generic;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Actions.Products;
using Its.Jenuiue.Core.Models.Organization;
using System;

namespace Its.Jenuiue.Core.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IDatabase database;
        private string orgId = "";

        public ProductsService(IDatabase db)
        {
            database = db;
        }

        public void SetOrgId(string id)
        {
            orgId = id;
        }

        public List<MProduct> GetProducts(MProduct param, QueryParam queryParam)
        {
            var act = new GetProductsAction(database, orgId);            
            var results = act.Apply<MProduct>(param, queryParam);

            return results;
        }

        public MProduct GetProductById(MProduct param)
        {
            var act = new GetProductByIdAction(database, orgId);            
            var product = act.Apply<MProduct>(param);

            return product;            
        }

        public MProduct GetProductByGeneratedId(MProduct param)
        {
            var act = new GetProductByGeneratedIdAction(database, orgId);            
            var product = act.Apply<MProduct>(param);

            return product;
        }

        public long GetProductsCount(MProduct param)
        {
            var act = new GetProductCountAction(database, orgId);
            var cnt = act.Apply<MProduct>(param);

            return cnt;
        }

        public MProduct AddProduct(MProduct param)
        {
            string regId = param.ProductId;
            if (string.IsNullOrEmpty(regId))
            {
                //Create if if not provided by caller
                Guid guid = Guid.NewGuid();
                regId = guid.ToString();
            }
            
            var act = new AddProductAction(database, orgId);
            param.ProductId = regId;
            var result = act.Apply<MProduct>(param);

            return result;
        }

        public MProduct UpdateProduct(MProduct param)
        {
            var act = new UpdateProductByIdAction(database, orgId);
            var result = act.Apply<MProduct>(param);

            return result;
        }

        public MProduct DeleteProduct(MProduct param)
        {
            var act = new DeleteProductByIdAction(database, orgId);
            var result = act.Apply<MProduct>(param.Id);

            return result;
        }
    }
}
