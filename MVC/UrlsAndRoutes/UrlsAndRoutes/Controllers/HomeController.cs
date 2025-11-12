using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action="Index";
            return View("ActionName");
        }
        public ActionResult CustomVariable(string id)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action="CustomVariable";
            ViewBag.CustomVariable = RouteData.Values["id"];
            return View();
        }
        
        public RedirectToRouteResult MyActionMethod(int id)
        {//pasar a otro metodo
            int dato = id;
            return RedirectToAction("Metodo Redirccionado", "Admin", new {valor=dato});
        }
    }
}