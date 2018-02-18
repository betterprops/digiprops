using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementTool.Models
{
    public class PropertyEditViewModel : PropertyViewModelBase
    {
        [Required]
        public int Id { get; set; }
    }
}