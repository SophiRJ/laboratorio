using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorVehiculos
{
    internal class Camion : Vehiculo, IMantenimiento
    {
        double capacidadCarga; 
        int ejes;
        bool usoComercial;

        public Camion(string _marca, string _modelo, int _año, string _color, int _peso, double _precio, int _velMaxima,
                      double _capacidadCarga, int _ejes, bool _usoComercial)
            : base(_marca, _modelo, _año, _color, _peso, _precio, _velMaxima)
        {
            capacidadCarga = _capacidadCarga;
            ejes = _ejes;
            usoComercial = _usoComercial;
        }

        public override void CalcularImpuesto()
        {
            double tasaBase = usoComercial ? 0.15 : 0.10;
            precioFinal = precioBase + (precioBase * (IVA + tasaBase));
            Console.WriteLine($"El precio final del camión es: {precioFinal:C}");
        }

        public override void MostrarInfo()
        {
            Console.WriteLine($"{marca} {modelo} ({año}) - {capacidadCarga}t - {precioFinal:C}");
        }

        public override void MostrarInfo(bool detallado)
        {
            if (detallado)
            
                Console.WriteLine($"Camión: {marca} {modelo} ({año})\n" +
                                  $"Carga: {capacidadCarga}t, Ejes: {ejes}, Uso comercial: {(usoComercial ? "Sí" : "No")}\n" +
                                  $"Color: {color}, Peso: {peso}kg, Precio final: {precioFinal:C}");
                  
        }

        public void RealizarMantenimiento()
        {
            Console.WriteLine("Revisando motor, frenos de aire y sistema hidráulico...");
        }
    }
}

