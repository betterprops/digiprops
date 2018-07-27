using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManagementTool.CustomAttributes;
using PropertyManagementTool.Models;
using PropertyManagementTool.Service;
using PropertyManagementTool.Service.Models;

namespace PropertyManagementTool.Controllers
{
    [AccountRequired]
    public class LeaseTermsController : Controller
    {
        private IPropertyManagementService Service { get; set; }

        public LeaseTermsController()
        {
            this.Service = new PropertyManagementService();
        }


        // GET: LeaseTerms
        public ActionResult Index()
        {
            return View();
        }

        public void OnCreate()
        {
            ViewBag.PropertiesList = new SelectList(Service.GetAllProperties(((OwnerModel) Session["SelectedAccount"]).Id), "Id", "Label");
        }

        public ActionResult Create(int pId = -1)
        {
            OnCreate();
            if (pId > 0)
                return View(new LeaseTermViewModel {PropertyId = pId});
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaseTermViewModel model, int pId = -1)
        {
            if (ModelState.IsValid)
            {
                if (pId > 0)
                    model.PropertyId = pId;
                LeaseTermModel serviceModel = new LeaseTermModel
                {
                    PropertyId = model.PropertyId,
                    Description = model.Description,
                    Duration = model.Duration,
                    MonthlyRent = model.MonthlyRent,
                    IsActive = true
                };
                var result = this.Service.CreateLeaseTerm((((OwnerModel)Session["SelectedAccount"]).Id), serviceModel);
                if (result)
                    return RedirectToAction("Details", "Properties", new {pId = model.PropertyId});
                ModelState.AddModelError("", "The lease term could not be created. Check if you have the right permissions to perfomr this action and if the selected property exists.");
            }
            OnCreate();
            return View(model);
        }

        public ActionResult Details(int tId)
        {
            var termDb = Service.GetLeaseTermById(tId, (((OwnerModel)Session["SelectedAccount"]).Id), User.Identity.Name);
            return View(termDb.ToViewModel());
        }

        public ActionResult History(int pId)
        {
            return View(Service.GetAllLeaseTermsByPropertyId(pId, (((OwnerModel)Session["SelectedAccount"]).Id), User.Identity.Name).ToViewModels());
        }

        public ActionResult SetAsInactive(int tId)
        {
            Service.SetLeaseTermAsInactive(tId, (((OwnerModel)Session["SelectedAccount"]).Id), User.Identity.Name);
            return RedirectToAction("Details", new {tId = tId});
        }
    }
}