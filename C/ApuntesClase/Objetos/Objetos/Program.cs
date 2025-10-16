using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    internal class Program
    {
        public class Puerta
        {
            public int ancho { get; set; }
            public int alto { get; set; }
            public int color { get; set; }
            //sino le damos ambito es private por defecto           
            public bool abierta;

            public Puerta()
            {
                ancho = 23;
                alto = 120;
                color = 34;
                abierta = false;
            }

            public Puerta(int anch, int alt, int col)
            {
                ancho = anch;
                alto = alt;
                color = col;
            }


            public void Abrir()
            {
                abierta = true;
            }
            public void Cerrar()
            {
                abierta = false;
            }
            public void MostrarEstado()
            {
                Console.WriteLine($"Ancho de la puerta: {ancho}");
                Console.WriteLine($"Ancho de la puerta: {alto}");
                Console.WriteLine($"Ancho de la puerta: {color}");
                Console.WriteLine($"Abierta?: {abierta}");

            }
        }

        public class Porton : Puerta{ //herencia : 
            public bool Bloqueado { get; set; }
            public void Bloquear()
            {
                Bloqueado = true;
            }
            public void Desbloquear()
            {
                Bloqueado = false;
            }
            public new void MostrarEstado()//Sobreescibimos el metodo
            {
                Console.WriteLine($"Ancho del porton: {ancho}");
                Console.WriteLine($"Alto del porton: {alto}");
                Console.WriteLine($"color del porton: {color}");
                Console.WriteLine($"Abierta?: {abierta}");
                Console.WriteLine($"Bloqueado?: {Bloqueado}");

            }
        }

        public class Persona
        {
            public string Nombre { get; set; } //prop + tab
            public int Edad { get; set; }
            public DateTime FechaNacimiento { get; set; }

            private int CalcularEdad(DateTime fecha)
            {
                int año = fecha.Year;
                int actual = DateTime.Now.Year;
                return actual - año;
            }
            public void Saludar()
            {
                Console.WriteLine($"Hola me llamo {Nombre} tengo {CalcularEdad(FechaNacimiento)}");
            }
        }

        public class Empleado
        {
            const int sueldo = 1000;
            const string nombre = "Nuevo empleado";
            const string cargo = "Empleado Base";

            public string Nombre { get; set; }
            public int Sueldo { get; set; }
            public string Cargo { get; set; }

            public Empleado()
            {
                Nombre = nombre;
                Sueldo = sueldo;
                Cargo = cargo;
            }    

            public Empleado(string _nombre,int _sueldo, string _cargo)
            {
                Nombre = nombre;
                Sueldo = sueldo;
                Cargo = cargo;
            }
            public void Imprimir()
            {
                Console.WriteLine($"El empleado : {Nombre} con cargo {Cargo} cobra {Sueldo}");
            }

        }
        static void Main(string[] args)
        {
            Console.Write("Empleado generico");
            string nombreEmpleado = Console.ReadLine();
            if (nombreEmpleado.Length == 0)
            {
                Empleado empleadoGenerico = new Empleado();
                empleadoGenerico.Imprimir();
            }else
            {
                Console.Write("Suledo: ");
                int sueldeEmpleado = Convert.ToInt32(Console.ReadLine());
                Console.Write("Cargo: ");
                string cargoEmpleado= Console.ReadLine();

                Empleado empleado = new Empleado(nombreEmpleado, sueldeEmpleado, cargoEmpleado);
                empleado.Imprimir();
            }

                Persona persona = new Persona();
            persona.Nombre = "David";
            DateTime fechaNac = new DateTime(2010, 8, 10);
            persona.FechaNacimiento = fechaNac;

            persona.Saludar();

            Puerta puerta1 = new Puerta();
            puerta1.MostrarEstado();

            Puerta puerta2 = new Puerta(45,190,56);
            puerta2.MostrarEstado();

            //porton
            Porton porton1 = new Porton();
            porton1.ancho = 65;
            porton1.alto = 238;
            porton1.color = 49;
            porton1.abierta = true;
            porton1.Bloqueado = false;

            porton1.MostrarEstado();

            Console.ReadKey();
        }
    }
}
