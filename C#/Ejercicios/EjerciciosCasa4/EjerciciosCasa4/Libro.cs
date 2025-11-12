using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    public class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Año { get; set; }
        public bool Disponible {  get; set; }

        public Libro(string titulo, string autor, int año)
        {
            Titulo = titulo;
            Autor = autor;
            Año = año;
            Disponible= true;
        }
    }
}
