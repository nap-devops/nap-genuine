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
            CreateMap<MJob,MVJobQuery>();
            CreateMap<MVJobQuery,MJob>();

            CreateMap<MCustomer,MVCustomer>();
            CreateMap<MVCustomer,MCustomer>();
            CreateMap<MCustomer,MVCustomerQuery>();
            CreateMap<MVCustomerQuery,MCustomer>();

            CreateMap<MConfig,MVConfig>();
            CreateMap<MVConfig,MConfig>();
            CreateMap<MConfig,MVConfigQuery>();
            CreateMap<MVConfigQuery,MConfig>();

            CreateMap<MCoaCriteria,MVCoaCriteria>();
            CreateMap<MVCoaCriteria,MCoaCriteria>();
            CreateMap<MCoaCriteria,MVCoaCriteriaQuery>();
            CreateMap<MVCoaCriteriaQuery,MCoaCriteria>();

            CreateMap<MCoaSpec,MVCoaSpec>();
            CreateMap<MVCoaSpec,MCoaSpec>();
            CreateMap<MCoaSpec,MVCoaSpecQuery>();
            CreateMap<MVCoaSpecQuery,MCoaSpec>();

            CreateMap<MCoaDoc,MVCoaDoc>();
            CreateMap<MVCoaDoc,MCoaDoc>();
            CreateMap<MCoaDoc,MVCoaDocQuery>();
            CreateMap<MVCoaDocQuery,MCoaDoc>();
        }
    }
}