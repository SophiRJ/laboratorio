using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorVehiculos
{
    internal class Camion : Vehiculo
    {
        public double CapacidadCarga { get; set; }
        public int Ejes { get; set; }
        public bool UsoComercial { get; set; }

        public Camion(string _marca, string _modelo, int _año, string _color, int _peso, double _precio, int _velMaxima,
                      double _capacidadCarga, int _ejes, bool _usoComercial)
            : base(_marca, _modelo, _año, _color, _peso, _precio, _velMaxima)
        {
            CapacidadCarga = _capacidadCarga;
            Ejes = _ejes;
            UsoComercial = _usoComercial;
        }

        public override void CalcularImpuesto()
        {
            double tasaExtra = UsoComercial ? 0.15 : 0.10;
            PrecioFinal = PrecioBase + (PrecioBase * (IVA + tasaExtra));
        }


        public override void MostrarInfo(bool detallado)
        {
            Console.WriteLine("===Camion===");
            base.MostrarInfo(detallado);
            Console.WriteLine($"Carga: {CapacidadCarga}t,\nEjes: {Ejes},\nUso comercial: {(UsoComercial ? "Sí" : "No")},\nPrecio final: {PrecioFinal:C}"); 
        }

        public override void RealizarMantenimiento()
        {
            Console.WriteLine("Revisando motor, frenos de aire y sistema hidráulico...");
        }
    }
}

