using AutoMapper;
using PropertyManagementTool.Models;

namespace PropertyManagementTool.App_Start
{
    public class AutoMapperClientProfile : Profile
    {
        public AutoMapperClientProfile()
        {
            CreateMap<Models.PropertyViewModel, Service.Models.PropertyModel>();
            CreateMap<Service.Models.PropertyModel, Models.PropertyEditViewModel>();
            CreateMap<Service.Models.OwnerModel, Models.OwnerViewModel>();
            CreateMap<Service.Models.OwnerModel, Models.OwnerEditViewModel>();
            CreateMap<Service.Models.LeaseTermModelExtended, Models.LeaseTermViewModel>();
            CreateMap<Service.Models.LeaseTermModel, Models.LeaseTermViewModel>();
            CreateMap<Service.Models.LeaseModel, Models.LeaseViewModel>();
            CreateMap<LeaseCreateViewModel, Service.Models.LeaseModel>();
            CreateMap<TransactionViewModel, Service.Models.TransactionModel>();
        }
    }
}