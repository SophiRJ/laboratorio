using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGimnasio.Model
{
    public class Entrenador
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Especialidad { get; set; }

        public ICollection<Clase> Clases { get; set; } = new List<Clase>();
    }
}
