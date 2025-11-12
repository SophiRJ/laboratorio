using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoniasEspaciales.Model
{
    public class Planeta
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public ICollection<Colonia> Colonias { get; set; } = new List<Colonia>();
    }
}
