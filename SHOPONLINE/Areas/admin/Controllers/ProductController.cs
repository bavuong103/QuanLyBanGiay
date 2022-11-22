using SHOPONLINE.Areas.Admin.Filters;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SHOPONLINE.Models.ShopOnline;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ThichLaMua.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        // ket noi voi database
        private readonly ShopOnlineModel dbc;
        public ProductController(ShopOnlineModel db)
        {
            this.dbc = db;
        }

        // hàm lưu data vào ViewBag để sử dụng cho phần View trang chủ của product
        public ActionResult Index()
        {
            var model = new Product();
            ViewBag.Items = dbc.Products.ToList();
            ViewBag.CategoryId = new SelectList(dbc.Categories, "Id", "NameVN");
            ViewBag.SupplierId = new SelectList(dbc.Suppliers, "Id", "Name");
            return View(model);
        }

        // hàm thêm product vào quản lý danh sách sản phẩm 
        public async Task<IActionResult> Insert(Product model)
        {
            var file = Request.Form.Files["upImage"];
            if (file != null && file.Length > 0)
            {
                model.Image = file.FileName;
                // file.SaveAs(Server.MapPath("~/Images/Products/" + file.FileName));

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products", file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            else
            {
                model.Image = "Product.png";
            }
            try
            {
                // Thêm sản phẩm vào danh sách sản phẩm
                dbc.Products.Add(model);
                // Lưu sản phẩm
                dbc.SaveChanges();
                ModelState.Clear();// xóa thông tin trên form
                ModelState.AddModelError("", "Thêm mới thành công");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.InnerException;
              
                ModelState.AddModelError("", "Thêm mới thất bại");
            }
            ViewBag.CategoryId = new SelectList(dbc.Categories, "Id", "NameVN");
            ViewBag.SupplierId = new SelectList(dbc.Suppliers, "Id", "Name");
            ViewBag.Items = dbc.Products.ToList();
            return View("Index");
        }

        // hàm cập nhật thông tin sản phẩm
        public async Task<IActionResult> Update(Product model)
        {
            var file = Request.Form.Files["upImage"];
            if (file != null && file.Length > 0)
            {
                model.Image = file.FileName;
                // file.SaveAs(Server.MapPath("~/Images/Products/" + file.FileName));
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products", file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            try
            {
                // dùng thư viện Microsoft.EntityFrameworkCore để cập nhật sản phẩm
                dbc.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbc.SaveChanges();
                ModelState.AddModelError("", "Cập nhật thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Cập nhật thất bại");
            }
            ViewBag.CategoryId = new SelectList(dbc.Categories, "Id", "NameVN", model.CategoryId);
            ViewBag.SupplierId = new SelectList(dbc.Suppliers, "Id", "Name", model.SupplierId);
            ViewBag.Items = dbc.Products.ToList();
            return View("Index");
        }

        public ActionResult Edit(int Id)
        {
            // tìm sản phẩm theo mã sản phẩm
            var model = dbc.Products.Find(Id);
            ViewBag.CategoryId = new SelectList(dbc.Categories, "Id", "NameVN", model.CategoryId);
            ViewBag.SupplierId = new SelectList(dbc.Suppliers, "Id", "Name", model.SupplierId);
            ViewBag.Items = dbc.Products.ToList();
            return View("Index", model);
        }

        // hàm xóa sản phẩm
        public ActionResult Delete(int Id)
        {
            ViewBag.CategoryId = new SelectList(dbc.Categories, "Id", "NameVN");
            ViewBag.SupplierId = new SelectList(dbc.Suppliers, "Id", "Name");
            var model = dbc.Products.Find(Id);
            try
            {
                // xóa sản phẩm
                dbc.Products.Remove(model);
                dbc.SaveChanges();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");
                // lưu dữ liệu sản phẩm hiện tại trong database vào ViewBag.Items
                ViewBag.Items = dbc.Products.ToList();
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                ViewBag.Items = dbc.Products.ToList();
                return View("Index", model);
            }
        }
    }
}