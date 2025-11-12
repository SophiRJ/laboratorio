using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGimnasio.Model
{
    public class Clase
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Nivel { get; set; }
        public decimal PrecioMensual { get; set; }

        
        public int EntrenadorId { get; set; }
        public Entrenador Entrenador { get; set; } = null!;

        
        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();
    }
}
