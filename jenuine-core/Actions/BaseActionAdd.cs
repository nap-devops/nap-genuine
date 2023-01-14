using System;
using MongoDB.Driver;
using MongoDB.Bson;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Database;

namespace Its.Jenuiue.Core.Actions
{
    public abstract class BaseActionAdd : IActionManipulate
    {
        private IDatabase dbConn;
        private IMongoDatabase db;

        protected abstract string GetCollectionName();

        protected virtual void PostAction<T>(T Param)
        {
        }

        protected virtual bool UseGlobalDb()
        {
            return false;
        }

        protected void Init(IDatabase conn, string orgId)
        {
            dbConn = conn;
            db = conn.GetOrganizeDb(orgId);
        }

        protected IMongoCollection<T> GetCollection<T>()        
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

            return collection;
        }

        public T Apply<T>(T param)
        {
            (param as BaseModel).CreatedDtm = DateTime.UtcNow;
            (param as BaseModel).ModifiedDtm = DateTime.UtcNow;
            (param as BaseModel).Id = ObjectId.GenerateNewId().ToString();

            IMongoCollection<T> collection = GetCollection<T>();

            collection.InsertOne(param);
            PostAction(param);

            return param;
        }
    }
}
