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
                d.LeaseTerms = s.PropertyStatusId == 1 ? d.LeaseTerms.Where(t => t.IsActive) : new List<LeaseTermModel>();

                if (s.PropertyStatusId == 2)
                {
                    d.ActiveLeaseId = d.Leases.FirstOrDefault(l => l.LeaseStatusId == 2)?.LeaseId ?? 0;
                }
            });
            CreateMap<Owner, OwnerModel>().AfterMap((s, d) =>
            {
                d.Type = s.OwnerType.Type;
            });
            CreateMap<OwnerType, OwnerTypeModel>();
            CreateMap<Feature, FeatureModel>();
            CreateMap<LeaseTerm, LeaseTermModel>().AfterMap((s, d) =>
            {
                d.TotalApplications = s.LeaseApplications?.Count ?? 0;
            });
            CreateMap<LeaseTerm, LeaseTermModelExtended>().AfterMap((s, d) =>
            {
                d.PropertyLabel = s.Property.Address;
            });
            CreateMap<LeaseApplication, LeaseApplicationModel>().AfterMap((s, d) =>
            {
                d.LeaseApplicationStatusLabel = s.LeaseApplicationStatu.Label;
                d.TenantFullName = s.Tenant.Name;
                d.PropertyAddress = s.Property.Address;
                d.Duration = s.LeaseTerm.Duration;
                d.Description = s.LeaseTerm.Description;
                d.MonthlyRent = s.LeaseTerm.MonthlyRent;
            });
            CreateMap<Lease, LeaseModel>().AfterMap((s, d) =>
            {
                d.TenantFullName = s.Tenant.Name;
                d.PropertyAddress = s.Property.Address;
                d.LeaseStatus = s.LeaseStatu.Label;
            });
            CreateMap<LeaseStatu, LeaseStatus>();
            CreateMap<Transaction, TransactionModel>().AfterMap((s, d) =>
            {
                if (d.PropertyId.HasValue)
                {
                    d.PropertyAddress = s.Property.Address;
                }

                d.CategoryLabel = s.ExpenseIncomeCategory.Label;
            });
            CreateMap<Bill, BillModel>().AfterMap((s, d) =>
            {
                if (d.PropertyId.HasValue)
                    d.PropertyAddress = s.Property.Address;
                d.CategoryLabel = s.ExpenseIncomeCategory.Label;
                if (d.TenantId.HasValue)
                    d.TenantFullName = s.Tenant.Name;
                d.BillStatusLabel = s.BillStatu.Label;
                d.ResponsiblePartyLabel = s.ResposibleParty.ResponsibleParty;
            });
        }
    }
}
