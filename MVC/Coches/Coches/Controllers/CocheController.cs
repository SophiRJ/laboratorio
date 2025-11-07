using Coches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coches.Controllers
{
    public class CocheController : Controller
    {
        private static List<Coche> coches = new List<Coche>()
        {
            new Coche { Marca = "Audi", Modelo = "A3", Color = "Negro", Precio = 20000 },
            new Coche { Marca = "BMW", Modelo = "320", Color = "Azul", Precio = 25000 },
            new Coche { Marca = "Seat", Modelo = "Ibiza", Color = "Rojo", Precio = 15000 }
        };

        //Añadir coche nuevo
        public ActionResult CrearCoche()
        {
            var nuevoCoche=new Coche("Toyota","Corolla","Blanco",18000);
            if (!coches.Any(c => c.Marca == nuevoCoche.Marca &&c.Modelo == nuevoCoche.Modelo)) {
                coches.Add(nuevoCoche);  
            };
            ViewBag.Mensaje = "El coche añadido correctamente";
            return View("listarCoches", coches);
        }

        //crear array clientes
        public ActionResult CrearCliente()
        {
            string[] clientes = { "Ana", "Alvaro", "Carlos", "Maria" };
            string cliente = clientes[1];
            ViewBag.ClienteSeleccionado= cliente;
            return View();
        }

        public ActionResult ListarCoches()
        {
            ViewBag.Titulo = "Listado general de coches";
            return View(coches);
        }

        public ActionResult ListarCochesOrdenados()
        {
            var cochesOrdenados= coches.OrderByDescending(c=>c.Marca).ToList();
            ViewBag.Titulo = "Listado de coches por marca (desc)";
            return View("listarCoches", cochesOrdenados);
        }
        public ActionResult CalcularMediaPrecio()
        {
            if (!coches.Any())
            {
                ViewBag.MediaPrecio = 0;
                ViewBag.Mensaje = "No hay coches";
            }
            else
            {
                double media = coches.Average(c => c.Precio);
                ViewBag.MediaPrecio = media;
            }
            ViewBag.Titulo = "Listado de coches por media";
            return View("listarCoches",coches);
        }
        public ActionResult EliminarCoche(string id)
        {
            var coche = coches.FirstOrDefault(c => c.Modelo == id);
            if(coche != null)
            {
                coches.Remove(coche);
                ViewBag.Mensaje = $"Coche {id} eliminado de la lista";
            }
            return View("listarCoches",coches);
        }
    
    }
}