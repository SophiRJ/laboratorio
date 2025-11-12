using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGimnasio.Model
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public int SocioId { get; set; }
        public Socio Socio { get; set; } = null!;

        public int ClaseId { get; set; }
        public Clase Clase { get; set; } = null!;

        public DateTime FechaInicio { get; set; }
    }
}
