using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementTool.Service.Models
{
    public class TransactionModel
    {
        public int TransactionId { get; set; }

        public decimal Amount { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int CategoryId { get; set; }

        public string CategoryLabel { get; set; }

        public Nullable<int> PropertyId { get; set; }

        public string PropertyAddress { get; set; }
    }
}
