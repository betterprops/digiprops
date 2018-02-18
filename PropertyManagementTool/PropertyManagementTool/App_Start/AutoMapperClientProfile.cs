using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManagementTool.App_Start
{
    public class AutoMapperClientProfile : Profile
    {
        public AutoMapperClientProfile()
        {
            CreateMap<Models.PropertyViewModel, Service.Models.PropertyModel>();
            CreateMap<Service.Models.PropertyModel, Models.PropertyEditViewModel>();
        }
    }
}