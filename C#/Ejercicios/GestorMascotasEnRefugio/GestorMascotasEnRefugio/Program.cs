using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestorMascotasEnRefugio
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Mascota> animales = new List<Mascota>();
            int opcion=0;
            do
            {
                Console.WriteLine("Escoja una opcion: " +
                    "\n1. Registrar mascota" +
                    "\n2. Listar mascotas" +
                    "\n3. Mostrar Detalles de una mascota" +
                    "\n4. Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Program.Registro(animales);
                        break;
                    case 2:
                        Program.Listar(animales);
                        break;
                    case 3:
                        Program.MostrarDetalle(animales);
                        break;
                    case 4:
                        Console.WriteLine("Saliendo..");
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;
                }
            } while (opcion != 4);
        }

        public static void Registro(List<Mascota> lista)
        {
            string nombre;
            string tipo;
            int edad;
            double peso;
            string raza;
            int nivelAct;
            bool domestico;
            bool esterilizado;
            bool vuela;
            string especie;

            Console.WriteLine("Indique que animal quiere registrar:" +
                        "\n1-> Perro\n2-> Gato\n3-> Ave");
            int dato = Convert.ToInt32(Console.ReadLine());
            if (dato <= 0 || dato > 3)
            {
                Console.WriteLine("Eleccion invalida");
                return;
            }
            Console.Write("Nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Tipo: ");
            tipo = Console.ReadLine();
            Console.Write("Edad: ");
            edad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Peso: ");
            peso = Convert.ToDouble(Console.ReadLine());
            Mascota nuevaM = null;
            switch (dato)
            {
                case 1:
                    Console.Write("Raza: ");
                    raza = Console.ReadLine();
                    Console.Write("Nivel de actividad(1-10): ");
                    nivelAct = Convert.ToInt32(Console.ReadLine());
                    if (nivelAct > 10 || nivelAct < 1)
                    {
                        Console.WriteLine("Dato invalido");
                        Console.ReadKey();
                        return;
                    }
                    nuevaM=new Perro(nombre, tipo, edad, peso, raza, nivelAct);
                    break;
                case 2:
                    Console.Write("Esterilizado?: (s/n) ");
                    string respuesta = Console.ReadLine();
                    esterilizado = (respuesta == "s") ? true : false;
                    Console.Write("domestico?: (s/n) ");             
                    respuesta = Console.ReadLine();
                    domestico = (respuesta == "s") ? true : false;
                    nuevaM= new Gato(nombre, tipo, edad, peso, esterilizado, domestico);
                    
                    break;
                case 3:
                    Console.Write("Especie: ");
                    especie = Console.ReadLine();
                    Console.Write("Vuela?: (s/n) ");
                    respuesta = Console.ReadLine();
                    vuela = (respuesta == "s") ? true : false;
                    nuevaM=new Ave(nombre, tipo, edad, peso, especie, vuela);
                    break;
            }
            if (nuevaM != null)
            {
                lista.Add(nuevaM);
                Console.WriteLine($"Animal {nombre} registrado correctamente.");

                nuevaM.Vacunar();
                Console.WriteLine("Vacunación completada");
            }

            
        }
        public static void Listar(List<Mascota> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("La lista esta vacia.");
                return;
            }
           foreach (Mascota m in lista)
            { 
                Console.WriteLine(m.nombre);
            }
        }
        public static void MostrarDetalle(List<Mascota> lista)
        {
            Console.WriteLine("Indique el nombre de la mascota: ");
            
            string resp= Console.ReadLine().ToLower();
            foreach (Mascota m in lista)
            {
                if(m.nombre.ToLower()== resp)
                {
                    Console.WriteLine("Deseas ver la datos generales o detallados? (g/d)");
                    resp = Console.ReadLine();
                    bool detallada = resp == "g" ? false : true;
                    if (detallada)
                    {
                        m.MostrarInfo(detallada);
                    }
                    else
                    {
                        m.MostrarInfo();
                    }
                }
                else
                {
                    Console.WriteLine("El animal no esta registrado");
                }                    
            }   
       }
    }
}




