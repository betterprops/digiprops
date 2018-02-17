using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PropertyManagementTool.CustomAttributes
{
    public class AccountRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["SelectedAccount"] == null)
            {
                filterContext.Result = new RedirectResult("~/Accounts/SelectAccount");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}