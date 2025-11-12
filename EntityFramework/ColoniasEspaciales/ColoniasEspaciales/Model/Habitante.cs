using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoniasEspaciales.Model
{
    public class Habitante
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public int ColoniaId { get; set; }
        public virtual Colonia? Colonia { get; set; }

    }
}
