using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorVehiculos
{
    internal class Moto : Vehiculo, IMantenimiento
    {
        string tipo;
        int cilindrada; 
        bool tieneBaul;

        public Moto(string _marca, string _modelo, int _año, string _color, int _peso, double _precio, int _velMaxima,
                    string _tipo, int _cilindrada, bool _tieneBaul)
            : base(_marca, _modelo, _año, _color, _peso, _precio, _velMaxima)
        {
            tipo = _tipo;
            cilindrada = _cilindrada;
            tieneBaul = _tieneBaul;
        }

        public override void CalcularImpuesto()
        {
            double extra = cilindrada > 500 ? 0.10 : 0.05;
            precioFinal = precioBase + (precioBase * (IVA + extra));
            Console.WriteLine($"El precio final de la moto es: {precioFinal:C}");
        }

        public override void MostrarInfo()
        {
            Console.WriteLine($"{marca} {modelo} {año} - {cilindrada}cc - {precioFinal:C}");
        }

        public override void MostrarInfo(bool detallado)
        {
                Console.WriteLine($"Moto: {marca} {modelo} ({año})\n" +
                                  $"Tipo: {tipo}, Cilindrada: {cilindrada}cc, Baúl: {(tieneBaul ? "Sí" : "No")}\n" +
                                  $"Color: {color}, Vel. Máx: {velocidadMAx} km/h, Precio final: {precioFinal:C}");   
            
        }

        public void RealizarMantenimiento()
        {
            Console.WriteLine("Revisando cadena, presión de neumáticos y frenos...");
        }
    }
}
