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

        private string CreateRedirectUrl(MAsset asset, string status)
        {
            string redirectUrl = "https://aldamex.com/register-product/result?status={0}&serial={1}&pin={2}";

            string serial = asset.SerialNo;
            string pin = asset.PinNo;

            String url = String.Format(redirectUrl, status, serial, pin);

            return url;
        }

        public T Apply<T>(T param)
        {
            string status = "";

            string collName = GetCollectionName();
            var collection = db.GetCollection<T>(collName);

            var filter = GetFilter<T>(param);
            var results = collection.Find(filter).ToList();

            if (results.Count <= 0)
            {
                status = "Serial and pin not found!!!";
                (param as MAsset).LastActionStatus = status;
                (param as MAsset).RedirectUrl = CreateRedirectUrl((param as MAsset), status);

                return param;
            }

            if (results.Count > 1)
            {
                status = "Found serial and pin more than one instance!!!";
                (param as MAsset).LastActionStatus = status;
                (param as MAsset).RedirectUrl = CreateRedirectUrl((param as MAsset), status);

                return param;
            }

            var asset = results[0];
            if ((asset as MAsset).IsRegistered)
            {
                status = "Serial and pin is already registered!!!";
                (param as MAsset).LastActionStatus = status;
                (param as MAsset).RegisteredInfo = (asset as MAsset).RegisteredInfo;
                (param as MAsset).RedirectUrl = CreateRedirectUrl((param as MAsset), status);

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

            status = "Serial and pin registered succesfully";
            updateResult.RedirectUrl = CreateRedirectUrl((param as MAsset), status);

            return (T)(object) updateResult;
        }
    }
}
