using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LigaProfesional.Models
{
    public class Equipo
    {
        public int IdEquipo { get; set; }
        public string NombreEquipo { get; set; }

        public virtual ICollection<Jugador> Jugadores { get; set; }

        public static List<Equipo> CrearEquipos()
        {
            List<Equipo> equipos = new List<Equipo>()
            {
                new Equipo { IdEquipo = 1, NombreEquipo = "Atletico Aviación" },
                new Equipo { IdEquipo = 2, NombreEquipo = "Real Leganes" },
                new Equipo { IdEquipo = 3, NombreEquipo = "Moscardón" }
            };
            //Con esto rellenamos la propiedad de navegación
            int cantidad_equipos = equipos.Count;
            for (int i = 0; i < cantidad_equipos; i++)
            {
                equipos[i].Jugadores = Jugador.CrearJugadores().Where(j => j.EquipoId == equipos[i].IdEquipo).ToList();
            }
            return equipos;
        }
    }
}