using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManagementTool.Models
{
    public class LeaseCreateViewModel : LeaseViewModel
    {
        public int LeaseApplicationId { get; set; }
    }
}