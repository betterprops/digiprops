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
    public static class Extensions
    {
        public static PropertyModel ToServiceModel(this Property property)
        {
            return Mapper.Map<Property, PropertyModel>(property);
        }

        public static IEnumerable<PropertyModel> ToServiceModels(this IEnumerable<Property> properties)
        {
            foreach (var prop in properties)
                yield return prop.ToServiceModel();
        }
    }
}
