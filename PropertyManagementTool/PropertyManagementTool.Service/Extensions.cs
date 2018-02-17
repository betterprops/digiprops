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

        public static PropertyStatusModel ToServiceModel(this PropertyStatu status)
        {
            return Mapper.Map<PropertyStatu, PropertyStatusModel>(status);
        }

        public static IEnumerable<PropertyStatusModel> ToServiceModels(this IEnumerable<PropertyStatu> statusList)
        {
            foreach (var s in statusList)
                yield return s.ToServiceModel();
        }

        public static OwnerModel ToServiceModel(this Owner owner)
        {
            return Mapper.Map<Owner, OwnerModel>(owner);
        }

        public static IEnumerable<OwnerModel> ToServiceModels(this IEnumerable<Owner> owners)
        {
            foreach (var s in owners)
                yield return s.ToServiceModel();
        }


        public static OwnerTypeModel ToServiceModel(this OwnerType ownerType)
        {
            return Mapper.Map<OwnerType, OwnerTypeModel>(ownerType);
        }

        public static IEnumerable<OwnerTypeModel> ToServiceModels(this IEnumerable<OwnerType> ownerTypes)
        {
            foreach (var s in ownerTypes)
                yield return s.ToServiceModel();
        }
    }
}
