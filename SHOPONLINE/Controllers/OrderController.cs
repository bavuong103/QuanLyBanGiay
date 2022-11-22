using Microsoft.AspNetCore.Mvc;
using SHOPONLINE.Models;
using SHOPONLINE.Models.ShopOnline;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThichLaMua.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        private readonly ShopOnlineModel dbc;
        List<Item> items = new List<Item>();
        int count = 0;
        double amount = 0.0;

        public OrderController(ShopOnlineModel db)
        {
            this.dbc = db;
            
        }

        public ActionResult Index()
        {
            ViewBag.Categories = dbc.Categories.ToList();
            return View();
        }

        public ActionResult Checkout()
        {
            var items = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            int count = 0;
            double amount = 0.0;

            if (items != null)
            {
                count = items.Sum(p => p.Quantity);
                amount = items.Sum(p => p.Product.UnitPrice * p.Quantity * (1 - p.Product.Discount));
            }

            var model = new Order();
            model.OrderDate = DateTime.Now;
            model.RequireDate = DateTime.Now.AddDays(5);
            if (items != null && items.Count > 0)
                model.Amount = amount;
            else model.Amount = 0;

            ViewBag.Categories = dbc.Categories.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Checkout(Order model)
        {
            var items = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (items!=null && items.Count > 0)
            {
                ViewBag.Categories = dbc.Categories.ToList();

                try
                {
                    if (model.Receiver == null || model.Receiver.ToString().Trim() == "")
                    {
                        ModelState.AddModelError("Receiver", "Họ tên không được để trống!");
                        return View();
                    }

                    if (model.Customer.Sdt == null || model.Customer.Sdt.ToString().Trim() == "")
                    {
                        ModelState.AddModelError("Customer.Sdt", "Số điện thoại không được để trống!");
                        return View();
                    }

                    if (model.Customer.Email == null || model.Customer.Email.ToString().Trim() == "")
                    {
                        ModelState.AddModelError("Customer.Email", "Địa chỉ email không được để trống");
                        return View();
                    }

                    if (model.Address == null || model.Address.ToString().Trim() == "")
                    {
                        ModelState.AddModelError("Address", "Địa chỉ giao hàng không được để trống");
                        return View();
                    }
                    // Tim trong database customer dua vao so dien thoai va password
                    var data = from p in dbc.Customers
                               where p.Sdt == model.Customer.Sdt && p.Email == model.Customer.Email
                               select p;
                    if (data != null && data.ToList().Count > 0)
                    {
                        model.Customer = data.ToList()[0];
                    }
                    else
                    {
                        Customer kh = new Customer();

                        var data_kh = from p in dbc.Customers
                                      where p.Id.StartsWith("KH_")
                                      select new
                                      {
                                          id = p.Id.Substring(3, p.Id.Length - 1)
                                      };


                        double index = 0;

                        if (data_kh != null && data_kh.ToList().Count > 0)
                        {
                            foreach (var p in data_kh.ToList())
                            {
                                if (Convert.ToDouble(p.id) > index)
                                    index = Convert.ToDouble(p.id);
                            }
                        }

                        kh.Id = "KH_" + (index + 1).ToString();

                        kh.Password = "";
                        kh.Fullname = model.Receiver;
                        kh.Email = model.Customer.Email;
                        kh.Photo = "User.jpg";
                        kh.Activated = true;
                        kh.Sdt = model.Customer.Sdt;
                        dbc.Customers.Add(kh); // insert customer

                        model.Customer = kh;
                    }

                    dbc.Orders.Add(model); // insert order
                    foreach (var p in items)
                    {
                        var detail = new OrderDetail
                        {
                            ProductId = p.Product.Id,
                            Order = model,
                            UnitPrice = p.Product.UnitPrice,
                            Quantity = p.Quantity,
                            Discount = p.Product.Discount
                        };
                        dbc.OrderDetails.Add(detail); // insert order detail
                    }

                    dbc.SaveChanges();

                    items.Clear();
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", items);

                    ModelState.AddModelError("", "Đặt hàng thành công !");
                    return View("OrderSuccess");

                }
                catch
                {
                    ViewBag.Categories = dbc.Categories.ToList();
                    ModelState.AddModelError("", "Đặt hàng thất bại !");

                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /*
        public ActionResult List()
        {
            var user = Session["User"] as Customer;
            var model = dbc.Orders
                .Where(o => o.CustomerId == user.Id)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
            return View(model);
        }*/
    }
}