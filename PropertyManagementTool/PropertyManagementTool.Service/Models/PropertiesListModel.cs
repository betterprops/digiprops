using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementTool.Service.Models
{
    public class PropertiesListModel
    {
        /// <summary>
        /// Page
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total records in db
        /// </summary>
        public int Total { get; set; }

        public IEnumerable<PropertyModel> Properties { get; set; }

        /// <summary>
        /// Used to search by number of bedrooms
        /// </summary>
        public int? Bedrooms { get; set; }

        /// <summary>
        /// Used to search by number of bathrooms
        /// </summary>
        public int? Bathrooms { get; set; }

        /// <summary>
        /// Used to search by Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Used to search features (i.e. pool, central ac, etc)
        /// </summary>
        public string Keywords { get; set; }
    }
}
