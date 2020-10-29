using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using HoaTuoi.Models.EF;
namespace HoaTuoi.Controllers
{
    public class LoginController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (TaiKhoan)Session["TaiKhoanSession"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "TaiKhoan", Action = "Login"}));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}