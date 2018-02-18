using AutoMapper;
using PropertyManagementTool.DataAccess;
using PropertyManagementTool.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementTool.Service
{
    public class AutoMapperServiceProfile : Profile
    {
        public AutoMapperServiceProfile()
        {
            CreateMap<Property, PropertyModel>().AfterMap((s, d) =>
            {
                d.PropertyStatus = s.PropertyStatus.Status;
            });
            CreateMap<Owner, OwnerModel>().AfterMap((s, d) =>
            {
                d.Type = s.OwnerType.Type;
            });
            CreateMap<OwnerType, OwnerTypeModel>();
            CreateMap<Feature, FeatureModel>();
        }
    }
}
