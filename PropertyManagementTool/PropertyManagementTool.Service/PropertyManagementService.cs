using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyManagementTool.DataAccess;
using PropertyManagementTool.Service.Models;

namespace PropertyManagementTool.Service
{
    public class PropertyManagementService : IPropertyManagementService
    {
        private PropertyManagementDbEntities Entities { get; set; }

        public PropertyManagementService()
        {
            Entities = new PropertyManagementDbEntities();
        }

        public PropertiesListModel GetProperties(int ownerId, int page = 1, int pageSize = 10)
        {
            var properties = this.Entities.Properties.Where(p => p.OwnerId == ownerId).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList().ToServiceModels();
            var propertyIndexModel = new PropertiesListModel
            {
                Properties = properties.ToList(),
                Total = this.Entities.Properties.Count(),
                Page = page,
                PageSize = pageSize
            };

            return propertyIndexModel;
        }

        public LeasesListModel GetLeases(int ownerId, int page = 1, int pageSize = 10)
        {
            var leases = this.Entities.Leases.Where(p => p.Property.OwnerId == ownerId).OrderBy(p => p.LeaseStatusId).Skip((page - 1) * pageSize).Take(pageSize).ToList().ToServiceModel();
            var leaseIndexModel = new LeasesListModel
            {
                Leases = leases.ToList(),
                Total = this.Entities.Leases.Count(p => p.Property.OwnerId == ownerId),
                Page = page,
                PageSize = pageSize
            };

            return leaseIndexModel;
        }

        public TransactionsListModel GetTransactions(int ownerId, int page = 1, int pageSize = 10)
        {
            var transactions = this.Entities.Transactions.Where(p => p.PropertyOwnerId == ownerId).OrderByDescending(p => p.DateCreated).Skip((page - 1) * pageSize).Take(pageSize).ToList().ToServiceModel();
            var transactionIndexModel = new TransactionsListModel
            {
                Transactions = transactions,
                Total = this.Entities.Transactions.Count(p => p.PropertyOwnerId == ownerId),
                Page = page,
                PageSize = pageSize
            };
            return transactionIndexModel;
        }

        public IEnumerable<IdLabelPairModel> GetAllProperties(int ownerId)
        {
            return this.Entities.Properties.Where(p => p.OwnerId == ownerId).Select(p => new IdLabelPairModel {Id = p.Id, Label = p.Address}).ToList();
        }

        public IEnumerable<PropertyStatusModel> GetPropertyStatusList()
        {
            return this.Entities.PropertyStatus.ToServiceModels().ToList();
        }

        private string GetUserIdByUsername(string username)
        {
            return this.Entities.AspNetUsers.First(u => u.UserName == username).Id;
        }

        public IEnumerable<OwnerModel> GetOwnersByUser(string userId)
        {
            return this.Entities.Owners.Where(o => o.AspNetUser.UserName == userId).ToServiceModels().ToList();
        }

        public OwnerModel GetOwnerById(int id, string userId)
        {
            var owner = this.Entities.Owners.Find(id);
            if (owner.AspNetUser.UserName == userId)
                return owner.ToServiceModel();
            return null;
        }

        public IEnumerable<OwnerTypeModel> GetOwnerTypes()
        {
            return this.Entities.OwnerTypes.ToServiceModels();
        }

        public bool CreateOwner(OwnerModel owner, string userId)
        {
            var ownerDb = new Owner
            {
                Address = owner.Address,
                Name = owner.Name,
                TypeId = owner.TypeId,
                UserId = GetUserIdByUsername(userId)
            };

            this.Entities.Owners.Add(ownerDb);
            this.Entities.SaveChanges();

            return true;
        }

        public bool EditOwner(OwnerModel owner, string userId)
        {
            var ownerDb = this.Entities.Owners.Find(owner.Id);
            if(ownerDb != null && ownerDb.AspNetUser.UserName == userId)
            {
                ownerDb.Address = owner.Address;
                ownerDb.Name = owner.Name;
                ownerDb.TypeId = owner.TypeId;
                Entities.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<FeatureModel> GetFeatures()
        {
            return this.Entities.Features.ToServiceModels();
        }

        public bool CreateProperty(int ownerId, PropertyModel property, IEnumerable<int> features)
        {
            var propDb = new Property
            {
                Address = property.Address,
                Bathrooms = property.Bathrooms,
                Bedrooms = property.Bedrooms,
                Description = property.Description,
                OwnerId = ownerId,
                PropertyStatusId = property.PropertyStatusId,
                Size = property.Size
            };
            if (features.Any())
                propDb.Features = this.Entities.Features.Where(f => features.Contains(f.FeatureId)).ToList();

            this.Entities.Properties.Add(propDb);
            this.Entities.SaveChanges();

            return true;
        }

        public bool EditProperty(int ownerId, PropertyModel property, IEnumerable<int> features, string username)
        {
            var propDb = this.Entities.Properties.Find(property.Id);

            propDb.Address = property.Address;
            propDb.Bathrooms = property.Bathrooms;
            propDb.Bedrooms = property.Bedrooms;
            propDb.Description = property.Description;
            propDb.PropertyStatusId = property.PropertyStatusId;
            propDb.Size = property.Size;

            var currentFeatures = propDb.Features;

            var featuresToDelete = propDb.Features.Where(f => features == null || !features.Contains(f.FeatureId)).ToArray();

            var featuresToAdd = features?.Where(f => !currentFeatures.Select(c => c.FeatureId).Contains(f)) ?? new List<int>();
                        
            foreach(var d in featuresToDelete)
            {
                propDb.Features.Remove(d);
            }

            foreach(var a in featuresToAdd)
            {
                propDb.Features.Add(this.Entities.Features.Find(a));
            }

            if (propDb.PropertyStatusId != 1)
            {
                foreach (var lease in propDb.LeaseTerms)
                {
                    SetLeaseTermInactive(lease);
                }

                var app = propDb.LeaseApplications.First(a => a.LeaseApplicationStatusId == 2); // status is approved
                if (app != null)
                {
                    SetLeaseApplicationStatus(app.LeaseApplicationId, 4, ownerId, username);
                }
            }
            
            this.Entities.SaveChanges();
            return true;
        }

        private void SetLeaseTermInactive(LeaseTerm lease)
        {
            lease.IsActive = false;
            foreach (var application in lease.LeaseApplications)
            {
                if (application.LeaseApplicationStatusId == 1)
                    application.LeaseApplicationStatusId = 4;
            }
        }

        public PropertyModel GetPropertyById(int propId, int ownerId, string username)
        {
            var propDb = this.Entities.Properties.Find(propId);
            if (propDb.OwnerId == ownerId && propDb.Owner.AspNetUser.UserName == username)
                return propDb.ToServiceModel();
            return null;
        }

        public bool CreateLeaseTerm(int ownerId, LeaseTermModel term)
        {
            var prop = Entities.Properties.Find(term.PropertyId);
            if (prop != null && prop.OwnerId == ownerId)
            {
                var termDb = new LeaseTerm
                {
                    PropertyId = term.PropertyId,
                    Description = term.Description,
                    Duration = term.Duration,
                    MonthlyRent = term.MonthlyRent,
                    IsActive = term.IsActive
                };
                Entities.LeaseTerms.Add(termDb);
                Entities.SaveChanges();
                return true;
            }
            return false;
        }

        public LeaseTermModelExtended GetLeaseTermById(int termId, int ownerId, string username)
        {
            var termDb = this.Entities.LeaseTerms.Find(termId);
            if (termDb.Property.OwnerId == ownerId && termDb.Property.Owner.AspNetUser.UserName == username)
                return termDb.ToServiceModelExtended();
            return null;
        }

        public bool CreateLeaseApplication(TenantModel tenant, int leaseTermId, int ownerId, string username)
        {
            var termDb = this.Entities.LeaseTerms.Find(leaseTermId);
            if (termDb.Property.OwnerId == ownerId && termDb.Property.Owner.AspNetUser.UserName == username)
            {
                // TODO: Add ssn to tenant and search by that instead
                var tenantDb = Entities.Tenants.FirstOrDefault(t => t.DateOfBirth.Year == tenant.DateOfBirth.Year &&
                                                           t.DateOfBirth.Month == tenant.DateOfBirth.Month &&
                                                           t.DateOfBirth.Day == tenant.DateOfBirth.Day &&
                                                           t.Name.Equals(tenant.Name, StringComparison.OrdinalIgnoreCase));
                if (tenantDb == null)
                {
                    tenantDb = new Tenant
                    {
                        Name = tenant.Name,
                        DateOfBirth = tenant.DateOfBirth,
                    };
                }
                var applicationDb = new LeaseApplication
                {
                    Tenant = tenantDb,
                    PropertyId = termDb.PropertyId,
                    DateCreated = DateTime.Now,
                    LeaseApplicationStatusId = 1,
                    LeaseTermsId = termDb.LeaseTermId,
                };
                Entities.LeaseApplications.Add(applicationDb);
                Entities.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<LeaseTermModel> GetAllLeaseTermsByPropertyId(int propertyId, int ownerId, string username)
        {
            var result = new List<LeaseTermModelExtended>();
            var propertyDb = this.Entities.Properties.Find(propertyId);
            if (propertyDb.OwnerId == ownerId && propertyDb.Owner.AspNetUser.UserName == username)
            {
                return propertyDb.LeaseTerms.ToServiceModels();
            }
            return result;
        }

        public bool SetLeaseTermAsInactive(int termId, int ownerId, string username)
        {
            var termDb = Entities.LeaseTerms.Find(termId);
            if (termDb != null && termDb.Property.OwnerId == ownerId &&
                termDb.Property.Owner.AspNetUser.UserName == username)
            {
                SetLeaseTermInactive(termDb);
                Entities.SaveChanges();
                return true;
            }
            return false;
        }

        public LeaseApplicationModel GetLeaseApplicationById(int applicationId, int ownerId, string username)
        {
            var appDb = Entities.LeaseApplications.Find(applicationId);
            if (appDb != null && appDb.LeaseTerm.Property.OwnerId == ownerId &&
                appDb.LeaseTerm.Property.Owner.AspNetUser.UserName == username)
            {
                return appDb.ToServiceModel();
            }
            return null;
        }

        public bool SetLeaseApplicationStatus(int leaseApplicationId, int statusId, int ownerId, string username)
        {
            var appDb = this.Entities.LeaseApplications.Find(leaseApplicationId);
            if (appDb.Property.OwnerId == ownerId && appDb.Property.Owner.AspNetUser.UserName == username)
            {
                switch (statusId)
                {
                    case 2: // approved
                        if (this.Entities.LeaseApplications.Any(a =>
                            a.PropertyId == appDb.PropertyId && 
                            a.LeaseApplicationStatusId == 2 || // approved
                            appDb.Property.PropertyStatusId != 1)) // available
                        {
                            return false;
                        }

                        appDb.LeaseApplicationStatusId = 2;

                        var otherApplications = this.Entities.LeaseApplications.Where(a => a.PropertyId == appDb.PropertyId && a.LeaseApplicationStatusId == 1 && a.LeaseApplicationId != leaseApplicationId); // active applications
                        foreach (var app in otherApplications)
                        {
                            app.LeaseApplicationStatusId = 3; // rejected
                        }

                        break;
                    case 3: // reject
                    case 4: // archive
                        appDb.LeaseApplicationStatusId = statusId;
                        break;
                    default:
                        return false;
                }
                
                Entities.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<IdLabelPairModel> GetAvailableProperties(int ownerId)
        {
            return this.Entities.Properties.Where(p => p.OwnerId == ownerId && p.PropertyStatusId == 1).Select(p => new IdLabelPairModel { Id = p.Id, Label = p.Address});
        }

        public IEnumerable<LeaseStatus> GetAllLeaseStatus()
        {
            return this.Entities.LeaseStatus.ToServiceModels();
        }

        public bool CreateLease(LeaseModel lease, int ownerId, string username)
        {
            var property = this.Entities.Properties.Find(lease.PropertyId);
            if (property != null && property.OwnerId == ownerId && property.Owner.AspNetUser.UserName.Equals(username))
            {
                var leaseDb = new Lease
                {
                    PropertyId = lease.PropertyId,
                    InitialDeposit = lease.InitialDeposit,
                    LeaseStatusId = lease.LeaseStatusId,
                    Duration = lease.Duration,
                    EndDate = lease.EndDate,
                    InitialDepositDescription = lease.InitialDepositDescription,
                    MonthlyRent = lease.MonthlyRent,
                    StartDate = lease.StartDate,
                    TenantId = lease.TenantId
                };

                this.Entities.Leases.Add(leaseDb);
                property.PropertyStatusId = 2;
                foreach (var leaseApplication in property.LeaseApplications)
                {
                    leaseApplication.LeaseApplicationStatusId = 4; // Archived
                }
                this.Entities.SaveChanges();
                return true;
            }
            return false;
        }

        public LeaseModel GetLeaseById(int leaseId, int ownerId, string username)
        {
            var lease = this.Entities.Leases.Find(leaseId);
            if (lease != null && lease.Property.OwnerId == ownerId)
            {
                return lease.ToServiceModel();
            }

            return null;
        }

        public bool SetLeaseStatus(int leaseId, int statusId, int ownerId, string username)
        {
            var leaseDb = this.Entities.Leases.Find(leaseId);
            if (leaseDb?.Property.OwnerId == ownerId && leaseDb.Property.Owner.AspNetUser.UserName == username)
            {
                leaseDb.LeaseStatusId = statusId;
                Entities.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<IdLabelPairModel> GetIncomeExpenseCategories()
        {
            return this.Entities.ExpenseIncomeCategories.Select(c => new IdLabelPairModel { Id = c.CategoryId, Label = c.Label });
        }

        public bool CreateTransaction(TransactionModel transaction, int ownerId)
        {
            if (transaction.PropertyId.HasValue)
            {
                var prop = Entities.Properties.Find(transaction.PropertyId);
                if (prop == null || prop.OwnerId != ownerId)
                {
                    return false;
                }
            }

            Entities.Transactions.Add(new Transaction
            {
                Amount = transaction.Amount,
                PropertyId = transaction.PropertyId,
                CategoryId = transaction.CategoryId,
                DateCreated = transaction.DateCreated,
                PropertyOwnerId = ownerId,
            });
            Entities.SaveChanges();
            return true;
        }

        public string GetChartTransactionsByCategory(int ownerId, DateTime from, DateTime to)
        {
            var transactions = Entities.Transactions.Where(t =>
                t.PropertyOwnerId == ownerId && t.DateCreated >= from && t.DateCreated <= to).GroupBy(k => k.ExpenseIncomeCategory.Label, v => v.Amount);
            string result = "[[";
            foreach (var transaction in transactions)
            {
                result += "['" + transaction.Key + "'," + transaction.Sum(t => Math.Abs(t)) + "],";
            }

            if (result.EndsWith(","))
                result = result.Remove(result.Length - 1);

            result += "]]";
            return result;
        }

        public string GetChartEarningsByMonth(int ownerId, int year, int fromMonth, int toMonth)
        {
            var transactions = Entities.Transactions.Where(t =>
                t.PropertyOwnerId == ownerId && t.DateCreated.Year == year && t.DateCreated.Month >= fromMonth &&
                t.DateCreated.Month <= toMonth).GroupBy(k => k.DateCreated.Month, v => v.Amount);
            string result = "[[";
            foreach (var transaction in transactions)
            {
                result += "['" + transaction.Key + "'," + transaction.Sum(t => t) + "],";
            }

            if (result.EndsWith(","))
                result = result.Remove(result.Length - 1);

            result += "]]";
            return result;
        }

        public BillsListModel GetBills(int ownerId, int page = 1, int pageSize = 10)
        {
            var bills = this.Entities.Bills.Where(p => p.PropertyOwnerId == ownerId).OrderByDescending(p => p.DueDate).Skip((page - 1) * pageSize).Take(pageSize).ToList().ToServiceModel();
            var billIndexModel = new BillsListModel
            {
                Bills = bills,
                Total = this.Entities.Bills.Count(b => b.PropertyOwnerId == ownerId),
                Page = page,
                PageSize = pageSize
            };
            return billIndexModel;
        }
    }
}
