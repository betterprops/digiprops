using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementTool.Service.Models
{
    public class LeaseApplicationModel
    {
        public int LeaseApplicationId { get; set; }

        public int TenantId { get; set; }

        public int LeaseTermsId { get; set; }

        public int PropertyId { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int LeaseApplicationStatusId { get; set; }

        public string LeaseApplicationStatusLabel { get; set; }

        public string TenantFullName { get; set; }

        public string PropertyAddress { get; set; }
        
        public double Duration { get; set; }

        public decimal MonthlyRent { get; set; }

        public string Description { get; set; }
    }
}
