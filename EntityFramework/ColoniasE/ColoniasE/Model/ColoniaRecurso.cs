using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoniasE.Model
{
    public class ColoniaRecurso
    {
        public int ColoniaId { get; set; }
        public int RecursoId { get; set; }
        public int Cantidad { get; set; }
        public Colonia Colonia { get; set; } = null!;
        public Recurso Recurso { get; set; } = null!;
    }
}
