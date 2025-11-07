using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio2MVC.Models
{
    public class Jugador
    {
        public int JugadorId { get; set; }
        public string NombreApellidos { get; set; }
        public string Posicion { get; set; }
        public int Sueldo { get; set; }
        public Jugador(int jugadorId,string nombreApellidos, string posicion, int sueldo)
        {
            JugadorId=jugadorId;
            NombreApellidos=nombreApellidos;
            Posicion=posicion;
            Sueldo = sueldo;
        }
    }
}