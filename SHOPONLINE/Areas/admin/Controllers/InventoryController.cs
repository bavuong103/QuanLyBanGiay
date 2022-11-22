using Microsoft.AspNetCore.Mvc;
using SHOPONLINE.Models.ShopOnline;
using System.Linq;

namespace SHOPONLINE.Areas.Admin.Controllers
{
    [Area("admin")]
    public class InventoryController : Controller
    {
        private readonly ShopOnlineModel dbc;
        public InventoryController(ShopOnlineModel db)
        {
            this.dbc = db;
        }

        // hàm tìm kiếm thông tin hàng tồn kho thuộc 1 thể loại sản phẩm 
        public ActionResult ByCategory()
        {
            var result = dbc.Products
                .GroupBy(p => p.Category)
                .Select(g => new Models.InventoryInfo
                {
                    // group là tìm tên thể loại cho sản phẩm tồn kho
                    Group = g.Key.NameVN,
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    Count = g.Sum(p => p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                });
            return View("Inventory", result);
        }

        public ActionResult BySupplier()
        {
            var result = dbc.Products
                .GroupBy(p => p.Supplier)
                .Select(g => new Models.InventoryInfo
                {
                    // group là tìm tên nhà sản xuất cho sản phẩm tồn kho
                    Group = g.Key.Name,
                    Value = g.Sum(p => p.UnitPrice * p.Quantity),
                    Count = g.Sum(p => p.Quantity),
                    MinPrice = g.Min(p => p.UnitPrice),
                    MaxPrice = g.Max(p => p.UnitPrice),
                    AvgPrice = g.Average(p => p.UnitPrice)
                });
            return View("Inventory", result);
        }
    }
}