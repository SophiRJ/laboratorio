using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Redirecciones.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //uso de viewBag y viewData
            ViewBag.Mensaje = "Hola";
            ViewBag.Date = DateTime.Now;

            ViewData["Edad"] = 23;
            ViewData["Precio"] = 45.40M;
            return View();
        }

        //preparado para redireccionar a otro metodo
        public RedirectToRouteResult ReciberedireccionadoDeList()
        {
            return RedirectToAction("Index","List");
        }
        public ActionResult RecibeRedireccionado()
        {
            ViewBag.Mensaje = TempData["Message"];
            ViewBag.Date = TempData["Date"];
            ViewData["Edad"] = TempData["Edad"];
            ViewData["Precio"] = TempData["Precio"];
            return View("Index");
        }
        public RedirectToRouteResult Redireccionado()
        {
            TempData["Message"] = "Hello";
            TempData["Date"] = Convert.ToDateTime("12/07/1992");
            TempData["Edad"] = 84;
            TempData["Precio"] = 15.65M;
            return RedirectToAction("RecibeRedireccionado");
        }
    }
}