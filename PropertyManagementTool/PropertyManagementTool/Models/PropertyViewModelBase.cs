﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementTool.Models
{
    public abstract class PropertyViewModelBase
    {
        [Required]
        public string Address { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public Nullable<double> Size { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public Nullable<double> Bedrooms { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public Nullable<double> Bathrooms { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Status")]
        public Nullable<int> PropertyStatusId { get; set; }

        public string PropertyStatus { get; set; }

        public Nullable<int> ParentPropertyId { get; set; }

        [Display(Name = "Features")]
        public ICollection<string> SelectedFeatures { get; set; }

        public ICollection<Service.Models.FeatureModel> Features { get; set; }

        public IEnumerable<Service.Models.LeaseTermModel> LeaseTerms { get; set; }

        public int ActiveLeaseId { get; set; }
    }
}