using EventoFotografos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventoFotografos.Controllers
{
    public class FotografoController : Controller
    {
        public static List<Fotografo> ObtenerFotografos()
        {
            var lista = new List<Fotografo>
        {
            new Fotografo { Id = 1, Nombre = "Carlos Pérez", Direccion = "Calle Luna 45" },
            new Fotografo { Id = 2, Nombre = "María López", Direccion = "Av. del Sol 120" },
            new Fotografo { Id = 3, Nombre = "Juan Ramírez", Direccion = "Calle Olivo 22" },
            new Fotografo { Id = 4, Nombre = "Laura Sánchez", Direccion = "Paseo del Río 8" }
        };

            return lista;
        }
        // GET: Fotografo
        public ActionResult Index()
        {
            var lista= ObtenerFotografos();
            return View(lista);
        }
    }
}