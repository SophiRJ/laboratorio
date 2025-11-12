using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoniasE.Model
{
    public class Colonia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public double NivelSostenibilidad { get; set; }
        public int PlanetaId { get; set; }
        public Planeta Planeta { get; set; } = null!;
        public ICollection<Habitante> Habitantes { get; set; } = new List<Habitante>();
        public ICollection<ColoniaRecurso> ColoniaRecursos { get; set; } = new List<ColoniaRecurso>();
        public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    }
}
