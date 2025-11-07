using ResortApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResortApp.Controllers
{
    public class ProductController : Controller
    {
        Product myProduct = new Product()
        {
            ProductId=1,
            Name = "Kayac",
            Description = "A boat for one person",
            Category="Watersport",
            Price=275M
        };
        

        // GET: Product
        public ActionResult Index()
        {

            return View(myProduct);
        }
        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }
        public ActionResult DemoExpresion()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;
            return View(myProduct);
        }
    }
}