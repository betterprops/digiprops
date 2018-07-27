using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementTool.Service.Models
{
    public class LeasesListModel
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

        public IEnumerable<LeaseModel> Leases { get; set; }

        /// <summary>
        /// Used to search by number of bedrooms
        /// </summary>
        public int? PropertyId { get; set; }
    }
}
