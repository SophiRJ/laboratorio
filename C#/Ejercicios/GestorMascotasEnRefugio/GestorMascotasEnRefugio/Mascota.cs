using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorMascotasEnRefugio
{
    public abstract class Mascota: ISalud
    {
        protected string Nombre {  get; set; }
        protected string Tipo {  get; set; }
        protected int Edad {  get; set; }
        protected double Peso {  get; set; }
        public Mascota(string nombre, string tipo, int edad, double peso)
        {
            Nombre = nombre;
            Tipo = tipo;
            Edad = edad;
            Peso = peso;
        }
        public string nombre { get => Nombre; }


        public abstract double CalcularRacion();
        public abstract void Vacunar();
        public void MostrarInfo()
        {
            Console.WriteLine($"{Nombre} - {Tipo} ({Edad} años)");
        }
        public virtual void MostrarInfo(bool detallado)
        {
            
            Console.WriteLine($"Mascota: {Nombre}, Tipo: {Tipo}, Edad: {Edad} años, Peso: {Peso:0.00}kg, Alimentación diaria: {CalcularRacion()}gr");
        }
    }
}
