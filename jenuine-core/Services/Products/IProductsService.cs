using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Services.Products
{
    public interface IProductsService
    {
        public void SetOrgId(string id);
        public List<MProduct> GetProducts(MProduct param, QueryParam queryParam);

        public MProduct GetProductById(MProduct param);

        public long GetProductsCount(MProduct param);

        public MProduct AddProduct(MProduct param);

        public MProduct UpdateProduct(MProduct param);

        public MProduct DeleteProduct(MProduct param);
        
    }
}
