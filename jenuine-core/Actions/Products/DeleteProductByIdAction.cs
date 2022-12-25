using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Products
{
    public class DeleteProductByIdAction : BaseActionDeleteById
    {
        public DeleteProductByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "products";
        }                     
    }
}
