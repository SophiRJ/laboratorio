using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoniasE.Model
{
    public class Recurso
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int CantidadTotal { get; set; }
        public ICollection<ColoniaRecurso> ColoniaRecurso { get; set; } = new List<ColoniaRecurso>();

    }
}

