using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptomonedas.Model
{
    public class Criptomoneda
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Simbolo { get; set; }
        public double ValorActual { get; set; }
        public ICollection<Portafolio> Portafolios { get; set; } = new List<Portafolio>();
        public ICollection<Operacion> Operaciones { get; set; } = new List<Operacion>();
    }
}
