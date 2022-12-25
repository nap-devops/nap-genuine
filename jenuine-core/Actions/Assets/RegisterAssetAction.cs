using System;
using Serilog;
using MongoDB.Driver;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Actions.Registration;
using Its.Jenuiue.Core.Actions.Products;
using Its.Jenuiue.Core.Utils;

namespace Its.Jenuiue.Core.Actions.Assets
{
    public class RegisterAssetAction : IActionManipulate
    {
        private readonly string defaultUrl = "https://aldamex.com/product-registration/?status={0}&serial={1}&pin={2}&statusCode={3}";
        private IDatabase dbConn;
        private IMongoDatabase db;
        private string org;
        private string key = null; //This should get from DB instead

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

        private string FormatUrl(string url, string status, string serial, string pin, string statusCode)
        {
            var templateUrl = url;
            if (string.IsNullOrEmpty(url))
            {
                templateUrl = defaultUrl;
            }

            String formattedUrl = String.Format(templateUrl, 
                EncryptUtil.EncryptString(status, key),
                EncryptUtil.EncryptString(serial, key), 
                EncryptUtil.EncryptString(pin, key),
                EncryptUtil.EncryptString(statusCode, key));

            return formattedUrl;
        }

        private string CreateRedirectUrl(MAsset asset, string status, string statusCode)
        {
            string serial = asset.SerialNo;
            string pin = asset.PinNo;

            if (!asset.NeedRedirect)
            {
                return "";
            }

            if (String.IsNullOrEmpty(asset.ProductId))
            {
                Log.Error($"Unable to find [ProductId] value for asset serial=[{serial}] pin=[{pin}]");
                return FormatUrl(defaultUrl, status, serial, pin, "ERROR");
            }

            var p = new MProduct()
            {
                Id = asset.ProductId
            };
            var act = new GetProductByIdAction(dbConn, org);
            var assetProduct = act.Apply<MProduct>(p);
            if (assetProduct == null)
            {
                Log.Error($"Unable to find [Production] object for asset serial=[{serial}] pin=[{pin}]");
                return FormatUrl(defaultUrl, status, serial, pin, "ERROR");
            }

            return FormatUrl(assetProduct.RedirectUrl, status, serial, pin, statusCode);;
        }

        public void SetSymetricKey(string keyStr)
        {
            key = keyStr;
        }

        public T Apply<T>(T param)
        {
            string status = "";
            string serial = (param as MAsset).SerialNo;
            string pin = (param as MAsset).PinNo;

            string collName = GetCollectionName();
            var collection = db.GetCollection<T>(collName);

            var filter = GetFilter<T>(param);
            var results = collection.Find(filter).ToList();

            if (results.Count <= 0)
            {
                status = "Serial and pin not found!!!";
                (param as MAsset).LastActionStatus = status;
                (param as MAsset).RedirectUrl = FormatUrl(defaultUrl, status, serial, pin, "ERROR");

                Log.Error($"Status=[{status}] serial=[{serial}] pin=[{pin}]");
                return param;
            }

            if (results.Count > 1)
            {
                status = "Found serial and pin more than one instance!!!";
                (param as MAsset).LastActionStatus = status;
                (param as MAsset).RedirectUrl = FormatUrl(defaultUrl, status, serial, pin, "ERROR");

                Log.Error($"Status=[{status}] serial=[{serial}] pin=[{pin}]");
                return param;
            }

            var asset = results[0];
            (asset as MAsset).NeedRedirect = (param as MAsset).NeedRedirect;

            if ((asset as MAsset).IsRegistered)
            {
                status = "Serial and pin is already registered!!!";
                (param as MAsset).LastActionStatus = status;
                (param as MAsset).RegisteredInfo = (asset as MAsset).RegisteredInfo;
                (param as MAsset).RedirectUrl = CreateRedirectUrl((asset as MAsset), status, "ERROR");

                Log.Error($"Status=[{status}] serial=[{serial}] pin=[{pin}]");
                return param;
            }
            
            Guid guid = Guid.NewGuid();
            string regId = guid.ToString();

            var reg = new MRegistration()
            {
                RegistrationId = regId,
                RegisteredDate = DateTime.Now
            };
            var addAct = new AddRegistrationAction(dbConn, org);
            var addResult = addAct.Apply<MRegistration>(reg);            

            (asset as MAsset).IsRegistered = true;
            (asset as MAsset).RegisteredInfo = addResult;            

            var updateAct = new UpdateAssetRegisterStatusByIdAction(dbConn, org);
            var updateResult = updateAct.Apply<MAsset>(asset as MAsset);

            status = "Serial and pin registered succesfully";
            updateResult.RedirectUrl = CreateRedirectUrl((asset as MAsset), status, "SUCCESS");
            Log.Information($"Status=[{status}] serial=[{serial}] pin=[{pin}]");

            return (T)(object) updateResult;
        }
    }
}
