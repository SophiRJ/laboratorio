using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    internal class Producto
    {
        public string  nombre { get; set; }
        public double precio { get; set; }
        public int stock {  get; set; }

        public Producto(string _nombre, double _precio)
        {
            nombre= _nombre;
            precio= _precio;
            stock = 100;
        }
        public void Ventas(int unidades)
        {
            if (unidades > stock)
            {
                Console.WriteLine("Sin stock");
            }
            else { stock -= unidades;
                Console.WriteLine("{0}, unidades vendidas:{1} stock: {2}", nombre, unidades, stock);
            }
           
        }
    }
}
