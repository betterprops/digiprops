using PropertyManagementTool.Models;
using PropertyManagementTool.Service;
using PropertyManagementTool.Service.Models;
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

        private void OnCreate()
        {
            var statusList = new SelectList(Service.GetPropertyStatusList(), "PropertyStatusId", "Status");
            ViewBag.PropertyStatusList = statusList; 
        }

        public ActionResult Create()
        {
            OnCreate();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyViewModel model)
        {
            if (ModelState.IsValid)
                return RedirectToAction("List");
            else
            {
                OnCreate();
                return View(model);
            }
        }
    }
}