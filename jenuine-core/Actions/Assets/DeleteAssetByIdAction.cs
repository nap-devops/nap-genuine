using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.Assets
{
    public class DeleteAssetByIdAction : BaseActionDeleteById
    {
        public DeleteAssetByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "assets";
        }                     
    }
}
