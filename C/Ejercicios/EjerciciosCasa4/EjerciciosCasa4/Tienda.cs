using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    internal class Tienda
    {
        public List<Productot> Productos { get; set; }
        public Tienda()
        {
            Productos = new List<Productot>();
        }
        public void agregarProducto(Productot producto)
        {
            Productos.Add(producto);
        }
        public void ListarProductos()
        {
            foreach (Productot producto in Productos)
            {
                
                Console.WriteLine("Prducto: {0}, Categoria:{1}, Precio:{2}"
                    , producto.Nombre, producto.Categoria, producto.Precio);
            }
        }
        public void BuscarPorNombre(string nombreProducto)
        {
            foreach (Productot producto in Productos)
            {
                if (producto.Nombre.ToLower() == nombreProducto.ToLower())
                {
                    Console.WriteLine("PRoducto encontrado: Nombre{0}-Categoria{1}-Precio{2}",producto.Nombre,producto.Categoria,producto.Precio);
                }
            }

        }
    }
}
