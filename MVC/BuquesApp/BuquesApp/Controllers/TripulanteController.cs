using BuquesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuquesApp.Controllers
{
    public class TripulanteController : Controller
    {
        // GET: Tripulante
        public ActionResult Index(int id, string nombre)
        {
            List<Tripulante> listaTripulantes = CrearTripulacion();

            var query = listaTripulantes.
                Where(t=>t.BarcoId.Equals(id)).ToList();

            ViewBag.Barco = nombre.ToUpper();

            return View(query);
        }

        private static List<Tripulante> CrearTripulacion()
        {
            List<Tripulante> tripulacion = new List<Tripulante>
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
            return tripulacion;
        }

        public ActionResult Inicio()
        {
            List<Barco> listaBarcos = BarcoController.CrearFlota();

            int cantidad_barcos = listaBarcos.Count;
            for(int i = 0; i < cantidad_barcos; i++)
            {
                listaBarcos[i].tripulacion = CrearTripulacion().Where(t=>t.BarcoId == listaBarcos[i].BarcoId).ToList();
            }

            var query = listaBarcos.OrderByDescending(b => b.NombreBarco).ToList();

            return View(query);
        }
    }
}