using Microsoft.AspNetCore.Mvc;
using SHOPONLINE.Models.ShopOnline;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SHOPONLINE.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SupplierController : Controller
    {
        private readonly ShopOnlineModel dbc;
        public SupplierController(ShopOnlineModel db)
        {
            this.dbc = db;
        }

        public ActionResult Index()
        {
            var model = new Supplier();
            ViewBag.Items = dbc.Suppliers.ToList();
            return View(model);
        }

        public async Task<IActionResult> Insert(Supplier model)
        {
            var file = Request.Form.Files["upLogo"];
            if (file.Length > 0)
            {
                model.Logo = file.FileName;
                // file.SaveAs(Server.MapPath("~/Images/Suppliers/" + file.FileName));
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\suppliers", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            else
            {
                model.Logo = "Supplier.png";
            }
            try
            {
                dbc.Suppliers.Add(model);
                dbc.SaveChanges();
                ModelState.Clear();// xóa thông tin trên form
                ModelState.AddModelError("", "Thêm mới thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới thất bại");
            }
            ViewBag.Items = dbc.Suppliers.ToList();
            return View("Index");
        }

        public async Task<IActionResult> Update(Supplier model)
        {
            var file = Request.Form.Files["upLogo"];
            if (file.Length > 0)
            {
                model.Logo = file.FileName;
                // file.SaveAs(Microsoft.AspNetCore.Server.MapPath("~/Images/Suppliers/" + file.FileName));

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\suppliers", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
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
            ViewBag.Items = dbc.Suppliers.ToList();
            return View("Index");
        }

        public ActionResult Edit(String Id)
        {
            var model = dbc.Suppliers.Find(Id);
            ViewBag.Items = dbc.Suppliers.ToList();
            return View("Index", model);
        }

        public ActionResult Delete(String Id)
        {
            var model = dbc.Suppliers.Find(Id);
            try
            {
                dbc.Suppliers.Remove(model);
                dbc.SaveChanges();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");

                ViewBag.Items = dbc.Suppliers.ToList();
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                ViewBag.Items = dbc.Suppliers.ToList();
                return View("Index", model);
            }
        }
    }
}