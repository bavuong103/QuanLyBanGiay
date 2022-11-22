
using Microsoft.AspNetCore.Mvc;
using SHOPONLINE.Models.ShopOnline;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThichLaMua.Areas.Admin.Controllers
{
    [Area("admin")]
    public class WebActionController : Controller
    {
        private readonly ShopOnlineModel dbc;
        public WebActionController(ShopOnlineModel db)
        {
            this.dbc = db;
        }

        public ActionResult Index()
        {
            var model = new WebAction();
            ViewBag.Items = dbc.WebActions.ToList();
            return View(model);
        }

        public ActionResult Insert(WebAction model)
        {
            try
            {
                dbc.WebActions.Add(model);
                dbc.SaveChanges();
                ModelState.Clear();// xóa thông tin trên form
                ModelState.AddModelError("", "Thêm mới thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới thất bại");
            }
            ViewBag.Items = dbc.WebActions.ToList();
            return View("Index");
        }

        public ActionResult Update(WebAction model)
        {
            try
            {
                dbc.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbc.SaveChanges();
                ModelState.AddModelError("", "Cập nhâtk thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Cập nhật thất bại");
            }
            ViewBag.Items = dbc.WebActions.ToList();
            return View("Index");
        }

        public ActionResult Edit(int Id)
        {
            var model = dbc.WebActions.Find(Id);
            ViewBag.Items = dbc.WebActions.ToList();
            return View("Index", model);
        }

        public ActionResult Delete(int Id)
        {
            var model = dbc.WebActions.Find(Id);
            try
            {
                dbc.WebActions.Remove(model);
                dbc.SaveChanges();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");

                ViewBag.Items = dbc.WebActions.ToList();
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                ViewBag.Items = dbc.WebActions.ToList();
                return View("Index", model);
            }
        }
    }
}