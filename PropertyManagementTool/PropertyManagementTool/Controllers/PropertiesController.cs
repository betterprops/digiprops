using PropertyManagementTool.CustomAttributes;
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
    [AccountRequired]
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
            return View(Service.GetProperties(((OwnerModel)Session["SelectedAccount"]).Id, page, pageSize));
        }

        private void OnCreate()
        {
            var statusList = new SelectList(Service.GetPropertyStatusList(), "PropertyStatusId", "Status");
            ViewBag.PropertyStatusList = statusList;

            var featureList = Service.GetFeatures();
            ViewBag.Features = featureList;
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
            {
                PropertyModel serviceModel = new PropertyModel
                {
                    Address = model.Address,
                    Bathrooms = model.Bathrooms,
                    Bedrooms = model.Bedrooms,
                    Description = model.Description,
                    PropertyStatusId = model.PropertyStatusId,
                    Size = model.Size
                };
                var features = new List<int>();
                if (model.SelectedFeatures != null && model.SelectedFeatures.Any())
                    features = model.SelectedFeatures.Select(f => Convert.ToInt32(f)).ToList();
                this.Service.CreateProperty((((OwnerModel)Session["SelectedAccount"]).Id), serviceModel, features);
                return RedirectToAction("List");
            }
            else
            {
                OnCreate();
                return View(model);
            }
        }

        public ActionResult Details(int pId)
        {
            var propDb = Service.GetPropertyById(pId, (((OwnerModel)Session["SelectedAccount"]).Id), User.Identity.Name);
            return View(propDb.ToEditViewModel());
        }

        public ActionResult Edit(int pId)
        {
            var propDb = Service.GetPropertyById(pId, (((OwnerModel)Session["SelectedAccount"]).Id), User.Identity.Name);
            OnCreate();
            return View(propDb.ToEditViewModel());
        }

        [HttpPost]
        public ActionResult Edit(PropertyEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                PropertyModel serviceModel = new PropertyModel
                {
                    Id = model.Id,
                    Address = model.Address,
                    Bathrooms = model.Bathrooms,
                    Bedrooms = model.Bedrooms,
                    Description = model.Description,
                    PropertyStatusId = model.PropertyStatusId,
                    Size = model.Size
                };
                var features = new List<int>();
                if (model.SelectedFeatures != null && model.SelectedFeatures.Any())
                    features = model.SelectedFeatures.Select(f => Convert.ToInt32(f)).ToList();
                this.Service.EditProperty((((OwnerModel)Session["SelectedAccount"]).Id), serviceModel, features, User.Identity.Name);
                return RedirectToAction("Details", new { pId = model.Id });
            }
            else
            {
                OnCreate();
                return View(model);
            }
        }
    }
}