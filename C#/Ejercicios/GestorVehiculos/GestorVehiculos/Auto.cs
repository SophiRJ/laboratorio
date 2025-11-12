using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GestorVehiculos
{
    internal class Auto : Vehiculo
    {
        public int Puertas { get; set; }
        public int CapacidadMaletero { get; set; }
        public double DescIVA { get; set; }

        public Auto(string _marca, string _modelo, int _año, string _color, int _peso, double _precio, int _velMaxima, int _puertas, int _capacidadMAletero,double _descIva)
            : base(_marca, _modelo, _año, _color, _peso, _precio, _velMaxima)
        {
            Puertas = _puertas;
            CapacidadMaletero = _capacidadMAletero;
            DescIVA = _descIva;
        }
        
        public override void CalcularImpuesto()
        {
            double precioConIVA = PrecioBase + (PrecioBase * IVA);
            double descuento = precioConIVA * (DescIVA / 100);
            PrecioFinal = precioConIVA - descuento;
        }


        public override void MostrarInfo(bool detallado)
        {
            Console.WriteLine("====Auto===");
            base.MostrarInfo(detallado);
            Console.WriteLine($"Puertas: {Puertas},\nCapacidad Maletero: {CapacidadMaletero} kg,\nPrecio Final: {PrecioFinal:C}");
        }

        public override void RealizarMantenimiento()
        {
            Console.WriteLine("Revisando aceite y frenos...");
        }
    }
}
