using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SHOPONLINE.Models;
using SHOPONLINE.Models.ShopOnline;

namespace ThichLaMua.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        private readonly ShopOnlineModel dbc;

        public ShoppingCartController(ShopOnlineModel db)
        {
            this.dbc = db;
        }
        public ActionResult Add(int Id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = dbc.Products.Find(Id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(Id.ToString());
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = dbc.Products.Find(Id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            var response = new
            {
                Count = Count(),
                Amount = Amount().ToString("#,###.#0")
            };
            return Json(response);
        }

        public ActionResult AddWithQuantity(int Id, int qty)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = dbc.Products.Find(Id), Quantity = qty });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(Id.ToString());
                if (index != -1)
                {
                    cart[index].Quantity += qty;
                }
                else
                {
                    cart.Add(new Item { Product = dbc.Products.Find(Id), Quantity = qty });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            var response = new
            {
                Count = Count(),
                Amount = Amount().ToString("#,###.#0")
            };
            return Json(response);
        }

        public ActionResult Remove(int Id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(Id.ToString());
            if (index != -1)
                cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            var response = new
            {
                Count = Count(),
                Amount = string.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:n0}", Amount()) + " VNĐ"
            };
            return Json(response);
        }

        public ActionResult Update(int Id, int newQty)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(Id.ToString());

            if (index != -1)
            {
                // Exists
                cart[index].Quantity = newQty;
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            
            var response = new
            {
                Count = Count(),
                Amount = string.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:n0}", Amount()) + " VNĐ",
                ItemAmount = string.Format(System.Globalization.CultureInfo.GetCultureInfo("vi-VN"), "{0:n0}", getItemAmount(Id)) + " VNĐ"
            };
            return Json(response);
        }

        public ActionResult Index()
        {
            ViewBag.Categories = dbc.Categories.ToList();
            return View();
        }

        public ActionResult Clear()
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart != null)
                cart.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.ToString().Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        private int Count()
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                return cart.Sum(p => p.Quantity);
            }
            else return 0;
        }

        private double Amount()
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                double rs = cart.Sum(p => p.Product.UnitPrice * p.Quantity * (1 - p.Product.Discount));
                return rs;
            }
            else return 0;
        }

        public double getItemAmount(int Id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(Id.ToString());
            if (index != -1)
            {
                double rs = cart[index].Product.UnitPrice * cart[index].Quantity * (1 - cart[index].Product.Discount);
                return rs;
               
            }
            else return 0;
        }
    }
}