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
    public class LeasesController : Controller
    {
        private IPropertyManagementService Service { get; set; }

        public LeasesController()
        {
            this.Service = new PropertyManagementService();
        }

        private void OnCreate()
        {
            var leaseStatusList = new SelectList(Service.GetAllLeaseStatus(), "LeaseStatusId", "Label");
            ViewBag.LeaseStatusList = leaseStatusList;
        }
        
        // GET: Leases
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List(int page = 1, int pageSize = 10)
        {
            return View(Service.GetLeases(((OwnerModel)Session["SelectedAccount"]).Id, page, pageSize));
        }

        public ActionResult Create(int aId)
        {
            var leaseApplication = Service.GetLeaseApplicationById(aId, ((OwnerModel)Session["SelectedAccount"]).Id, User.Identity.Name);
            var newLease = new LeaseCreateViewModel
            {
                PropertyId = leaseApplication.PropertyId,
                PropertyAddress = leaseApplication.PropertyAddress,
                LeaseApplicationId = aId,
                Duration = leaseApplication.Duration,
                MonthlyRent = leaseApplication.MonthlyRent,
                TenantFullName = leaseApplication.TenantFullName,
                StartDate = DateTime.Now.AddDays(15),
                EndDate = DateTime.Now.AddDays(3).AddMonths((int) leaseApplication.Duration),
                TenantId = leaseApplication.TenantId,
                LeaseStatusId = 2,
                LeaseStatus = "Active",
                InitialDeposit = 3 * leaseApplication.MonthlyRent,
                InitialDepositDescription = "Includes first month, last month and security deposit."
            };
            OnCreate();
            return View(newLease);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaseCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = Service.CreateLease(model.ToServiceModel(), ((OwnerModel)Session["SelectedAccount"]).Id, User.Identity.Name);
                if (result)
                {
                    return RedirectToAction("Details", "Properties", new { pId = model.PropertyId });
                }
                ModelState.AddModelError("", "Request could not be completed.");
            }
            OnCreate();
            return View(model);
        }

        public ActionResult Details(int lId)
        {
            var lease = Service.GetLeaseById(lId, ((OwnerModel) Session["SelectedAccount"]).Id, User.Identity.Name);
            OnCreate();
            return View(lease.ToViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(LeaseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = Service.SetLeaseStatus(model.LeaseId, model.LeaseStatusId, ((OwnerModel) Session["SelectedAccount"]).Id, User.Identity.Name);
                if (result)
                {
                    return RedirectToAction("Details", new {lId = model.LeaseId});
                }
                ModelState.AddModelError("", "Request could not be completed.");
            }

            OnCreate();
            return View(model);
        }
    }
}