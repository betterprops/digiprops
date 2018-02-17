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
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Property, PropertyModel>().AfterMap((s, d) =>
                {
                    d.PropertyStatus = s.PropertyStatus.Status;
                });
                cfg.CreateMap<Owner, OwnerModel>().AfterMap((s, d) =>
                {
                    d.Type = s.OwnerType.Type;
                });
                cfg.CreateMap<OwnerType, OwnerTypeModel>();
                
            });
        }
    }
}
