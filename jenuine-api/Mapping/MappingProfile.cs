using AutoMapper;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Core.ModelsViews.Organization;

namespace Its.Jenuiue.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MProduct, MVProduct>();
            CreateMap<MVProduct, MProduct>();
            CreateMap<MProduct,MVProductQuery>();
            CreateMap<MVProductQuery,MProduct>();

            CreateMap<MAsset,MVAsset>();            
            CreateMap<MVAsset,MAsset>();

            CreateMap<MAsset,MVAssetQuery>();
            CreateMap<MVAssetQuery,MAsset>();

            CreateMap<MJob,MVJob>();
            CreateMap<MVJob,MJob>();            
        }
    }
}