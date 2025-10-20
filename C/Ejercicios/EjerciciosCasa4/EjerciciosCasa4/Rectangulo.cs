using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    internal class Rectangulo
    {
        public decimal ancho { get; set; }
        public decimal alto { get; set; }
        public Rectangulo(decimal _ancho, decimal _alto) {
            ancho= _ancho;
            alto= _alto;
        }
        public void mostrarArea()
        {
            Console.WriteLine($"El area es: {ancho * alto}");
        }
        public void mostrarPerimetro()
        {
            Console.WriteLine($"El perimatro es: {2*(ancho+alto)}");
        }

    }
}
