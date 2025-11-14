using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LigaProfesional.Models
{
    public class Jugador
    {
        public int JugadorId { get; set; }
        public string NombreJugador { get; set; }
        public string Posicion { get; set; }
        public int Edad { get; set; }
        public int EquipoId { get; set; }
        public virtual Equipo Equipo { get; set; }

        public static List<Jugador> CrearJugadores()
        {
            List<Jugador> jugadorList = new List<Jugador>()
            {
                new Jugador { JugadorId=1,NombreJugador="Pepe",Edad=23,Posicion="Delantero",EquipoId=1 },
                new Jugador { JugadorId=2,NombreJugador="Juan",Edad=22,Posicion="Defensa",EquipoId=1 },
                new Jugador { JugadorId=3,NombreJugador="Andrés",Edad=21,Posicion="Portero", EquipoId=1 },
                new Jugador { JugadorId=4,NombreJugador="Tomás",Edad=26,Posicion="Delantero", EquipoId=1 },
                new Jugador { JugadorId=5,NombreJugador="Javier",Edad=23,Posicion="Delantero" , EquipoId=2},
                new Jugador { JugadorId=6,NombreJugador="Carlos",Edad=21,Posicion="Defensa" , EquipoId=2},
                new Jugador { JugadorId=7,NombreJugador="Andrés",Edad=21,Posicion="Portero", EquipoId=2},
                new Jugador { JugadorId=8,NombreJugador="Tomás",Edad=26,Posicion="Delantero", EquipoId=2 },
                new Jugador { JugadorId=9,NombreJugador="Evaristo",Edad=23,Posicion="Delantero", EquipoId=3 } ,
                new Jugador { JugadorId=10,NombreJugador="Sebas",Edad=22,Posicion="Defensa", EquipoId=3 },
                new Jugador { JugadorId=11,NombreJugador="Elias",Edad=21,Posicion="Portero" , EquipoId=3},
                new Jugador { JugadorId=12,NombreJugador="Anibal",Edad=29,Posicion="Portero", EquipoId=3 }
            };
            return jugadorList;
        }
    }
}