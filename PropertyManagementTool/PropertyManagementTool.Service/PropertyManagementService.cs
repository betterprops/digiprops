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

        public bool EditProperty(int ownerId, PropertyModel property, IEnumerable<int> features)
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

            var featuresToAdd = features != null ? features.Where(f => !currentFeatures.Select(c => c.FeatureId).Contains(f)) : new List<int>();
                        
            foreach(var d in featuresToDelete)
            {
                propDb.Features.Remove(d);
            }

            foreach(var a in featuresToAdd)
            {
                propDb.Features.Add(this.Entities.Features.Find(a));
            }
            
            this.Entities.SaveChanges();
            return true;
        }

        public PropertyModel GetPropertyById(int propId, int ownerId, string username)
        {
            var propDb = this.Entities.Properties.Find(propId);
            if (propDb.OwnerId == ownerId && propDb.Owner.AspNetUser.UserName == username)
                return propDb.ToServiceModel();
            return null;
        }
    }
}
