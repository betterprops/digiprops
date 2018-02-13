using PropertyManagementTool.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManagementTool.Controllers
{
    public class PropertiesController : Controller
    {
        private IPropertyManagementService Service { get; set; }
            
        public PropertiesController()
        {
            this.Service = new PropertyManagementService();
        }

        // GET: Properties
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List(int page = 1, int pageSize = 10)
        {
            return View(Service.GetProperties(page, pageSize));
        }
    }
}