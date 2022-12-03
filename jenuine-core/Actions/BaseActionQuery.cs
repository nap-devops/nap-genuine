using MongoDB.Driver;
using System.Collections.Generic;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Actions
{
    public abstract class BaseActionQuery : IActionQuery
    {
        private IDatabase dbConn;
        private IMongoDatabase db;

        protected abstract string GetCollectionName();

        protected abstract FilterDefinition<T> GetFilter<T>(T model);

        protected virtual bool UseGlobalDb()
        {
            return false;
        }

        protected void Init(IDatabase conn, string orgId)
        {
            dbConn = conn;
            db = conn.GetOrganizeDb(orgId);
        }        

        public List<T> Apply<T>(T param, QueryParam queryParam)
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

            var filter = GetFilter<T>(param);
            var results = collection.Find(filter).ToList();

            return results;
        }
    }
}
