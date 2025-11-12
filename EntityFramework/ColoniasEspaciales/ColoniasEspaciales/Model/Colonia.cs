using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoniasEspaciales.Model
{
    public class Colonia
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int PlanetaId { get; set; }
        public virtual Planeta? Planeta { get; set; }
        public ICollection<Recurso> Recursos { get; set; } = new List<Recurso>();
        public ICollection<Habitante> Habitantes { get; set; } = new List<Habitante>();
        public ICollection<Evento>? Eventos { get; set; } =new List<Evento>();

    }
}
