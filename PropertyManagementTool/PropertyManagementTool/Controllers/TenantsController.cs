using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManagementTool.Controllers
{
    public class TenantsController : Controller
    {
        // GET: Tenants
        public ActionResult Index()
        {
            return View();
        }
    }
}