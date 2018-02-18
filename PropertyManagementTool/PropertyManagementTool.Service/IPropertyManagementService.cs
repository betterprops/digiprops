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

        bool EditProperty(int ownerId, PropertyModel property, IEnumerable<int> features);

        IEnumerable<PropertyStatusModel> GetPropertyStatusList();

        IEnumerable<OwnerModel> GetOwnersByUser(string userId);

        OwnerModel GetOwnerById(int id, string userId);

        IEnumerable<OwnerTypeModel> GetOwnerTypes();

        bool CreateOwner(OwnerModel owner, string userId);

        IEnumerable<FeatureModel> GetFeatures();

        PropertyModel GetPropertyById(int propId, int ownerId, string username);
    }
}
