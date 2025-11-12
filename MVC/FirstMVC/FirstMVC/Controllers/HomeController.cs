using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace FirstMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Voy a navegar a una URL para probar";
        }
        public ViewResult AutoProperty()
        {
            Product product = new Product();
            product.Name = "Kayac";
            //aqui especificamos donde tiene que ir por que no es la suya
            return View("Index", (object)string.Format($"Product Name {product.Name}"));
        }
        public ViewResult CreateProduct()
        {
            Product product = new Product();
            product.ProductId = 1;
            product.Name = "Kayac";
            product.Description = "Aboat for one person";
            product.Price = 275M;
            product.Category = "Waterports";
            return View("Index", (object)string.Format("Product Description: {0}", product.Description));
        }
        public ViewResult CreateCollection() {
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intList = new List<int> { 10, 20, 30, 40 };
            Dictionary<string, int> myDict = new Dictionary<string, int> {
            { "apple",10},{"orange",20 },{ "plum",30}};
            //return View("Index", (object)stringArray[1]);//lo recoge bien por que es un string
            return View("Index", (object)myDict["apple"]);//aqui falla por que le estamos mandando un int 

        }
        public ViewResult CreateList()
        {
            //tipo anonimo -> segun los datos que le pasemos adquiere el tipo
            //esto se llama encapsular un tipo anonimo
            //var v = new { Name="Kayac green",Price=234.24M,Category="Watersports"};

            Product[] productArray =
            {
                new Product{Name="Kayac",Price=275M,Category="Watersports" },
                new Product{Name="Lifejacket",Price=48.5M,Category="Watersports" },
                new Product{Name = "Soccer Ball", Price = 19.50M, Category = "Soccer" },
                new Product{Name= "Corner Flag", Price= 34.95M, Category= "Soccer" }
            };

            decimal total = 0;
            foreach (Product product in productArray.
                Where(prod=>prod.Category=="Soccer" && prod.Price>20)) { 
                total += product.Price;
            }
            return View("Index", (object)string.Format("Total Soccer>20: {0}",total));
        }

        //Consulta link con Fitro
        public ViewResult CreateListFilter()
        {
            Product[] productArray =
            {
                 new Product {Name="Kayak",Category="Watersports",Price=275M},
                 new Product {Name="Lifejacket",Category="Watersports",Price=48.95M},
                 new Product {Name="Soccer Ball",Category="Soccer",Price=19.50M},
                 new Product {Name="Corner Flag",Category="Soccer",Price=34.95M},
            };
            decimal total = 0;
            //filtro
            foreach (Product prod in productArray.Where(prod => prod.Category
            == "Soccer"))
            {
            }
            total += prod.Price;
            return View("Index", (object)String.Format("Total Soccer:{0}",
            total));
        }

        //Tipos anonimos
        public ViewResult CreateAnonArray()
        {
            var oddsAndEnds = new[]
            {
                new {Name= "MVC",Category="Pattern"},
                new {Name= "Hat",Category="Clothing"},
                new {Name= "Apple",Category="Fruit"}
            };
            StringBuilder result= new StringBuilder();
            foreach (var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" ");
            }
            return View("Index", (object)result.ToString());
        }
        //Metodos Diferidos 
        //la consulta no se ejecuta hasta que los elementos se enumeran
        public ViewResult FindProducts()//metodos en diferido no se ejecutan hasta que hago la numeracion 
            //cuando enumero cuando hago el foreach 
        {
            Product[] products =
           {
                new Product{Name="Kayac",Price=275M,Category="Watersports" },
                new Product{Name="Lifejacket",Price=48.5M,Category="Watersports" },
                new Product{Name = "Soccer Ball", Price = 19.50M, Category = "Soccer" },
                new Product{Name= "Corner Flag", Price= 34.95M, Category= "Soccer" }
            };
            var results = products.Sum(p => p.Price);//el sum no admite metodos diferidos el Take si por que 
            //en el sum no estoy enumerando nada

            //var foundProducts= products.OrderByDescending(p=>p.Price)
            //    .Take(3)
            //    .Select(p=>new {
            //        p.Name,
            //        p.Price,
            //    });
            products[2] = new Product { Name = "Stadium", Price =2506522M};
            //StringBuilder result= new StringBuilder();
            //foreach(var item in foundProducts)
            //{
            //    result.AppendFormat("Price: {0}", item.Price);
            //}
            return View("Index",(object)string.Format($"La suma es: {results}"));

        }
    }
}