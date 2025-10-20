using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa3
{
    internal class PersonaItaliana:Persona
    {
        public override void saludar()
        {
            Console.WriteLine($"Hola soy {Nombre}. Tengo {CalcularEdad(fechaNacimiento)}. Ciao");
        }
    }
}
