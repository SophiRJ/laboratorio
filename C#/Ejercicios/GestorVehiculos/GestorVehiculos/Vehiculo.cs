using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorVehiculos
{
    internal abstract class Vehiculo:IMantenimiento
    {
        protected const double IVA = 0.21;
        protected string Marca { get; set; }
        protected string Modelo { get; set; }
        protected int Año { get; set; }
        protected string Color {  get; set; }
        protected int Peso {  get; set; }
        protected double PrecioBase {  get; set; }
        protected double PrecioFinal {  get; set; }
        protected int VelocidadMAx {  get; set; }
        
        
        
        public Vehiculo(string _marca, string _modelo, int _año, string _color, int _peso, double _precio, int _velMaxima)
        {
            Marca= _marca;
            Modelo= _modelo;
            Color= _color;
            Año = _año;
            Peso= _peso;
            PrecioBase= _precio;
            PrecioFinal= 0;
            VelocidadMAx= _velMaxima;
        }
        

        public abstract void CalcularImpuesto();
        public void MostrarInfo()
        {
            Console.WriteLine($"Vehiculo -> Marca: {Marca}, Modelo: {Modelo}, Año: {Año}, Color: {Color}, Año: {Año}");
        }
        public virtual void MostrarInfo(bool detallado)
        {
            Console.WriteLine("=== Información Detallada ===\n" +
           $"Marca: {Marca}\n" +
           $"Modelo: {Modelo}\n" +
           $"Año: {Año}\n" +
           $"Color: {Color}\n" +
           $"Peso: {Peso} kg\n" +
           $"Precio base: ${PrecioBase}\n" +
           $"Velocidad máxima: {VelocidadMAx} km/h");
        }
        public abstract void RealizarMantenimiento();

    }
}
