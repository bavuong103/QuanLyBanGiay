using SHOPONLINE.Models;
using System;
using System.Linq;
using SHOPONLINE.Models.ShopOnline;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace SHOPONLINE.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CustomerController : Controller
    {
        private readonly ShopOnlineModel dbc;
        public CustomerController(ShopOnlineModel db)
        {
            this.dbc = db;
        }

        public ActionResult Index()
        {
            var model = new Customer();
            //ViewBag.Items = dbc.Customers.ToList();
            return View(model);
        }

        public async Task<IActionResult> Insert(Customer model)
        {
            var file = Request.Form.Files["upPhoto"];
            if (file.Length > 0)
            {
                model.Photo = file.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\customers", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                // file.SaveAs(MapPath("~/Images/Customers/" + file.FileName));
            }
            else
            {
                model.Photo = "Customer.png";
            }
            try
            {
                dbc.Customers.Add(model);
                dbc.SaveChanges();
                ModelState.Clear();// xóa thông tin trên form
                ModelState.AddModelError("", "Thêm mới thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới thất bại");
            }
            //ViewBag.Items = dbc.Customers.ToList();
            return View("Index");
        }

        public async Task<IActionResult> Update(Customer model)
        {
            var file = Request.Form.Files["upPhoto"];
            if (file.Length > 0)
            {
                model.Photo = file.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\customers", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                // file.SaveAs(Server.MapPath("~/Images/Customers/" + file.FileName));
            }
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
            //ViewBag.Items = dbc.Customers.ToList();
            return View("Index");
        }

        public ActionResult Edit(String Id)
        {
            var model = dbc.Customers.Find(Id);
            //ViewBag.Items = dbc.Customers.ToList();
            return View("Index", model);
        }

        public ActionResult Delete(String Id)
        {
            var model = dbc.Customers.Find(Id);
            try
            {
                dbc.Customers.Remove(model);
                dbc.SaveChanges();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");

                //ViewBag.Items = dbc.Customers.ToList();
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                //ViewBag.Items = dbc.Customers.ToList();
                return View("Index", model);
            }
        }

        //----------------------//
        public ActionResult GetList(int PageNo=0, int PageSize=10)
        {
            ViewBag.Items = dbc.Customers
                .OrderBy(c => c.Id)
                .Skip(PageNo * PageSize)
                .Take(PageSize)
                .ToList();
            return PartialView("_List");
        }

        public ActionResult GetPageCount(int PageSize = 10)
        {
            var pageCount = Math.Ceiling(1.0*dbc.Customers.Count() / PageSize);
            return Json(pageCount);
        }
    }
}