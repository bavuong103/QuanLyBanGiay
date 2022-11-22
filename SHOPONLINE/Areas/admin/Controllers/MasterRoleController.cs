
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SHOPONLINE.Models.ShopOnline;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SHOPONLINE.Areas.Admin.Controllers
{
    [Area("admin")]
    public class MasterRoleController : Controller
    {
        private readonly ShopOnlineModel dbc;
        public MasterRoleController(ShopOnlineModel db)
        {
            this.dbc = db;
        }
        public ActionResult Index()
        {
            ViewBag.MasterId = new SelectList(dbc.Masters.ToList(), "Id", "FullName");
            ViewBag.Roles = dbc.Roles.ToList();
            return View();
        }

        public ActionResult GetRoles(String MasterId)
        {
            var RoleIds = dbc.MasterRoles
                .Where(mr => mr.MasterId == MasterId)
                .Select(mr => mr.RoleId).ToList();
            return Json(RoleIds);
        }

        public ActionResult Update(String MasterId, String RoleId, Boolean Status)
        {
            if (Status == true)
            {
                var mr = new MasterRole
                {
                    MasterId = MasterId,
                    RoleId=RoleId
                };
                dbc.MasterRoles.Add(mr);
            }
            else
            {
                var mrole = dbc.MasterRoles
                    .Single(mr => mr.MasterId == MasterId && mr.RoleId == RoleId);
                dbc.MasterRoles.Remove(mrole);
            }
            dbc.SaveChanges();
            return Json(null);
        }
    }
}