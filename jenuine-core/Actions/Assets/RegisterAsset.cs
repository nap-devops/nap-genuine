using System;
using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Actions.Registration;

namespace Its.Jenuiue.Core.Actions.Assets
{
    public class RegisterAssetAction : IActionManipulate
    {
        private IDatabase dbConn;
        private IMongoDatabase db;
        private string org;

        public RegisterAssetAction(IDatabase conn, string orgId)
        {
            dbConn = conn;
            db = conn.GetOrganizeDb(orgId);
            org = orgId;
        }

        private string GetCollectionName()
        {
            return "assets";
        }

        private FilterDefinition<T> GetFilter<T>(T model)
        {
            var md = model as MAsset;
            var filter1 = Builders<T>.Filter.Eq("SerialNo", md.SerialNo);
            var filter2 = Builders<T>.Filter.Eq("PinNo", md.PinNo);

            var filter = Builders<T>.Filter.And(filter1, filter2);

            return filter;
        }

        public T Apply<T>(T param)
        {
            string collName = GetCollectionName();
            var collection = db.GetCollection<T>(collName);

            var filter = GetFilter<T>(param);
            var results = collection.Find(filter).ToList();

            if (results.Count <= 0)
            {
                (param as MAsset).LastActionStatus = "Serial and pin not found!!!";
                return param;
            }

            if (results.Count > 1)
            {
                (param as MAsset).LastActionStatus = "Found serial and pin more than one instance!!!";
                return param;
            }

            var asset = results[0];
            if ((asset as MAsset).IsRegistered)
            {
                (param as MAsset).LastActionStatus = "Serial and pin is already registered!!!";
                (param as MAsset).RegisteredInfo = (asset as MAsset).RegisteredInfo;
                return param;
            }

            (asset as MAsset).IsRegistered = true;
            Guid guid = Guid.NewGuid();
            string regId = guid.ToString();

            var reg = new MRegistration()
            {
                RegistrationId = regId,
                RegisteredDate = DateTime.Now
            };
            var addAct = new AddRegistrationAction(dbConn, org);
            var addResult = addAct.Apply<MRegistration>(reg);

            (asset as MAsset).RegisteredInfo = addResult;
            var updateAct = new UpdateAssetRegisterStatusByIdAction(dbConn, org);
            var updateResult = updateAct.Apply<MAsset>(asset as MAsset);

            return (T)(object) updateResult;
        }
    }
}
