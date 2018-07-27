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
    public class LeaseApplicationsController : Controller
    {
        private IPropertyManagementService Service { get; set; }

        public LeaseApplicationsController()
        {
            Service = new PropertyManagementService();
        }

        public ActionResult Create(int tId)
        {
            var term = Service.GetLeaseTermById(tId, ((OwnerModel) Session["SelectedAccount"]).Id, User.Identity.Name);
            if (term == null)
                return RedirectToAction("Details", "LeaseTerms", new {tId = tId});
            var model = new LeaseApplicationCreateViewModel
            {
                PropertyId = term.PropertyId,
                LeaseTerms = $"{term.MonthlyRent:C2} per month for {term.Duration} months",
                LeaseTermsId = term.LeaseTermId,
                PropertyAddress = term.PropertyLabel,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaseApplicationCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tenant = new TenantModel
                {
                    Name = model.TenantFullName,
                    DateOfBirth = model.TenantDateOfBirth.Value
                };
                var result = Service.CreateLeaseApplication(tenant, model.LeaseTermsId, ((OwnerModel)Session["SelectedAccount"]).Id, User.Identity.Name);
                if(result)
                    return RedirectToAction("Details", "LeaseTerms", new {tId = model.LeaseTermsId});
                else
                {
                    ModelState.AddModelError("", "Error creating application.");
                }
            }
            return View(model);
        }

        public ActionResult Details(int aId)
        {
            var app = Service.GetLeaseApplicationById(aId, ((OwnerModel) Session["SelectedAccount"]).Id,
                User.Identity.Name);
            return View(app.ToViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(LeaseApplicationViewModel model, string command)
        {
            if (ModelState.IsValid)
            {
                var result = false;
                switch (command)
                {
                    case "Approve":
                        result = this.Service.SetLeaseApplicationStatus(model.LeaseApplicationId, 2,
                            ((OwnerModel) Session["SelectedAccount"]).Id, User.Identity.Name);
                        break;
                    case "Reject":
                        result = this.Service.SetLeaseApplicationStatus(model.LeaseApplicationId, 3,
                            ((OwnerModel) Session["SelectedAccount"]).Id, User.Identity.Name);
                        break;
                    case "Archive":
                        result = this.Service.SetLeaseApplicationStatus(model.LeaseApplicationId, 4,
                            ((OwnerModel) Session["SelectedAccount"]).Id, User.Identity.Name);
                        break;
                }

                if (!result)
                {
                    ModelState.AddModelError("", "The action you requested could not be completed.");
                    return View(model);
                }

                return RedirectToAction("Details", "LeaseTerms", new { tId = model.LeaseTermsId });
            }

            return View(model);
        }
    }
}