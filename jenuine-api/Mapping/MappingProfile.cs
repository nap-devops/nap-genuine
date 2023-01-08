using AutoMapper;
using Its.Jenuiue.Core.Models.Organization;
using Its.Jenuiue.Api.ModelsViews.Organization;

namespace Its.Jenuiue.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MProduct, MVProduct>();
            CreateMap<MVProduct, MProduct>();

            CreateMap<MAsset,MVAsset>();            
            CreateMap<MVAsset,MAsset>();

            CreateMap<MAsset,MVAssetQuery>();
            CreateMap<MVAssetQuery,MAsset>();

            CreateMap<MJob,MVJob>();
            CreateMap<MVJob,MJob>();            
        }
    }
}