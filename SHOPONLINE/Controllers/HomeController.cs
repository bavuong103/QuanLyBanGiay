using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SHOPONLINE.Models;
using SHOPONLINE.Models.ShopOnline;

namespace SHOPONLINE.Controllers
{
    public class HomeController : Controller
    {
        // kết nối database
        private readonly ShopOnlineModel db;

        public HomeController(ShopOnlineModel db)
        {
            this.db = db;
        }

        //hàm lưu các thông tin cần thiết vào ViewBag để trả dữ liệu về cho trang Index của Home
        public IActionResult Index()
        {
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Products = db.Products.ToList();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
