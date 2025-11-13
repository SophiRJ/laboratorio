using BuquesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuquesApp.Controllers
{
    public class BarcoController : Controller
    {
        // GET: Barco
        public ActionResult Index()
        {
            List<Barco> listaBarcos = CrearFlota();
            var query = listaBarcos.OrderByDescending(b=>b.AñoConstruccion).ToList();
            return View(query);
        }

        public static List<Barco> CrearFlota()
        {
            List<Barco> flota = new List<Barco>
            {
                new Barco {BarcoId=1,NombreBarco="María Luisa",AñoConstruccion=2003, CosteConstruccion=1200, 
                    FechaUltimaReparacion=Convert.ToDateTime("12/07/2005")},
                new Barco {BarcoId=2,NombreBarco="La Pili",AñoConstruccion=1997,CosteConstruccion=2400, 
                    FechaUltimaReparacion=Convert.ToDateTime("12/10/1999")},
                new Barco {BarcoId=3,NombreBarco="El Torreon",AñoConstruccion=1993,CosteConstruccion=1700, 
                    FechaUltimaReparacion=Convert.ToDateTime("12/07/2005")},
                new Barco {BarcoId=4,NombreBarco="La Niña",AñoConstruccion=1998,CosteConstruccion=3100, 
                    FechaUltimaReparacion=Convert.ToDateTime("10/06/2002")}
            };
            return flota;
        }

    }
}