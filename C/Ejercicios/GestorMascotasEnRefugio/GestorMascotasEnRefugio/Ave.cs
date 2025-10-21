using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorMascotasEnRefugio
{
    internal class Ave:Mascota
    {
        public string Especie { get; set; }
        public bool Vuela { get; set; }
        public Ave(string nombre, string tipo, int edad, double peso, string especie, bool vuela)
            : base(nombre, tipo, edad, peso)
        {
            Vuela = vuela;
            Especie=especie;
        }
        public override double CalcularRacion()
        {
            double racion = 0;
            racion = (Vuela) ? Peso * 2.14 : Peso * 1.2;
            return Math.Round(racion, 2);
        }
        public override void MostrarInfo(bool detallado)
        {
            string volador = (Vuela) ? "Volador" : "No Volador";
            
            base.MostrarInfo(detallado);
            Console.WriteLine($"Especie: {Especie}, {volador}");
        }
    }
}
