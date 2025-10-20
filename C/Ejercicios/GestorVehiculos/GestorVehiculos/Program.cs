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
                Console.WriteLine("1. Agregar Auto");
                Console.WriteLine("2. Agregar Moto");
                Console.WriteLine("3. Agregar Camión");
                Console.WriteLine("4. Mostrar Lista");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("\n--- Nuevo Auto ---");
                        Auto a = new Auto("Toyota", "Corolla", 2022, "Blanco", 1200, 20000, 180, 4, 450, 0.10);
                        empresa.agregarVehiculo(a);
                        Console.WriteLine("Auto agregado correctamente.");
                        break;

                    case "2":
                        Console.WriteLine("\n--- Nueva Moto ---");
                        Moto m = new Moto("Yamaha", "MT-07", 2021, "Negra", 180, 7500, 220, "Deportiva", 689, true);
                        empresa.agregarVehiculo(m);
                        Console.WriteLine("Moto agregada correctamente.");
                        break;

                    case "3":
                        Console.WriteLine("\n--- Nuevo Camión ---");
                        Camion c = new Camion("Volvo", "FH16", 2020, "Azul", 8000, 95000, 140, 18, 3, true);
                        empresa.agregarVehiculo(c);
                        Console.WriteLine("Camión agregado correctamente.");
                        break;

                    case "4":
                        Console.WriteLine();
                        empresa.mostrarLista();
                        break;

                    case "5":
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

