using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Listas
{
    internal class Program
    {
        public static List<Producto> productos=new List<Producto>();
        public static int contadorId = 1;
        static void Main(string[] args)
        {
            //Tablas Hash
            // Dictionry<TKey,TValue>

            Dictionary<string, int> edades=new Dictionary<string, int>();
            edades.Add("Andres", 35);
            edades.Add("Luis", 28);

            //si existe una determinada clave
            if (edades.ContainsKey("Ana"))
            {
                Console.WriteLine("Encontrado");

            }

            foreach(var valores in edades)
            {
                Console.WriteLine($"{valores.Key} - {valores.Value}");
            }



            //int opcion;
            //do
            //{
            //    Console.Clear();//limpiar consola
            //    Console.WriteLine("Gestion de productos");
            //    Console.WriteLine("1, Agregar producto");
            //    Console.WriteLine("2. Listar Productos");
            //    Console.WriteLine("3. Editar producto");
            //    Console.WriteLine("4.Eliminar producto");
            //    Console.WriteLine("0. Salir");

            //    Console.Write("Elige una opcion..");
            //    //opcion= Convert.ToInt32(Console.ReadLine()); 

            //    //si no logras parsear el string a int devuelveme un -1
            //    if(!int.TryParse(Console.ReadLine(), out opcion))//intenta parsear string a int si no lo consigue devuelve false 
            //        //en este caso lo estoy dando la vuelta !devulve true por q quiero q se ejecute el if y devuelva un -1
            //    {
            //        opcion = -1;
            //    }

            //    switch (opcion)
            //    {
            //        case 1:
            //            Producto.Agregar();
            //            break;
            //        case 2:
            //            Producto.Listar();
            //            break;
            //        case 3:
            //            Producto.Editar();
            //            break;
            //        case 4:
            //            Producto.Eliminar();
            //            break;
            //        case 0: Console.WriteLine("Saliendo..");
            //            Console.ReadKey();
            //            break;
            //        default: Console.WriteLine("Opcion no valida.Intenta de nuevo");
            //            Console.ReadKey();
            //            break;
                    
            //    }
            //} while (opcion != 0);




            //List<int> listaEnteros= new List<int>();
            //listaEnteros.Add(1); 
            //listaEnteros.Add(2);
            //listaEnteros.Add(3);
            //listaEnteros.Add(4);

            //foreach (var item in listaEnteros)
            //{
            //    Console.WriteLine(item);
            //}
            

            //List<Person> listaPersonas= new List<Person>();
            //Person persona=new Person();
            //persona.Id = 1;
            //persona.Name = "Ana";

            //listaPersonas.Add(persona);

            //listaPersonas.Add(new Person { Id=2,Name="Kike"});
            //foreach (Person person in listaPersonas) 
            //{
            //    Console.WriteLine(person.Name);
            
            //}

            //List<Empleado> listaEmpleados = new List<Empleado>
            //{
            //    new Empleado { Nombre = "Lucía", Departamento = "IT", Salario = 3200 },
            //    new Empleado { Nombre = "Carlos", Departamento = "Ventas", Salario = 2800 },
            //    new Empleado { Nombre = "Sofía", Departamento = "IT", Salario = 3500 },
            //    new Empleado { Nombre = "Pedro", Departamento = "RRHH", Salario = 2500 }
            //};

            //foreach(Empleado empleado in listaEmpleados)
            //{
            //    Console.WriteLine($"Nombre: {empleado.Nombre}- Salario: {empleado.Salario}");
            //}
            Console.ReadKey();
        }

        
    }
}
