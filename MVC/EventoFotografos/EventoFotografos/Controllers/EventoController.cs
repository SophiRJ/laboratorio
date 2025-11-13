using EventoFotografos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventoFotografos.Controllers
{
    public class EventoController : Controller
    {
        public static List<Evento> ObtenerEventos()
        {
            var lista = new List<Evento>
        {
            new Evento { Id = 1, Descripcion = "Boda en Madrid", Fecha = new DateTime(2025, 5, 10), Pago = 500m, FotografoId = 1 },
            new Evento { Id = 2, Descripcion = "Concierto de verano", Fecha = new DateTime(2025, 6, 20), Pago = 750m, FotografoId = 2 },
            new Evento { Id = 3, Descripcion = "Cumpleaños infantil", Fecha = new DateTime(2025, 7, 15), Pago = 300m, FotografoId = 1 },
            new Evento { Id = 4, Descripcion = "Evento empresarial", Fecha = new DateTime(2025, 8, 5), Pago = 900m, FotografoId = 3 },
            new Evento { Id = 5, Descripcion = "Desfile de moda", Fecha = new DateTime(2025, 9, 25), Pago = 1000m, FotografoId = 2 },
            new Evento { Id = 6, Descripcion = "Festival cultural", Fecha = new DateTime(2025, 10, 18), Pago = 650m, FotografoId = 1 }
        };

            return lista;
        }
        // GET: Evento
        public ActionResult Index()
        {
            return View();
        }
    }
}