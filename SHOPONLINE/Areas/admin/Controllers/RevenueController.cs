
using Microsoft.AspNetCore.Mvc;
using SHOPONLINE.Models.ShopOnline;
using System;
using System.Linq;

namespace SHOPONLINE.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RevenueController : Controller
    {
        private readonly ShopOnlineModel dbc;
        public RevenueController(ShopOnlineModel db)
        {
            this.dbc = db;
        }

        public ActionResult ByProduct()
        {
            var result = dbc.OrderDetails
                .GroupBy(p => p.Product)
                .Select(g => new Models.InventoryInfo
                {
                    Group = g.Key.Name,
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    Count = g.Sum(p => p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                });
            return View("Revenue", result);
        }

        public ActionResult ByCategory()
        {
            var result = dbc.OrderDetails
                .GroupBy(p => p.Product.Category)
                .Select(g => new Models.InventoryInfo
                {
                    Group = g.Key.NameVN,
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    Count = g.Sum(p => p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                });
            return View("Revenue", result);
        }

        public ActionResult BySupplier()
        {
            var result = dbc.OrderDetails
                .GroupBy(p => p.Product.Supplier)
                .Select(g => new Models.InventoryInfo
                {
                    Group = g.Key.Name,
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    Count = g.Sum(p => p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                });
            return View("Revenue", result);
        }

        public ActionResult ByCustomer()
        {
            var result = dbc.OrderDetails
                .GroupBy(p => p.Order.Customer)
                .Select(g => new Models.InventoryInfo
                {
                    Group = g.Key.Id,
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    Count = g.Sum(p => p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                });
            return View("Revenue", result);
        }

        public ActionResult ByYear()
        {
            var result = dbc.OrderDetails
                .GroupBy(p => p.Order.OrderDate.Year)
                .ToList()
                .Select(g => new Models.InventoryInfo
                {
                    Group = g.Key.ToString(),
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    Count = g.Sum(p => p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                });
            return View("Revenue", result);
        }

        public ActionResult ByMonth()
        {
            var result = dbc.OrderDetails
                .GroupBy(p => p.Order.OrderDate.Month)
                .ToList()
                .Select(g => new Models.InventoryInfo
                {
                    Group = g.Key.ToString(),
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    Count = g.Sum(p => p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                });
            return View("Revenue", result);
        }

        public ActionResult ByQuarter()
        {
            var result = dbc.OrderDetails
                .GroupBy(p => Math.Ceiling(1.0 * p.Order.OrderDate.Month/3))
                .ToList()
                .Select(g => new Models.InventoryInfo
                {
                    Group = g.Key.ToString(),
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    Count = g.Sum(p => p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                });
            return View("Revenue", result);
        }
    }
}