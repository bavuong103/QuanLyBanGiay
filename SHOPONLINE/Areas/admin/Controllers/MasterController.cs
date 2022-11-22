
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SHOPONLINE.Models.ShopOnline;
using System;
using System.Linq;

namespace SHOPONLINE.Areas.Admin.Controllers
{
    [Area("admin")]
    public class MasterController : Controller
    {
        private readonly ShopOnlineModel dbc;
        public MasterController(ShopOnlineModel db)
        {
            this.dbc = db;
        }

        public ActionResult Index()
        {
            var model = new Master();
            ViewBag.Items = dbc.Masters.ToList();
            return View(model);
        }

        public ActionResult Insert(Master model)
        {
            try
            {
                dbc.Masters.Add(model);
                dbc.SaveChanges();
                ModelState.Clear();// xóa thông tin trên form
                ModelState.AddModelError("", "Thêm mới thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới thất bại");
            }
            ViewBag.Items = dbc.Masters.ToList();
            return View("Index");
        }

        public ActionResult Update(Master model)
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
            ViewBag.Items = dbc.Masters.ToList();
            return View("Index");
        }

        public ActionResult Edit(String Id)
        {
            var model = dbc.Masters.Find(Id);
            ViewBag.Items = dbc.Masters.ToList();
            return View("Index", model);
        }

        public ActionResult Delete(String Id)
        {
            var model = dbc.Masters.Find(Id);
            try
            {
                dbc.Masters.Remove(model);
                dbc.SaveChanges();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");

                ViewBag.Items = dbc.Masters.ToList();
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                ViewBag.Items = dbc.Masters.ToList();
                return View("Index", model);
            }
        }
        //-------------------------//

        // hàm đăng nhập
        public ActionResult Login()
        {
            // Session.Remove("Master");
            return View();
        }

        // hàm đăng nhập
        [HttpPost]
        public ActionResult Login(String Id, String Password)
        {
            var master = dbc.Masters.Find(Id);

            if (master == null) //khoog tồn tại username
            {
                ModelState.AddModelError("", "Sai tên đăng nhập");
            }
            else if (master.Password != Password) // mật khẩu người dùng không giống trong database
            {
                ModelState.AddModelError("", "Sai mật khẩu");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập thành công");

                HttpContext.Session.SetString("Master", master.Id);
            }
           return View();
        }

        // hàm thay đổi mật khẩu mới
        public ActionResult Change()
        {
            return View();
        }

        // hàm thay đổi mật khẩu mới
        [HttpPost]
        public ActionResult Change(String Id, String Password, String Password1, String Password2)
        {
            var master = dbc.Masters.Find(Id);
            if (master == null)
            {
                ModelState.AddModelError("", "Sai tên đăng nhập");
            }
            else if (master.Password != Password)
            {
                ModelState.AddModelError("", "Sai mật khẩu");
            }
            else if (Password1 != Password2)
            {
                ModelState.AddModelError("", "Xác nhận sai mật khẩu mới");
            }
            else
            {
                ModelState.AddModelError("", "Đổi mật khẩu thành công");
                // tiến hành lưu mk mới vào database
                master.Password = Password2;
                dbc.SaveChanges();

                HttpContext.Session.SetString("Master", master.Id);
            }
            return View();
        }
    }
}