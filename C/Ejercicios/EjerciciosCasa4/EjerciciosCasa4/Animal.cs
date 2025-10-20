using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    internal class Animal
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public Animal(string _nombre, string _tipo) { 
            Nombre = _nombre;
            Tipo = _tipo;
        }
        public void HacerSonido(string sonido)
        {
            Console.WriteLine($"Hola soy {Nombre} y mi sonido es {sonido}");
        }
    }
}
