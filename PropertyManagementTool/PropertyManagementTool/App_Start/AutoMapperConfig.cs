using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManagementTool.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(new[]
                {
                    typeof(Service.AutoMapperServiceProfile),
                    typeof(AutoMapperClientProfile)
                });
            });
        }
    }
}