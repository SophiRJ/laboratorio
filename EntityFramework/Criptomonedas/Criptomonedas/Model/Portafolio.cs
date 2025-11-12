using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptomonedas.Model
{
    public class Portafolio
    {
        public int CriptomonedaId { get; set; }
        public int UsuarioId { get; set; }
        public Criptomoneda Criptomoneda { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
        public int CantidadActual { get; set; }
    }
}
