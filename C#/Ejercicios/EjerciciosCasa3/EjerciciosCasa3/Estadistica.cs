using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa3
{
    internal class Estadistica
    {
        public int[] Numeros { get; set; }
        

        public Estadistica(int numero1, int numero2, int numero3)
        {
            Numeros = new int[] { numero1, numero2, numero3 };
            
        }
        public int sumar()
        {
            int suma = 0;
            foreach (int n in Numeros) {
                suma += n;
            }
            return suma;
        }
        public void media()
        {
            Console.WriteLine($"La media es {sumar() / Numeros.Length}");
        }
    }
}
