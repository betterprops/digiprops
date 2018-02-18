using AutoMapper;
using PropertyManagementTool.Models;
using PropertyManagementTool.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManagementTool
{
    public static class Extensions
    {
        public static PropertyModel ToServiceModel(this PropertyViewModel model)
        {
            return Mapper.Map<PropertyViewModel, PropertyModel>(model);
        }

        public static PropertyEditViewModel ToEditViewModel(this PropertyModel model)
        {
            return Mapper.Map<PropertyModel, PropertyEditViewModel>(model);
        }
    }
}