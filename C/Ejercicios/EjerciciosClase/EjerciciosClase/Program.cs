using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosClase
{
    class Auto: IVehiculo, Imostrable
    {
        public string Marca { get; set; }
        public int Velocidad { get; private set; }
        public Auto(string marca, int velocidadInicial) { 
            Marca= marca;
            Velocidad= velocidadInicial;
        }
        public void Frenar() => Velocidad -= 5;
        public void Acelerar() => Velocidad += 10;
        public void MostrarInfo()
        {
            Console.Write($"Auto: {Marca} velocidad actual {Velocidad} km/h");
        }

    }
    class Moto : IVehiculo, Imostrable
    {
        public string Modelo { get; set; }
        public int Velocidad { get; private set; }
        public Moto(string modelo, int velocidadInicial) { 
            Modelo= modelo;
            Velocidad = velocidadInicial;
        }
        public void Acelerar() => Velocidad += 150;
        public void Frenar() => Velocidad -= 120;

        public void MostrarInfo() {
            Console.WriteLine($"Moto: {Modelo} velocidad actual {Velocidad} km/h");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IVehiculo v1 = new Auto("Toyota", 50);
            IVehiculo v2 = new Moto("Yamaha", 40);

            ((Imostrable)v1).MostrarInfo();
            ((Imostrable)v2).MostrarInfo();

            Console.WriteLine("Acelerando Vehiculos..");
            v1.Acelerar();
            v2.Acelerar();

            ((Imostrable)v1).MostrarInfo();
            ((Imostrable)v2).MostrarInfo();

            v1.Frenar();
            v2.Frenar();

            ((Imostrable)v1).MostrarInfo();
            ((Imostrable)v2).MostrarInfo();

            Console.ReadKey();
        }
    }
}
