using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa3
{
    internal class PersonaInglesa:Persona
    {
        public override void saludar()
        {
            Console.WriteLine($"Hi I am {Nombre}");
        }
        public void TomarTe()
        {
            Console.WriteLine($"Estoy tomando te tengo {CalcularEdad(fechaNacimiento)}");
        }
    }
}
