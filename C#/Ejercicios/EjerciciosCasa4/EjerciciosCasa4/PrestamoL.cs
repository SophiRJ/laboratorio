using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    internal class PrestamoL
    {
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime fechaPrestamo { get; set; }
        public bool activo { get; set; }
        public PrestamoL(Libro lib, Usuario usu, DateTime fechaP)
        {
            Libro = lib;
            Usuario = usu;
            fechaPrestamo = fechaP;
            activo = true;
        }
    }
}
