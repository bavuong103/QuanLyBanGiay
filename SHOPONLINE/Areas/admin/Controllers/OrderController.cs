
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SHOPONLINE.Models.ShopOnline;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SHOPONLINE.Areas.Admin.Controllers
{
    [Area("admin")]
    public class OrderController : Controller
    {
        private readonly ShopOnlineModel dbc;
        public OrderController(ShopOnlineModel db)
        {
            this.dbc = db;
        }

        public ActionResult Index()
        {
            var model = new Order();
            ViewBag.Items = dbc.Orders.ToList();
            ViewBag.CustomerId = new SelectList(dbc.Customers, "Id", "Fullname");
            return View(model);
        }

        public ActionResult Insert(Order model)
        {
            try
            {
                dbc.Orders.Add(model);
                dbc.SaveChanges();
                ModelState.Clear();// xóa thông tin trên form
                ModelState.AddModelError("", "Thêm mới thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới thất bại");
            }
            ViewBag.CustomerId = new SelectList(dbc.Customers, "Id", "Fullname", model.CustomerId);
            ViewBag.Items = dbc.Orders.ToList();
            return View("Index");
        }

        public ActionResult Update(Order model)
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
            ViewBag.CustomerId = new SelectList(dbc.Customers, "Id", "Fullname", model.CustomerId);
            ViewBag.Items = dbc.Orders.ToList();
            return View("Index");
        }

        public ActionResult Edit(int Id)
        {
            var model = dbc.Orders.Find(Id);
            ViewBag.CustomerId = new SelectList(dbc.Customers, "Id", "Fullname", model.CustomerId);
            ViewBag.Items = dbc.Orders.ToList();
            return View("Index", model);
        }

        public ActionResult Delete(int Id)
        {
            ViewBag.CustomerId = new SelectList(dbc.Customers, "Id", "Fullname");
            var model = dbc.Orders.Find(Id);
            try
            {
                dbc.Orders.Remove(model);
                dbc.SaveChanges();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");

                ViewBag.Items = dbc.Orders.ToList();
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                ViewBag.Items = dbc.Orders.ToList();
                return View("Index", model);
            }
        }
    }
}