using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosEnergiaRenovable.Model
{
    public class Inversion
    {
        public int InversorId { get; set; }
        public int ProyectoId { get; set; }
        public double MontoInvertido { get; set; }
        public Inversor Inversor { get; set; } = null!;
        public Proyecto Proyecto { get; set; } = null!;
    }
}
