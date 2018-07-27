using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementTool.Service.Models
{
    public class LeaseTermModel
    {
        public int LeaseTermId { get; set; }

        public double Duration { get; set; }

        public decimal MonthlyRent { get; set; }

        public string Description { get; set; }

        public int PropertyId { get; set; }

        public bool IsActive { get; set; }

        public int TotalApplications { get; set; }

        public string PropertyLabel { get; set; }
    }

    public class LeaseTermModelExtended : LeaseTermModel
    {
        public virtual ICollection<LeaseApplicationModel> LeaseApplications { get; set; }
    }
}
