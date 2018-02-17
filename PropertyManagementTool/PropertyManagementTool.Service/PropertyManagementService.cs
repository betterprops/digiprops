using System;
using System.Collections.Generic;
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
            var properties = this.Entities.Properties.Where(p => p.OwnerId == ownerId).OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize).ToServiceModels().ToList();
            var propertyIndexModel = new PropertiesListModel
            {
                Properties = properties,
                Total = this.Entities.Properties.Count(),
                Page = page,
                PageSize = pageSize
            };

            return propertyIndexModel;
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
    }
}
