using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorMascotasEnRefugio
{
    internal class Gato:Mascota
    {
        public bool Esterilizado { get; set; }
        public bool Domestico { get; set; }
        public Gato(string nombre, string tipo, int edad, double peso,bool esterilizado,bool domestico)
            : base(nombre,tipo,edad,peso) 
        {
            Esterilizado = esterilizado;
            Domestico = domestico;
        }
        public override double CalcularRacion()
        {
            double racion = 0;
            racion = (Esterilizado == true && Domestico == true) ? Peso * (1.2) : Peso * 2.5;
            return Math.Round(racion, 2);
        }
        public override void MostrarInfo(bool detallado)
        {
            base.MostrarInfo(detallado);
            Console.WriteLine($"Esterilizado?: {Esterilizado}, Domestico?: {Domestico}");
        }
    }
}
