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

        public List<Jugador> jugadores = new List<Jugador>
        {
            new Jugador(1,"Lionel Messi","Delantero",650000),
            new Jugador(2,"Cristiano Ronaldo","Delantero",500000),
            new Jugador(3,"Sergio Ramos","Defensa",400000),
            new Jugador(4,"Luka Modric","Centrocampista",300000)
        };
        public ActionResult ListarJugadores()
        {
            return View(jugadores);
        }
        public ViewResult JugadorMasGana() {
            var jugadorMasGana= jugadores.OrderByDescending(j=>j.Sueldo).FirstOrDefault();
            return View(jugadorMasGana);
        }
        public ActionResult TotalSueldos()
        {
            var totalS= jugadores.Sum(j=>j.Sueldo);
            ViewBag.TotalSueldos = totalS;
            return View("ListarJugadores",jugadores);
        }
        public ActionResult AñadirJugador()
        {
            var nuevoJugador = new Jugador(5, "Vini Vinicius", "Delantero", 430000);
            jugadores.Add(nuevoJugador);
            //Redirecciona a un metodo dentro de mismo controlador
            return View("ListarJugadores", jugadores);
            //return View("ListarJugadores",jugadores);
        }

        public ActionResult TresQueMenosGanan()
        {
            var tresQueMenosGanan = jugadores.OrderBy(j => j.Sueldo).Take(3).ToList();
            return View(tresQueMenosGanan);
        }


        // Método para mostrar el listado de jugadores que ganan menos que la media
        public ActionResult JugadoresMenosQueMedia()
        {
            var mediaSueldo = jugadores.Average(j => j.Sueldo);
            ViewBag.MediaSueldo = mediaSueldo;
            var jugadoresMenosQueMedia = jugadores.Where(j => j.Sueldo < mediaSueldo).ToList();
            return View(jugadoresMenosQueMedia);
        }

    }
}