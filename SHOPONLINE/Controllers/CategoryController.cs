using Microsoft.AspNetCore.Mvc;
using SHOPONLINE.Models.ShopOnline;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThichLaMua.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ShopOnlineModel dbc;
        public CategoryController(ShopOnlineModel db)
        {
            this.dbc = db;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Categories_Footer()
        {
            var model = dbc.Categories.ToList();
            return PartialView(model);
        }
	}
}