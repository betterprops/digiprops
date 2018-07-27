using PropertyManagementTool.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementTool.Models
{
    public class LeaseTermViewModel
    {
        public int LeaseTermId { get; set; }

        [Required]
        [Display(Name = "Duration in months")]
        public double Duration { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "The value for monthly rent should be greater than or equal to 0")]
        [Display(Name = "Monthly Rent")]
        public decimal MonthlyRent { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Property")]
        public int PropertyId { get; set; }

        [Display(Name = "Property")]
        public string PropertyLabel { get; set; }

        public bool IsActive { get; set; }

        public int TotalApplications { get; set; }

        [Display(Name = "Applications")]
        public ICollection<LeaseApplicationModel> LeaseApplications { get; set; }
    }
}