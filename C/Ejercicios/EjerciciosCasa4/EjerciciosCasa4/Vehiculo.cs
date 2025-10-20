using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    public class Vehiculo
    {
        public string Color { get; set; }
        public  string Marca{ get; set; }
        public int Año {  get; set; }
        public int velocidadMax {  get; set; }
        public Vehiculo(string color, string marca, int año, int velocidadMax)
        {
            Color = color;
            Marca = marca;
            Año = año;
            this.velocidadMax = velocidadMax;
        }
        public virtual void mostrarInfo()
        {
            Console.WriteLine($"Marca {Marca}, Color: {Color},Año: {Año}, VelocidadMAx:{velocidadMax}");
        }
    }
    public class Moto : Vehiculo
    {
        public string tipoMoto {  get; set; }
        public int cilindrada {  get; set; }
        public Moto(string color, string marca, int año, int velocidadMax, string _tipoMoto, int _cilindrada) : base(color, marca, año, velocidadMax)
        {     
            tipoMoto = _tipoMoto;
            cilindrada = _cilindrada;
        }
        public override void mostrarInfo() {
            base.mostrarInfo();
            Console.WriteLine($"Tipo de moto {tipoMoto}, Cilindrada, {cilindrada}");
        }

    }
    public class Auto : Vehiculo
    {
        public int numPuertas { get; set; }
        public int capacidadMaletero { get; set; }

        public Auto(string color, string marca, int año, int velocidadMax, int _numPuertas, int _capacidadMaletero) : base(color, marca, año, velocidadMax)
        {
            numPuertas = _numPuertas;
            capacidadMaletero= _capacidadMaletero;
        }
        public override void mostrarInfo()
        {
            base.mostrarInfo();
            Console.WriteLine($"Numero Puertas {numPuertas}, Capacidad maletero: {capacidadMaletero}");
        }
    }
}
