using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestorVehiculos
{
    internal class Auto : Vehiculo, IMantenimiento
    {
        int puertas;
        int capacidadMaletero;
        double descuentoIva;

        public Auto(string _marca, string _modelo, int _año, string _color, int _peso, double _precio, int _velMaxima, int _puertas, int _capacidadMAletero,double _descIva)
            : base(_marca, _modelo, _año, _color, _peso, _precio, _velMaxima)
        {
            puertas = _puertas;
            capacidadMaletero = _capacidadMAletero;
            descuentoIva = _descIva;
        }
        public int Puertas { get => puertas;set=>puertas = value; }
        public int CapMaletero { get => capacidadMaletero; set => capacidadMaletero = value; }
        public double DescIva { get => descuentoIva;set=>descuentoIva=value; }

        public override void CalcularImpuesto()
        {
            double precioParcial= precioBase * IVA;
            precioFinal = precioParcial - descuentoIva;
            Console.WriteLine($"El precio final es: {precioFinal:C} ");
        }

        public override void MostrarInfo()
        {
            Console.WriteLine($"{marca} {modelo} {año} - ${precioFinal}");
        }

        public override void MostrarInfo(bool detallado)
        {
            Console.WriteLine($"Auto: {marca} {modelo}, Año: {año}, Puertas: {puertas}, Precio: {precioFinal:C}");
        }

        public void RealizarMantenimiento()
        {
            Console.WriteLine("Revisando aceite y frenos...");
        }
    }
}
