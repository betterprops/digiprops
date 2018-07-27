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

        public static FeatureModel ToServiceModel(this Feature feature)
        {
            return Mapper.Map<Feature, FeatureModel>(feature);
        }

        public static IEnumerable<FeatureModel> ToServiceModels(this IEnumerable<Feature> features)
        {
            foreach (var prop in features)
                yield return prop.ToServiceModel();
        }

        public static LeaseTermModelExtended ToServiceModelExtended(this LeaseTerm leaseTerm)
        {
            return Mapper.Map<LeaseTerm, LeaseTermModelExtended>(leaseTerm);
        }

        public static LeaseTermModel ToServiceModel(this LeaseTerm term)
        {
            return Mapper.Map<LeaseTerm, LeaseTermModel>(term);
        }

        public static IEnumerable<LeaseTermModel> ToServiceModels(this IEnumerable<LeaseTerm> terms)
        {
            foreach (var term in terms)
                yield return term.ToServiceModel();
        }

        public static LeaseApplicationModel ToServiceModel(this LeaseApplication app)
        {
            return Mapper.Map<LeaseApplication, LeaseApplicationModel>(app);
        }

        public static LeaseModel ToServiceModel(this Lease lease)
        {
            return Mapper.Map<Lease, LeaseModel>(lease);
        }

        public static IEnumerable<LeaseModel> ToServiceModel(this IEnumerable<Lease> leases)
        {
            foreach (var lease in leases)
            {
                yield return lease.ToServiceModel();
            }
        }

        public static LeaseStatus ToServiceModel(this LeaseStatu model)
        {
            return Mapper.Map<LeaseStatu, LeaseStatus>(model);
        }

        public static IEnumerable<LeaseStatus> ToServiceModels(this IEnumerable<LeaseStatu> models)
        {
            foreach (var m in models)
            {
                yield return m.ToServiceModel();
            }
        }

        public static TransactionModel ToServiceModel(this Transaction transaction)
        {
            return Mapper.Map<Transaction, TransactionModel>(transaction);
        }

        public static IEnumerable<TransactionModel> ToServiceModel(this IEnumerable<Transaction> transactions)
        {
            foreach (var t in transactions)
            {
                yield return t.ToServiceModel();
            }
        }

        public static BillModel ToServiceModel(this Bill bill)
        {
            return Mapper.Map<Bill, BillModel>(bill);
        }

        public static IEnumerable<BillModel> ToServiceModel(this IEnumerable<Bill> bills)
        {
            foreach (var t in bills)
            {
                yield return t.ToServiceModel();
            }
        }
    }
}
