using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementTool.Service.Models
{
    public class TenantModel
    {
        public int TenantId { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
