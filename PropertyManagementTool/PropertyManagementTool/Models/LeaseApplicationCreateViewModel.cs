using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementTool.Models
{
    public class LeaseApplicationCreateViewModel
    {
        [Required]
        [Display(Name = "Full Name")]
        public string TenantFullName { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        public DateTime? TenantDateOfBirth { get; set; }

        [Required]
        public int LeaseTermsId { get; set; }

        [Required]
        public int PropertyId { get; set; }

        [Display(Name = "Property")]
        public string PropertyAddress { get; set; }

        [Display(Name = "Lease Terms")]
        public string LeaseTerms { get; set; }
    }
}