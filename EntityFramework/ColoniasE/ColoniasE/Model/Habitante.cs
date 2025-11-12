using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoniasE.Model
{
    public class Habitante
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public int ColoniaId { get; set; }
        public Colonia Colonia { get; set; } = null!;

    }
}
