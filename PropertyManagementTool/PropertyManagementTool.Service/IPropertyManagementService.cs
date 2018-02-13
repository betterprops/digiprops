using PropertyManagementTool.DataAccess;
using PropertyManagementTool.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagementTool.Service
{
    public interface IPropertyManagementService
    {
        PropertiesListModel GetProperties(int page = 1, int pageSize = 10);
    }
}
