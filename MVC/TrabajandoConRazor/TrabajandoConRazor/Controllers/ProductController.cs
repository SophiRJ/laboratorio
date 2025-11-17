using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrabajandoConRazor.Models;
using TrabajandoConRazor.ViewModels;

namespace TrabajandoConRazor.Controllers
{
    public class ProductController : Controller
    {
        private List<Product> products = new List<Product>
{
        new Product { Id = 1, Name = "Laptop", Price = 999.99m, CategoryId= 1 },
        new Product { Id = 2, Name = "Smartphone", Price = 499.99m, CategoryId= 2 },
        new Product { Id = 3, Name = "Tablet", Price = 299.99m, CategoryId= 1 },
        new Product { Id = 4, Name = "Monitor", Price = 199.99m, CategoryId= 2 }
};

        private List<Category> categories = new List<Category>
{
        new Category { Id = 1, Name = "Electronics" },
        new Category { Id = 2, Name = "Mobile" }
};


        // GET: Product
        public ActionResult Index()
        {
            //var vm = products.Select(p => new ProductoPorCategoriaViewModel
            //{
            //    ProductId = p.Id,
            //    ProductName = p.Name,
            //    CategoryName = categories.FirstOrDefault(c => c.Id == p.CategoryId).Name,
            //    FormattedPrice = p.Price.ToString("C")
            //}).ToList();

            string[] products = { "laptop", "smartphone", "tablet", "monitor", "mouse" };

            //filtrar el array para eliminar tablet
            var filterProduct = products.Where(p => p != "tablet").ToArray();

            //Convertir todos los productos  mayusculas
            var productsInUpperCase = filterProduct.Select(p => p.ToUpper()).ToArray();

            //productos con posiciones pares
            var productsEvenPositions = productsInUpperCase.Where((product, index) => index % 2 == 0).ToArray();

            var vm = new ProductViewModel
            {
                AllProducts = productsInUpperCase,
                ProductsAtEvenPosition = productsEvenPositions,
            };
            return View(vm);
        }
    }
}