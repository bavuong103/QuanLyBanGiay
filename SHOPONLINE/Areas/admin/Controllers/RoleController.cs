
using Microsoft.AspNetCore.Mvc;
using SHOPONLINE.Models.ShopOnline;
using System;
using System.Linq;

namespace SHOPONLINE.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoleController : Controller
    {
        private readonly ShopOnlineModel dbc;
        public RoleController(ShopOnlineModel db)
        {
            this.dbc = db;
        }

        public ActionResult Index()
        {
            var model = new Role();
            ViewBag.Items = dbc.Roles.ToList();
            return View(model);
        }

        public ActionResult Insert(Role model)
        {
            try
            {
                dbc.Roles.Add(model);
                dbc.SaveChanges();
                ModelState.Clear();// xóa thông tin trên form
                ModelState.AddModelError("", "Thêm mới thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới thất bại");
            }
            ViewBag.Items = dbc.Roles.ToList();
            return View("Index");
        }

        public ActionResult Update(Role model)
        {
            try
            {
                dbc.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbc.SaveChanges();
                ModelState.AddModelError("", "Cập nhât thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Cập nhật thất bại");
            }
            ViewBag.Items = dbc.Roles.ToList();
            return View("Index");
        }

        public ActionResult Edit(String Id)
        {
            var model = dbc.Roles.Find(Id);
            ViewBag.Items = dbc.Roles.ToList();
            return View("Index", model);
        }

        public ActionResult Delete(String Id)
        {
            var model = dbc.Roles.Find(Id);
            try
            {
                dbc.Roles.Remove(model);
                dbc.SaveChanges();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");

                ViewBag.Items = dbc.Roles.ToList();
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                ViewBag.Items = dbc.Roles.ToList();
                return View("Index", model);
            }
        }
    }
}