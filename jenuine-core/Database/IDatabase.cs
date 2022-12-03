using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Its.Jenuiue.Core.Database
{
    public interface IDatabase
    {
        public IMongoDatabase GetOrganizeDb(string orgId);
        public IMongoCollection<T> GetCollectionGlobal<T>(string name);
    }
}
