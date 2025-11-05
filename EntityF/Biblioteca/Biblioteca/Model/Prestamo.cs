using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Model
{
    public class Prestamo
    {
        public int Id { get; set; }
        public DateTime FechaPrestamo { get; set; } = DateTime.UtcNow;
        public DateTime? FechaDevolucion { get; set; }
        public int LibroId { get; set; }
        public Libro Libro { get; set; } = null!;
        public int BibliotecarioId { get; set; }
        public Bibliotecario Bibliotecario { get; set; } = null!;
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }
}
