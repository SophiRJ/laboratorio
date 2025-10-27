using System;

namespace GestorVehiculos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Empresa empresa = new Empresa();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n=== MENÚ VEHÍCULOS ===");
                Console.WriteLine("1. Agregar Vehiculo");
                Console.WriteLine("2. Mostrar Lista");
                Console.WriteLine("3. Salir");
                Console.Write("Elige una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        empresa.agregarVehiculo();
                        break;

                    case "2":
                        empresa.mostrarLista(empresa.lista);
                        break;

                    case "3":
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}

