using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementTool.Service.Models
{
    public class LeaseModel
    {
        public int LeaseId { get; set; }

        public int PropertyId { get; set; }

        public string PropertyAddress { get; set; }

        public int TenantId { get; set; }

        public string TenantFullName { get; set; }

        public double Duration { get; set; }

        public decimal InitialDeposit { get; set; }

        public string InitialDepositDescription { get; set; }

        public decimal MonthlyRent { get; set; }

        public System.DateTime StartDate { get; set; }

        public System.DateTime EndDate { get; set; }

        public int LeaseStatusId { get; set; }

        public string LeaseStatus { get; set; }
    }
}
