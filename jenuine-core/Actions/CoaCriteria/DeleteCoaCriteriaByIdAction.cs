using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions.CoaCriteria
{
    public class DeleteCoaCriteriaByIdAction : BaseActionDeleteById
    {
        public DeleteCoaCriteriaByIdAction(IDatabase conn, string orgId)
        {
            Init(conn, orgId);
        }

        protected override string GetCollectionName()
        {
            return "coa_criteria";
        }                     
    }
}