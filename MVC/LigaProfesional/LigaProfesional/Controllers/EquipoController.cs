using LigaProfesional.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LigaProfesional.Controllers
{
    public class EquipoController : Controller
    {
        // GET: Equipo
        public ActionResult Index()
        {
            return View(Equipo.CrearEquipos());
        }

        public PartialViewResult VerPlantilla(int id)
        {
            List<Equipo> equipos = Equipo.CrearEquipos();
            var jugadores = equipos.FirstOrDefault(e => e.IdEquipo == id).Jugadores;
            return PartialView(jugadores);
        }
    }
}