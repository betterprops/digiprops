using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementTool.Models
{
    public class OwnerViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name="Type")]
        public int TypeId { get; set; }

        public string Type { get; set; }
        
        public string Address { get; set; }
    }
}