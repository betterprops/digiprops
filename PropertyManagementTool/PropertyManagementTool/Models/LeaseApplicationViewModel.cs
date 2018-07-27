using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementTool.Models
{
    public class LeaseApplicationViewModel
    {
        public int LeaseApplicationId { get; set; }

        public int TenantId { get; set; }

        public int LeaseTermsId { get; set; }

        public int PropertyId { get; set; }

        [Display(Name = "Created On")]
        public System.DateTime DateCreated { get; set; }

        public int LeaseApplicationStatusId { get; set; }

        [Display(Name = "Status")]
        public string LeaseApplicationStatusLabel { get; set; }

        [Display(Name = "Tenant")]
        public string TenantFullName { get; set; }

        [Display(Name = "Property")]
        public string PropertyAddress { get; set; }

        [Required]
        [Display(Name = "Duration In Months")]
        public double Duration { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value for monthly rent should be greater than or equal to 0")]
        [Display(Name = "Monthly Rent")]
        public decimal MonthlyRent { get; set; }

        public string Description { get; set; }
    }
}