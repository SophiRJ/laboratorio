using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosEnergiaRenovable.Model
{
    public class Inversor
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public double CapitalDisponible { get; set; }
        public ICollection<Inversion> Inversiones { get; set; } = new List<Inversion>();
    }
}
