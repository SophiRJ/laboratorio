using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    /*Crea una interfaz 'INotificacion' con un método 'Enviar()'. 
     * Implementa clases 'Email' y 'SMS' que la usen de forma diferente. 
     * Simula el envío de distintos mensajes.*/
    class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public virtual double PrecioFinal() => Precio;
    }
    class Electronica : Producto
    {
        public override double PrecioFinal() => Precio * 1.21; //21% IVA
    }

    class Ropa : Producto
    {
        public double Descuento { get; set; }
        public override double PrecioFinal() => Precio * (1 - Descuento);
    }

    class Libro
    {
        public string Titulo { get; set; }
    }
    class Usuario
    {
        public string Nombre { get;  set; }
    }
    class Prestamo
    {
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
        public bool Activo { get; set; }
    }
    class Vehiculo
    {
        public string Marca { get; set; }
        public virtual void MostrarInfo() => Console.WriteLine($"Marca: {Marca}");
    }
    class Auto: Vehiculo
    {
        public int Puertas { get; set; }
        public override void MostrarInfo() => Console.WriteLine($"Auto {Marca} con {Puertas}");
    }
    class Moto: Vehiculo
    {
        public bool CascoIncluido { get; set; }

        public override void MostrarInfo() => Console.WriteLine($"Moto {Marca} casco incluido?: {CascoIncluido}");
    }
    internal class Program
    {

        
        static void Main(string[] args)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>()
            {
                new Auto{Marca="Toyota", Puertas=4},
                new Moto{Marca="Suzuki",CascoIncluido=true}
            };
            foreach(var v in vehiculos)
            {
                v.MostrarInfo();
            }

            //Usuario usuario = new Usuario { Nombre = "Ana" };
            //Libro uno = new Libro { Titulo = "C# Avanzado" };
            //Prestamo prestamo = new Prestamo { Usuario = usuario,Libro=uno,Activo=true };
            
            //Console.WriteLine($"{prestamo.Usuario.Nombre} - {prestamo.Libro.Titulo}");

            //inventario de tienda  
            //List<Producto> productos = new List<Producto>
            //{
            //    new Electronica{Nombre="TV",Precio=500},
            //    new Ropa{Nombre="Camiseta",Precio=20,Descuento=0.1}

            //};
            //foreach(var p in productos)
            //{
            //    Console.WriteLine($"{p.Nombre} - Precio Final:{p.PrecioFinal()}");
            //}




            //Concesionario concesionario = new Concesionario(10);
            //Coche c1 = new Coche(1, "BMW", "4", 1000, 12000);
            //Coche c2 = new Coche(2, "Toyota", "Auris", 0, 12000);
            //Coche c3 = new Coche(3, "Seat", "Ibiza", 2000, 15000);
            //Coche c4 = new Coche(4, "Ferrari", "Rosca", 1000, 20000);
            //Coche c5 = new Coche(5, "Peugeout", "206", 10000, 3000);


            //concesionario.AddCoche(c1);
            //concesionario.AddCoche(c2);
            //concesionario.AddCoche(c3);
            //concesionario.AddCoche(c4);
            //concesionario.AddCoche(c5);

            //Console.WriteLine("Coches en el concesionario");
            //concesionario.MostrarCoches();
            //concesionario.EliminarCoche(c3);
            //concesionario.EliminarCoche(c4);

            //Console.WriteLine("Coches");
            //concesionario.MostrarCoches();

            //Console.WriteLine("añadir otro mas");
            //concesionario.AddCoche(c3);

            //Console.WriteLine("Coches");
            //concesionario.MostrarCoches();

            //Console.WriteLine("Vacio");
            //concesionario.vaciarCoches();
            //concesionario.MostrarCoches();




            //Console.Write("Indique la opcion que desea realizar: ");
            //Console.Write("1. Retirar\n2. Depositar\n3. Ver saldo \n4. Salir");
            //int opcion = 0;
            //do
            //{
            //    switch (opcion)
            //    {
            //        case 1:
            //            Console.Write("Ingrese la cantidad que quiere retirar");
            //            int cantidad = Convert.ToInt32(Console.ReadLine());
            //            cliente1.retirarDinero(cantidad);
            //            break;
            //        case 2:


            //    }
            //} while (opcion!=0);



            //    List<INotificacion> notificaciones = new List<INotificacion>
            //{
            //    new Email(),
            //    new SMS(),
            //};
            //    foreach (var n in notificaciones)
            //    {
            //        n.Enviar("Hola Master desarrollo");

            //    }
            //    Console.ReadKey();
        }
    }
}
