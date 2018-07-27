using PropertyManagementTool.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManagementTool.CustomAttributes;
using PropertyManagementTool.Service.Models;

namespace PropertyManagementTool.Controllers
{
    [AccountRequired]
    public class BillsController : Controller
    {
        private IPropertyManagementService Service { get; set; }

        public BillsController()
        {
            this.Service = new PropertyManagementService();
        }

        // GET: Bills
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List(int page = 1, int pageSize = 10)
        {
            return View(Service.GetBills(((OwnerModel)Session["SelectedAccount"]).Id, page, pageSize));
        }
    }
}