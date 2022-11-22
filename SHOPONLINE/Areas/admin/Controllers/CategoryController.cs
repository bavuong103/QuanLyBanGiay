using Microsoft.AspNetCore.Mvc;
using SHOPONLINE.Models.ShopOnline;
using System.Collections.Generic;
using System.Linq;

namespace SHOPONLINE.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly ShopOnlineModel dbc;
        public CategoryController(ShopOnlineModel db)
        {
            this.dbc = db;
        }

        public ActionResult Index()
        {
            var model = new Category();
            ViewBag.Items = dbc.Categories.ToList();
            return View(model);
        }

        public ActionResult Insert(Category model)
        {
            try
            {
                dbc.Categories.Add(model);
                dbc.SaveChanges();
                ModelState.Clear();// xóa thông tin trên form
                ModelState.AddModelError("", "Thêm mới thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới thất bại");
            }
            ViewBag.Items = dbc.Categories.ToList();
            return View("Index");
        }

        public ActionResult Update(Category model)
        {
            try
            {
                dbc.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbc.SaveChanges();
                ModelState.AddModelError("", "Cập nhật thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Cập nhật thất bại");
            }
            ViewBag.Items = dbc.Categories.ToList();
            return View("Index");
        }

        public ActionResult Edit(int Id)
        {
            var model = dbc.Categories.Find(Id);
            ViewBag.Items = dbc.Categories.ToList();
            return View("Index", model);
        }

        public ActionResult Delete(int Id)
        {
            var model = dbc.Categories.Find(Id);
            try
            {
                dbc.Categories.Remove(model);
                dbc.SaveChanges();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");

                ViewBag.Items = dbc.Categories.ToList();
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                ViewBag.Items = dbc.Categories.ToList();
                return View("Index", model);
            }
        }
    }
}