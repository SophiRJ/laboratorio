using DisfracesPractica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisfracesPractica.Controllers
{
   

    public class AsistentesController : Controller
    {
        private readonly Asistente[] asistentesData =
            {
                new Asistente { Nombre = "Laura", Acompañado = true,  Tema = TemaDisfraz.Vampiros },
                new Asistente { Nombre = "David", Acompañado = false, Tema = TemaDisfraz.Zombies },
                new Asistente { Nombre = "Ana",   Acompañado = true,  Tema = TemaDisfraz.Brujas },
                new Asistente { Nombre = "Carlos", Acompañado = false, Tema = TemaDisfraz.Otros },
                new Asistente { Nombre = "Marta", Acompañado = true,  Tema = TemaDisfraz.Vampiros },
                new Asistente { Nombre = "Sergio", Acompañado = false, Tema = TemaDisfraz.Zombies },
                new Asistente { Nombre = "Julia", Acompañado = true,  Tema = TemaDisfraz.Brujas },
                new Asistente { Nombre = "Pablo", Acompañado = false, Tema = TemaDisfraz.Otros }
            };
        // GET: Asistentes
        public ActionResult GetAsistentes()
        {
            var model = new DisfracesViewModel
            {
                SelectedTema=null,
                Asistentes=asistentesData
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult FilterAsistentes(TemaDisfraz? selectedTema)
        {
            var filtered= !selectedTema.HasValue
                ? asistentesData: asistentesData.Where(a=>a.Tema==selectedTema);

            var resultado = filtered.Select(a => new
            {
                nombre = a.Nombre,
                acompañado = a.Acompañado,
                tema = a.Tema.ToString()
            });
            return Json(resultado);
        }
    }
}