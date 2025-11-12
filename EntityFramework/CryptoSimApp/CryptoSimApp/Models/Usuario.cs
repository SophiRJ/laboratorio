using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSimApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public double SaldoVirtual { get; set; }

        public ICollection<Portafolio> Portafolios { get; set; } = new List<Portafolio>();
        public ICollection<Operacion> Operaciones { get; set; } = new List<Operacion>();
    }
}
