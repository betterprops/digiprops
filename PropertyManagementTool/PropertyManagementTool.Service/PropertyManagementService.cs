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

        public PropertiesListModel GetProperties(int page = 1, int pageSize = 10)
        {
            var properties = this.Entities.Properties.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize).ToServiceModels().ToList();
            var propertyIndexModel = new PropertiesListModel
            {
                Properties = properties,
                Total = this.Entities.Properties.Count(),
                Page = page,
                PageSize = pageSize
            };

            return propertyIndexModel;
        }
    }
}
