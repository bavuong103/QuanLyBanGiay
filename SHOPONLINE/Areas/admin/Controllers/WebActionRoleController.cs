
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SHOPONLINE.Models.ShopOnline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHOPONLINE.Areas.Admin.Controllers
{
    [Area("admin")]
    public class WebActionRoleController : Controller
    {
        private readonly ShopOnlineModel dbc;
        public WebActionRoleController(ShopOnlineModel db)
        {
            this.dbc = db;
        }

        public ActionResult Index()
        {
            ViewBag.RoleId = new SelectList(dbc.Roles.ToList(), "Id", "Name");
            ViewBag.WebActions = dbc.WebActions.ToList();
            return View();
        }

        public ActionResult GetActions(String RoleId)
        {
            var response = dbc.ActionRoles
                .Where(ar => ar.RoleId == RoleId)
                .Select(ar => ar.WebActionId).ToList();
            return Json(response);
        }

        public ActionResult Update(int ActionId, String RoleId, Boolean Status)
        {
            if (Status == true)
            {
                var ar = new ActionRole
                {
                    WebActionId = ActionId,
                    RoleId = RoleId
                };
                dbc.ActionRoles.Add(ar);
            }
            else
            {
                var arole = dbc.ActionRoles
                    .Single(ar => ar.WebActionId == ActionId && ar.RoleId == RoleId);
                dbc.ActionRoles.Remove(arole);
            }
            dbc.SaveChanges();
            return Json(null);
        }
    }
}