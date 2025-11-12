using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSimApp.Models
{
    public class Operacion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CriptomonedaId { get; set; }
        public string TipoOperacion { get; set; } = string.Empty; // Compra o Venta
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public DateTime Fecha { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public Criptomoneda Criptomoneda { get; set; } = null!;
    }
}
