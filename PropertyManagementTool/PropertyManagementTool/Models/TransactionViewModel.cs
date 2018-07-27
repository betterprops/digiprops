using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementTool.Models
{
    public class TransactionViewModel
    {
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        
        [Required]
        [DisplayName("Date")]
        public System.DateTime DateCreated { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Category")]
        public string CategoryLabel { get; set; }

        [DisplayName("Property")]
        public int? PropertyId { get; set; }

        [DisplayName("Property")]
        public string PropertyAddress { get; set; }
    }
}