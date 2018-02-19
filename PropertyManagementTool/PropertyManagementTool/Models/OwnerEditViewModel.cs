using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementTool.Models
{
    public class OwnerEditViewModel : OwnerViewModel
    {
        [Required]
        public new int Id { get; set; }
    }
}