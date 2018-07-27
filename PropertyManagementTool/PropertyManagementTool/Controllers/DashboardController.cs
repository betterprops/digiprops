using PropertyManagementTool.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyManagementTool.Service;
using PropertyManagementTool.Service.Models;

namespace PropertyManagementTool.Controllers
{
    [AccountRequired]
    public class DashboardController : Controller
    {
        private IPropertyManagementService Service { get; set; }

        public DashboardController()
        {
            this.Service = new PropertyManagementService();
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            var now = DateTime.Now;
            DateTime from = new DateTime(now.Year, 1, 1, 0, 0, 0);
            DateTime to = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month), 12, 59, 59);
            ViewBag.TransactionsChartData = Service.GetChartTransactionsByCategory(((OwnerModel)Session["SelectedAccount"]).Id, from, to);
            ViewBag.EarningsChartData =
                Service.GetChartEarningsByMonth(((OwnerModel) Session["SelectedAccount"]).Id, now.Year, 1, now.Month);
            return View();
        }
    }
}