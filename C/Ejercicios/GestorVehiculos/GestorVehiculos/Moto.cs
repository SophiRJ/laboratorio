using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorVehiculos
{
    internal class Moto : Vehiculo
    {
        public string Tipo { get; set; }
        public int Cilindrada { get; set; }
        public bool TieneBaul { get; set; }

        public Moto(string _marca, string _modelo, int _año, string _color, int _peso, double _precio, int _velMaxima,
                    string _tipo, int _cilindrada, bool _tieneBaul)
            : base(_marca, _modelo, _año, _color, _peso, _precio, _velMaxima)
        {
            Tipo = _tipo;
            Cilindrada = _cilindrada;
            TieneBaul = _tieneBaul;
        }

        public override void CalcularImpuesto()
        {
            double extra = Cilindrada > 500 ? 0.10 : 0.05;
            PrecioFinal = PrecioBase + (PrecioBase * (IVA + extra));
        }


        public override void MostrarInfo(bool detallado)
        {
            Console.WriteLine("===Moto===");
            base.MostrarInfo(detallado);
            Console.WriteLine($"Tipo: {Tipo},\nCilindrada: {Cilindrada}cc,\nBaúl: {(TieneBaul ? "Sí" : "No")},\nPrecio final: {PrecioFinal:C}");       
        }

        public override void RealizarMantenimiento()
        {
            Console.WriteLine("Revisando cadena, presión de neumáticos y frenos...");
        }
    }
}
