using Microsoft.AspNetCore.Mvc;
using SHOPONLINE.Models.ShopOnline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace ThichLaMua.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopOnlineModel dbc;
        public ProductController(ShopOnlineModel db)
        {
            this.dbc = db;
        }
        public ActionResult Index()
        {
            return View();
        }

        // hàm xuất danh sách sản phẩm ra trang chủ theo thể loại của nó
        // int ID đầu vào là Id của category
        public ActionResult ListByCategory(int Id)
        {
            // Session["ShoppingUrl"] = "/Product/ListByCategory/" + Id;
            // int ID đầu vào là Id của category
            // tìm kiếm các sp thoải điều kiện với mã thể loại tham số đầu vào
            var model = dbc.Products
                .Where(p => p.CategoryId == Id)
                .ToList();
            ViewBag.Categories = dbc.Categories.ToList();
            ViewBag.CategoryName = dbc.Categories.Find(Id).NameVN;
            return View("ProductList", model);
        }

        //hàm xuất danh sách sp theo nhà cung cấp
        public ActionResult ListBySupplier(String Id)
        {
            // Session["ShoppingUrl"] = "/Product/ListByCategory/" + Id;
            var model = dbc.Products
                .Where(p => p.SupplierId == Id)
                .ToList();
            return View("ProductList", model);
        }

        // hàm xem chi tiết hản phẩm
        public ActionResult Detail(int Id)
        {
            // tìm kiếm sản phẩm dự vào ID của nó
            var model = dbc.Products.Find(Id);

            // Tăng số lần xem
            model.Views++;
            dbc.SaveChanges();

            // Ghi nhận hàng đã xem
            var cookie = Request.Cookies["Views"];
            if (cookie == null)
            {
                //cookie = new HttpCookie("Views");
            }

            //cookie.Values[Id.ToString()] = Id.ToString();
            //Response.Cookies.Add(cookie);

            //// Truy vấn hàng đã xem
            //var Ids = cookie.Values.AllKeys.Select(k => int.Parse(k)).ToList();
            //ViewBag.Views = dbc.Products.Where(p => Ids.Contains(p.Id));

            // Danh sách sản phẩm cùng loại
            ViewBag.Products = dbc.Products.Where(p => p.CategoryId == model.CategoryId);

            // Danh sách Categories -- Để hiển thị cuối footer
            ViewBag.Categories = dbc.Categories.ToList();

            return View("ProductDetail", model);
        }


        // hàm tìm kiếm sp 
        public ActionResult Search(String Keywords)
        {
            ViewBag.Categories = dbc.Categories.ToList();
            ViewBag.Keywords = Keywords.ToUpper();

            //var model = dbc.Products
            //    .Where(p => p.Name.Contains(Keywords)
            //        || p.Category.NameVN.Contains(Keywords)
            //        || p.Category.Name.Contains(Keywords)
            //        || ConvertToUnSign(p.Category.NameVN).Contains(ConvertToUnSign(Keywords))
            //        || ConvertToUnSign(p.Category.Name).Contains(ConvertToUnSign(Keywords))
            //        )
            //    .ToList();

            string Keywords_khongdau = ConvertToUnSign(Keywords);

            var model = dbc.Products.ToList().FindAll
                (
                      delegate(Product sp)
                      {
                          if (
                                  sp.Name.ToUpper().Contains(Keywords.ToUpper())
                                      || ConvertToUnSign(sp.Name).ToUpper().Contains(Keywords_khongdau.ToUpper())
                                      || sp.Category.NameVN.ToUpper().Contains(Keywords.ToUpper()) 
                                      || sp.Category.Name.ToUpper().Contains(Keywords.ToUpper()) 
                                      || ConvertToUnSign(sp.Category.NameVN).ToUpper().Contains(Keywords_khongdau.ToUpper()) 
                                      || ConvertToUnSign(sp.Category.Name).ToUpper().Contains(Keywords_khongdau.ToUpper())
                              )
                              return true;
                          else
                              return false;
                      }
                );

            return View("ProductSearch", model);
        }

        #region Phan xu ly chuyen tu chu co dau sang chu khong dau
        public static string ConvertToUnSign(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            //text = text.Replace(" ", "-"); //Comment lại để không đưa khoảng trắng thành ký tự -

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");

            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);

            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        #endregion
    }
}