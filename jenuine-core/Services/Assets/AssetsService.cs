using System;
using System.Collections.Generic;
using Its.Jenuiue.Core.Database;
using Its.Jenuiue.Core.Models;
using Its.Jenuiue.Core.Actions.Assets;
using Its.Jenuiue.Core.Models.Organization;

namespace Its.Jenuiue.Core.Services.Assets
{
    public class AssetsService : IAssetsService
    {
        private readonly IDatabase database;
        private string orgId = "";

        public AssetsService(IDatabase db)
        {
            database = db;
        }

        public void SetOrgId(string id)
        {
            orgId = id;
        }

        public List<MAsset> GetAssets(MAsset param, QueryParam queryParam)
        {
            var act = new GetAssetsAction(database, orgId);
            var results = act.Apply<MAsset>(param, queryParam);

            return results;
        }

        public MAsset AddAsset(MAsset param)
        {
            var act = new AddAssetAction(database, orgId);

            var result = new MAsset();
            param.AssetId = string.Format("{0}-{1}", param.PinNo, param.SerialNo);
            try
            {
                result = act.Apply<MAsset>(param);
            }
            catch (Exception e)
            {
                result.LastActionStatus = e.Message;
            }

            return result;
        }

        public MAsset GetAssetById(MAsset param)
        {
            var act = new GetAssetByIdAction(database, orgId);            
            var asset = act.Apply<MAsset>(param);

            return asset;            
        }

        public long GetAssetsCount()
        {
            var m = new MAsset();

            var act = new GetAssetCountAction(database, orgId);
            var cnt = act.Apply<MAsset>(m);

            return cnt;
        }

        public MAsset UpdateAsset(MAsset param)
        {
            var act = new UpdateAssetByIdAction(database, orgId);
            var result = act.Apply<MAsset>(param);

            return result;
        }

        public MAsset UpdateAssetRegisterFlag(MAsset param)
        {
            var act = new UpdateAssetRegisterStatusByIdAction(database, orgId);
            var result = act.Apply<MAsset>(param);

            return result;
        }

        public MAsset DeleteAsset(MAsset param)
        {
            var act = new DeleteAssetByIdAction(database, orgId);
            var result = act.Apply<MAsset>(param.Id);

            return result;
        }

        public MAsset RegisterAsset(MAsset param, string key)
        {
            var act = new RegisterAssetAction(database, orgId);

            act.SetSymetricKey(key);
            var result = act.Apply<MAsset>(param);

            return result;
        }
    }
}
