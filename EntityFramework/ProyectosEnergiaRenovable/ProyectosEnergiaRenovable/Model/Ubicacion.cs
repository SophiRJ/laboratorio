using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosEnergiaRenovable.Model
{
    public class Ubicacion
    {
        public int Id { get; set; }
        public string? Ciudad { get; set; }
        public string? Pais { get; set; }
        public ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
    }
}
