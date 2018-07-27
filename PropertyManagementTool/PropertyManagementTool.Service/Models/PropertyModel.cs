using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementTool.Service.Models
{
    public class PropertyModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public Nullable<double> Size { get; set; }
        public Nullable<double> Bedrooms { get; set; }
        public Nullable<double> Bathrooms { get; set; }
        public string Description { get; set; }
        public Nullable<int> PropertyStatusId { get; set; }
        public string PropertyStatus { get; set; }
        public Nullable<int> ParentPropertyId { get; set; }

        public ICollection<FeatureModel> Features { get; set; }

        public IEnumerable<LeaseTermModel> LeaseTerms { get; set; }

        public IEnumerable<LeaseModel> Leases { get; set; }

        public int ActiveLeaseId { get; set; }
    }
}
