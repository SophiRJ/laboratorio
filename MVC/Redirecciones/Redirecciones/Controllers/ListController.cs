using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Redirecciones.Controllers
{
    public class ListController : Controller
    {
        // GET: List
        public ActionResult Index()
        {
            return View();
        }
        public RedirectToRouteResult Redireccionado()
        {
            //uso de Session con redirect
            Session["usuario"] = "Javier";
            Session["rol"] = "Administrador";
            //vmaos a pasar los datos a otro controlador
            return RedirectToAction("ReciberedireccionadoDeList", "Home");
        }
    }
}