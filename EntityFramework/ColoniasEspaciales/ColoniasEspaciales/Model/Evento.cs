using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoniasEspaciales.Model
{
    public class Evento
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descripcion { get; set; }
        public int ColoniaId { get; set; }
        public virtual Colonia? Colonia { get; set; }
    }
}
