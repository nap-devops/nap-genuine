using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Actions
{
    public abstract class BaseActionUpdateById : IActionManipulate
    {
        private IDatabase dbConn;
        private IMongoDatabase db;

        protected abstract string GetCollectionName();
        protected abstract List<string> GetUpdateFields();

        protected virtual bool UseGlobalDb()
        {
            return false;
        }

        protected void Init(IDatabase conn, string orgId)
        {
            dbConn = conn;
            db = conn.GetOrganizeDb(orgId);
        }
        
        public T Apply<T>(T param)
        {
            string objectId = (param as BaseModel).Id;
            var updateFields = GetUpdateFields();

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

            var filter = Builders<T>.Filter.Eq("Id", new ObjectId(objectId));

            var update = Builders<T>.Update;
            var updateDef = update.Set("ModifiedDtm", DateTime.UtcNow);

            foreach (string field in updateFields)
            {
                //Support only one level field now
                var value = param.GetType().GetProperty(field).GetValue(param, null);
                updateDef = updateDef.Set(field, value);
            }

            collection.UpdateOne(filter, updateDef);

            return param;
        }
    }
}
