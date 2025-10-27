using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestorMascotasEnRefugio
{
    internal class Perro:Mascota
    {
        public string Raza { get; set; }
        public int NivelActividad { get; set; }
        public Perro(string nombre, string tipo, int edad, double peso, string raza,int nivelAct)
            : base(nombre, tipo, edad, peso)
        {
            Raza = raza;
            NivelActividad = nivelAct;
        }
        public override double CalcularRacion()
        {
            double racion = 0;
            racion = (NivelActividad >= 5) ? Peso * 2.43 : Peso * 1.53;    
            return Math.Round(racion, 2); ;
        }
        public override void MostrarInfo(bool detallado)
        { 
            base.MostrarInfo(detallado);
            Console.WriteLine($"Raza: {Raza}, Nivel de Actividad: {NivelActividad}");
        }
        public override void Vacunar()
        {
            Console.WriteLine($"{Nombre} esta siendo vacunado contra Rabia y Sarna Canina");
            Thread.Sleep(2000);
        }
    }
}
