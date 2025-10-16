using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioClase3._6
{
    /*Crear un programa que contenga la clase ‘Concatena.cs’ con dos atributos “nombre” y “apellido”
         * . Tendrá un constructor que recibirá esos dos parámetros y un método “concatenar” que
         * devolverá (return) el nombre correctamente concatenado al apellido”. Crear, asi mismo,
         * una clase program.cs cuyo Mainpedirá 
         * el nombre y el apellido del usuario e imprimirá por pantalla el nombre concatenado.*/
    /*(3.7). Crear un programa que contenga la clase ‘Estadística.cs’ cuyo constructor recibirá
     * tres números enteros y dos métodos “suma”  y “media” que devolverán la suma y la media respectivamente.
⦁Crear, así mismo, una clase program.cs cuyo 
    Mainpedirá los tres números al usuario e imprimirá por pantalla los valores resultantes.*/
    internal class Program
    {
        public class Concatena
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }

            public Concatena(string _nomb, string _apell)
            {
                Nombre = _nomb;
                Apellido = _apell;
            }
            public string NombreCompleto()
            {
                return string.Format($"{Apellido}, {Nombre}"); 
            } 
        }
        public class Estadistica
        {
            public int numero1 { get; set; }
            public int numero2 { get; set; }
            public int numero3 { get; set; }

            public Estadistica(int _numero1, int _numero2, int _numero3)
            {
                numero1= _numero1;
                numero2= _numero2;
                numero3= _numero3;
            }
            public int suma()
            {
                return numero1 + numero2 + numero3;
            }
            public double media()
            {
                return (numero1 + numero2 + numero3) / 3;
            }
        }
        
        static void Main(string[] args)
        {
            //Console.Write("Escribe el nombre: ");
            //string nombre = Console.ReadLine();
            //Console.Write("Escribe el apellido: ");
            //string apellido = Console.ReadLine();
            //Concatena persona = new Concatena(nombre,apellido);
            //Console.WriteLine(persona.NombreCompleto());

            Console.WriteLine("Primer numero: ");
            int primerN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Segundo numero: ");
            int segundoN = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Tercer numero: ");
            int tercerN = Convert.ToInt32(Console.ReadLine());


            Estadistica estadistica1= new Estadistica(primerN,segundoN, tercerN);
            Console.WriteLine($"La suma es {estadistica1.suma()}");
            Console.WriteLine($"La media es {estadistica1.media()}");
        }
    }
}
