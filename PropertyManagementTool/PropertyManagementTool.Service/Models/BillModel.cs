using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementTool.Service.Models
{
    public class BillModel
    {
        public int BillId { get; set; }

        public decimal Amount { get; set; }

        public int PropertyOwnerId { get; set; }

        public int ResposiblePartyId { get; set; }

        public string ResponsiblePartyLabel { get; set; }

        public int? TaskId { get; set; }

        public int? PropertyId { get; set; }

        public string PropertyAddress { get; set; }

        public int? TenantId { get; set; }

        public string TenantFullName { get; set; }

        public System.DateTime DueDate { get; set; }

        public System.DateTime DateCreated { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string CategoryLabel { get; set; }

        public int BillStatusId { get; set; }

        public string BillStatusLabel { get; set; }
    }
}
