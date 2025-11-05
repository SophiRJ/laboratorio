using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosEnergiaRenovable.Model
{
    public class Informe
    {
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; } = null!;
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public int EnergiaGeneradaMWh { get; set; }
    }
}
