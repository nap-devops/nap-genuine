using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.CoaSpecs
{
    public class DeleteCoaSpecByIdAction : BaseActionDeleteById
    {
        public DeleteCoaSpecByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "coa_specs";
        }                     
    }
}
