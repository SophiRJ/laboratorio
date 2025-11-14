using BuquesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuquesApp.Controllers
{
    public class LocationController : Controller
    {
        private static List<Barco> barcos = new List<Barco>
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

        private static List<Tripulante> tripulantes = new List<Tripulante>
        {
            new Tripulante {TripulanteId=1,NombreTripulante="David",Cargo="Contramaestre",
                    FechaTituloNavegacion=Convert.ToDateTime("05/08/1999"), BarcoId=1},
                new Tripulante {TripulanteId=2,NombreTripulante="Felix",Cargo="Almirante",
                    FechaTituloNavegacion=Convert.ToDateTime("05/09/2001"), BarcoId=2},
                new Tripulante {TripulanteId=3,NombreTripulante="Ricardo",Cargo="Marinero",
                    FechaTituloNavegacion=Convert.ToDateTime("08/08/1988"),BarcoId=1},
                new Tripulante {TripulanteId=4,NombreTripulante="Elena",Cargo="Marinero",
                    FechaTituloNavegacion=Convert.ToDateTime("16/08/1999"),BarcoId=3},
                new Tripulante {TripulanteId=5,NombreTripulante="Susana",Cargo="Sobrecargo",
                    FechaTituloNavegacion=Convert.ToDateTime("17/10/2002"),BarcoId=1},
                new Tripulante {TripulanteId=6,NombreTripulante="Javier",Cargo="Marinero 1ª",
                    FechaTituloNavegacion=Convert.ToDateTime("05/08/2001"),BarcoId=4},
                new Tripulante {TripulanteId=7,NombreTripulante="Federico",Cargo="Marinero 2ª",
                    FechaTituloNavegacion=Convert.ToDateTime("19/01/1999"),BarcoId=4},
                new Tripulante {TripulanteId=8,NombreTripulante="Inmaculada",Cargo="Piloto",
                    FechaTituloNavegacion=Convert.ToDateTime("17/10/2003"),BarcoId=4}

        };
        // GET: Location
        public ActionResult Index()
        {
            var model = new LocationViewModel
            {
                Barcos= barcos.Select(b=>new SelectListItem
                {
                    Value=b.BarcoId.ToString(),
                    Text=b.NombreBarco
                }),
                Tripulantes= new List<SelectListItem>(),
                AllTripulantes= tripulantes.Select(t=>new Tripulante
                {
                    TripulanteId= t.TripulanteId,
                    NombreTripulante=t.NombreTripulante,
                    BarcoId=t.BarcoId
                })
            };
            return View(model);
        }
    }
}