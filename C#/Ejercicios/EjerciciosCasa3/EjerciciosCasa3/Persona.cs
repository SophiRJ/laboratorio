using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa3
{
    internal class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public DateTime fechaNacimiento { get; set; }



        public int CalcularEdad(DateTime fechaNacimiento)
        {
            
            return DateTime.Now.Year-fechaNacimiento.Year;
        }
        public virtual void saludar()
        {
            Console.WriteLine($"Hola, soy {Nombre} y tengo {CalcularEdad(fechaNacimiento)} años");
        }
    }
}
