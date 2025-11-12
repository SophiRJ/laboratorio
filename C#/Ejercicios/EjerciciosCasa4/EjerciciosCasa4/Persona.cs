using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    internal class Persona
    {
        private string nombre;
        private int edad;
        private string ciudad;

        public Persona(string _nombre, int _edad, string _ciudad)
        {
            nombre = _nombre;
            edad = _edad;
            ciudad = _ciudad;
        }
        public string Nombre { get => nombre;set=>nombre = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Ciudad {  get => ciudad; set => ciudad = value; }

        public void mostrarInfo()
        {
            Console.WriteLine($"Nombre: {Nombre} Edad: {Edad} Ciudad:{Ciudad}");
        }
    }
}
