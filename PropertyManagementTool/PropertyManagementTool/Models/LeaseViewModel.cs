using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementTool.Models
{
    public class LeaseViewModel
    {
        public int LeaseId { get; set; }

        public int PropertyId { get; set; }

        [Display(Name = "Property")]
        public string PropertyAddress { get; set; }

        public int TenantId { get; set; }

        [Display(Name = "Tenant")]
        public string TenantFullName { get; set; }

        [Display(Name = "Duration (months)")]
        public double Duration { get; set; }

        [Display(Name = "Initial Deposit")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal InitialDeposit { get; set; }

        [Display(Name = "Initial Deposit Description")]
        public string InitialDepositDescription { get; set; }

        [Display(Name = "Monthly Rent")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MonthlyRent { get; set; }

        [Display(Name = "Start Date")]
        public System.DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public System.DateTime EndDate { get; set; }

        [Display(Name = "Status")]
        public int LeaseStatusId { get; set; }

        [Display(Name = "Status")]
        public string LeaseStatus { get; set; }
    }
}