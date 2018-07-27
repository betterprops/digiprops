using System;
using PropertyManagementTool.CustomAttributes;
using System.Web.Mvc;
using PropertyManagementTool.Models;
using PropertyManagementTool.Service;
using PropertyManagementTool.Service.Models;

namespace PropertyManagementTool.Controllers
{
    [AccountRequired]
    public class TransactionsController : Controller
    {
        private IPropertyManagementService Service { get; set; }

        public TransactionsController()
        {
            this.Service = new PropertyManagementService();
        }

        // GET: Transactions
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List(int page = 1, int pageSize = 10)
        {
            return View(Service.GetTransactions(((OwnerModel)Session["SelectedAccount"]).Id, page, pageSize));
        }

        public void OnCreate()
        {
            ViewBag.PropertiesList = new SelectList(Service.GetAllProperties(((OwnerModel) Session["SelectedAccount"]).Id), "Id", "Label");
            ViewBag.CategoriesList = new SelectList(Service.GetIncomeExpenseCategories(), "Id", "Label");
        }

        public ActionResult Create(int pId = 0)
        {
            OnCreate();
            return View(new TransactionViewModel { PropertyId = pId, DateCreated = DateTime.Now });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = Service.CreateTransaction(model.ToServiceModel(), ((OwnerModel)Session["SelectedAccount"]).Id);
                if (result)
                {
                    return RedirectToAction("List");
                }
                ModelState.AddModelError("", "Request could not be completed");
            }
            OnCreate();
            return View(model);
        }
    }
}