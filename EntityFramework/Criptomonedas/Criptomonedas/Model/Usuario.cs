using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptomonedas.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public double SaldoVirtual { get; set; }
        public string? Email { get; set; }
        public ICollection<Portafolio> Portafolios { get; set; } = new List<Portafolio>();
        public ICollection<Operacion> Operaciones { get; set; } = new List<Operacion>();

    }
}
