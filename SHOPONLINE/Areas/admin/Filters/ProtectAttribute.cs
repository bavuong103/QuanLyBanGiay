
using Microsoft.AspNetCore.Mvc.Filters;
using SHOPONLINE.Models.ShopOnline;
using System;
using System.Linq;

namespace SHOPONLINE.Areas.Admin.Filters
{
    public class ProtectAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            /*
            var master = HttpContext.Current.Session["Master"] as Master;
            if (master == null)
            {
                HttpContext.Current.Session["Message"] = "Vui lòng đăng nhập";
                HttpContext.Current.Response.Redirect("/Admin/Master/Login");
                return;
            }

            var ActionName = (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "/" + filterContext.ActionDescriptor.ActionName).ToLower();

            ShopOnlineModel dbc = new ShopOnlineModel();
            var count = dbc.WebActions
                .Where(w => w.Name == ActionName).Count();
            if (count == 0)
            {
                return;
            }

            var RoleIds = master.MasterRoles
                .Select(mr => mr.RoleId)
                .ToList();

            count = dbc.ActionRoles
                .Where(ar => ar.WebAction.Name == ActionName
                    && RoleIds.Contains(ar.RoleId)).Count();
            if (count > 0)
            {
                return;
            }

            HttpContext.Current.Session["Message"] = "Không có quyền truy cập";
            HttpContext.Current.Response.Redirect("/Admin/Master/Login");
            */
        }
    }
}