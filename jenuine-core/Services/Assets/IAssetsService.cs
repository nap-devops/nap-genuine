using System.Collections.Generic;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.Models;

namespace Its.Jenuiue.Core.Services.Assets
{
    public interface IAssetsService
    {
        public void SetOrgId(string id);
        public MAsset AddAsset(MAsset param);
        public List<MAsset> GetAssets(MAsset param, QueryParam queryParam);
        public MAsset GetAssetById(MAsset param);
        public long GetAssetsCount(MAsset param);
        public MAsset UpdateAsset(MAsset param);
        public MAsset UpdateAssetRegisterFlag(MAsset param);
        public MAsset DeleteAsset(MAsset param);
        public MAsset RegisterAsset(MAsset param, string key);
    }
}
