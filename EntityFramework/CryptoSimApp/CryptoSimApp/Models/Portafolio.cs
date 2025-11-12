using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSimApp.Models
{
    public class Portafolio
    {
        public int UsuarioId { get; set; }
        public int CriptomonedaId { get; set; }
        public double CantidadActual { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public Criptomoneda Criptomoneda { get; set; } = null!;
    }
}
