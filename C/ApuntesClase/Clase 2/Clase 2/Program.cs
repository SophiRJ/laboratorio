using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_2
{
    internal class Program
    {

        //para crear funciones -> lo estatico no necesito generare una instancia del objeto para usarlo

        public static void saludar()
        {
            Console.WriteLine("Hola al programa");
            Console.WriteLine(" de ejmeplo");
            Console.WriteLine("saudos");
        }
        public static void escribeNumeroReal(float n)
        {
            Console.WriteLine(n.ToString("#.###"));
        }
        public static void escribeSuma(int x, int y)
        {
            int suma = x + y;
            Console.WriteLine(suma.ToString());
        }
        public static int cuadrado(int x)
        {
            return x * x;
        }
        public static void duplicar(ref int x)
        {
            Console.WriteLine($"El valor recibido vale {x}");
            x = x * 2;
            Console.WriteLine($"Ahora vale {x}");
        }

        static void Main(string[] args)
        {

            //llamada funciones
            saludar();
            escribeNumeroReal(2.3f);//sufijo f
            escribeSuma(3, 5);
            int resultado = cuadrado(5);
            //Por referencia cambia el valor original
            int n = 5;
            Console.WriteLine($"n vale{n}");
            duplicar(ref n);//cuando la llmas tb pasar ref
            Console.WriteLine($"Ahora n vale {n}");



            //string Texto = "Hola";
            //Texto += "mundo";
            //Texto += "!";


            //string texto = "";
            //for(int i = 0; i < 10000; i++)//aqui construimos 10000 strings diferentes
            //{
            //    texto += i.ToString();
            //}
            //StringBuilder sb = new StringBuilder();//solo usa un string
            //for(int i = 0; i < 10000; i++)
            //{
            //    sb.Append(i);
            //}
            //string texto2 = sb.ToString(); //convertirlo a string

            //int[] diasMes = { 31,12,24};
            //foreach(int dias in diasMes)
            //{
            //    Console.WriteLine("Disa del mes:{0}", dias);
            //}

            //string[] nombres = { "Alberto", "Jesus", "Maria" };
            //foreach(string nombre in nombres)
            //{
            //    Console.WriteLine(nombre);
            //}

            //string saludo = "hola";
            //foreach(char i in saludo)
            //{
            //    Console.WriteLine(i);
            //}

            //Funciones



            Console.ReadKey();

        }
    }
}
