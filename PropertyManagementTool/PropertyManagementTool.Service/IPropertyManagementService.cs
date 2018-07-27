using PropertyManagementTool.DataAccess;
using PropertyManagementTool.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementTool.Service
{
    public interface IPropertyManagementService
    {
        PropertiesListModel GetProperties(int ownerId, int page = 1, int pageSize = 10);

        bool CreateProperty(int ownerId, PropertyModel property, IEnumerable<int> features);

        bool EditProperty(int ownerId, PropertyModel property, IEnumerable<int> features, string username);

        IEnumerable<PropertyStatusModel> GetPropertyStatusList();

        IEnumerable<OwnerModel> GetOwnersByUser(string userId);

        OwnerModel GetOwnerById(int id, string userId);

        IEnumerable<OwnerTypeModel> GetOwnerTypes();

        bool CreateOwner(OwnerModel owner, string userId);

        bool EditOwner(OwnerModel owner, string userId);

        IEnumerable<FeatureModel> GetFeatures();

        PropertyModel GetPropertyById(int propId, int ownerId, string username);

        IEnumerable<IdLabelPairModel> GetAllProperties(int ownerId);

        bool CreateLeaseTerm(int ownerId, LeaseTermModel term);

        LeaseTermModelExtended GetLeaseTermById(int termId, int ownerId, string username);

        bool CreateLeaseApplication(TenantModel tenant, int leaseTermId, int ownerId, string username);

        IEnumerable<LeaseTermModel> GetAllLeaseTermsByPropertyId(int propertyId, int ownerId, string username);

        bool SetLeaseTermAsInactive(int termId, int ownerId, string username);

        LeaseApplicationModel GetLeaseApplicationById(int applicationId, int ownerId, string username);

        bool SetLeaseApplicationStatus(int leaseApplicationId, int statusId, int ownerId, string username);

        IEnumerable<IdLabelPairModel> GetAvailableProperties(int ownerId);

        IEnumerable<LeaseStatus> GetAllLeaseStatus();

        bool CreateLease(LeaseModel lease, int ownerId, string username);

        LeaseModel GetLeaseById(int leaseId, int ownerId, string username);

        bool SetLeaseStatus(int leaseId, int statusId, int ownerId, string username);

        LeasesListModel GetLeases(int ownerId, int page = 1, int pageSize = 10);

        TransactionsListModel GetTransactions(int ownerId, int page = 1, int pageSize = 10);

        IEnumerable<IdLabelPairModel> GetIncomeExpenseCategories();

        bool CreateTransaction(TransactionModel transaction, int ownerId);

        string GetChartTransactionsByCategory(int ownerId, DateTime from, DateTime to);

        string GetChartEarningsByMonth(int ownerId, int year, int fromMonth, int toMonth);

        BillsListModel GetBills(int ownerId, int page = 1, int pageSize = 10);
    }
}
