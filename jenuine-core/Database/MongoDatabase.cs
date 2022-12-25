using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Its.Jenuiue.Core.Database
{
    public class MongoDatabase : IDatabase
    {
        private const string GLOBAL_DB_NAME = "_global_";
        private readonly IMongoClient conn = null;
        private readonly IMongoDatabase globalDb = null;

        public MongoDatabase(IMongoClient client)
        {
            conn = client;
            globalDb = conn.GetDatabase(GLOBAL_DB_NAME);
        }

        public IMongoDatabase GetOrganizeDb(string orgId)
        {
            var db = conn.GetDatabase(orgId);
            return db;
        }

        public IMongoCollection<T> GetCollectionGlobal<T>(string name)
        {
            var coll = globalDb.GetCollection<T>(name);
            return coll;
        }     
    }
}
