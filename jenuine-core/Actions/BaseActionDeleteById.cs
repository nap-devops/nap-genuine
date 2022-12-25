using MongoDB.Driver;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions
{
    public abstract class BaseActionDeleteById : IActionDelete
    {
        private IDatabase dbConn;
        private IMongoDatabase db;

        protected abstract string GetCollectionName();

        protected virtual bool UseGlobalDb()
        {
            return false;
        }

        protected void Init(IDatabase conn, string orgId)
        {
            dbConn = conn;
            db = conn.GetOrganizeDb(orgId);
        }

        public T Apply<T>(string objectId)
        {
            bool isGlobalDb = UseGlobalDb();
            string collName = GetCollectionName();

            IMongoCollection<T> collection;
            if (isGlobalDb)
            {
                collection = dbConn.GetCollectionGlobal<T>(collName);
            }
            else
            {
                collection = db.GetCollection<T>(collName);
            }

            var filter = Builders<T>.Filter.Eq("Id", objectId);
            T m = collection.FindOneAndDelete(filter);
            
            return m;
        }
    }
}
