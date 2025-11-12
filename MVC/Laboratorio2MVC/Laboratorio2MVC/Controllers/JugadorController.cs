using Laboratorio2MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laboratorio2MVC.Controllers
{
    public class JugadorController : Controller
    {

        private static List<Jugador> jugadores = new List<Jugador>
        {
            new Jugador(1,"Lionel Messi","Delantero",650000),
            new Jugador(2,"Cristiano Ronaldo","Delantero",500000),
            new Jugador(3,"Sergio Ramos","Defensa",400000),
            new Jugador(4,"Luka Modric","Centrocampista",300000)
        };
        public ActionResult ListarJugadores()
        {
            ViewBag.Titulo = "Listado General de Jugadores";
            ViewBag.TotalSueldos = TotalSueldos();
            return View(jugadores);
        }
        public ViewResult JugadorMasGana() {
            var jugadorMasGana= jugadores.OrderByDescending(j=>j.Sueldo).FirstOrDefault();
            return View(jugadorMasGana);
        }
        public int TotalSueldos()
        {
            var totalS= jugadores.Sum(j=>j.Sueldo);
            
            return totalS;
        }
        public ActionResult AñadirJugador()
        {
            var nuevoJugador = new Jugador(5, "Vini Vinicius", "Delantero", 430000);
            if(!jugadores.Any(j=>j.JugadorId== nuevoJugador.JugadorId))
            {
                jugadores.Add(nuevoJugador);
            }
            ViewBag.Titulo = "Listado general mas el añadido";
            ViewBag.TotalSueldos = TotalSueldos();
            //Redirecciona a un metodo dentro de mismo controlador
            return View("ListarJugadores", jugadores);
            //return View("ListarJugadores",jugadores);
        }

        public ActionResult TresQueMenosGanan()
        {
            var tresQueMenosGanan = jugadores.OrderBy(j => j.Sueldo).Take(3).ToList();
            ViewBag.Titulo = "Tres que ganan menos";
            return View("ListarJugadores", jugadores);
        }


        // Método para mostrar el listado de jugadores que ganan menos que la media
        public ActionResult JugadoresMenosQueMedia()
        {
            var mediaSueldo = jugadores.Average(j => j.Sueldo);
            
            var jugadoresMenosQueMedia = jugadores.Where(j => j.Sueldo < mediaSueldo).ToList();

            ViewBag.Titulo = "Jugadores que ganan menos que la media";
            ViewBag.Media = mediaSueldo;
            return View("ListarJugadores", jugadoresMenosQueMedia);
        }

    }
}