using System;

namespace Listas
{
    internal class Producto
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public static void Agregar()
        {
            Console.WriteLine("Nombre Producto: ");
            string nombre=Console.ReadLine();

            Console.WriteLine("Precio Producto: ");
            if(!decimal.TryParse(Console.ReadLine(), out decimal precio))
            {
                Console.WriteLine("Precio no valido");
                Console.ReadKey();
                return;
            }
            

            Program.productos.Add(new Producto { id=Program.contadorId,Nombre=nombre,Precio=precio});
            Program.contadorId++;
        
        }
        public static void Listar()
        {
            Console.Clear();
            Console.WriteLine("Lista d productos");

            if (Program.productos.Count == 0)
            {
                Console.WriteLine("No hay productos");
            }
            else
            {
                foreach (Producto p in Program.productos)
                {
                    Console.WriteLine($"id: {p.id} Nombre: {p.Nombre}- Precio: {p.Precio}");
                }
                Console.WriteLine("\nPresione un tecla para continuar");
                Console.ReadKey();
            }
        }
        public static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Editar Producto");
            Console.Write("Ingrese el ID del producto");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("id no valido");
                Console.ReadKey();
                return;
            }
            Producto productoEncontrado = null;
            foreach (Producto p in Program.productos)
            {
                if (p.id == id)
                {
                    productoEncontrado = p;
                    break;
                }
            }
            if (productoEncontrado == null)
            {
                Console.WriteLine("Producto no encontrado");
            }
            else 
            {
                Console.Write($"{productoEncontrado.Nombre}");   
                productoEncontrado.Nombre= Console.ReadLine();

                Console.Write($"{productoEncontrado.Precio}");
                if (decimal.TryParse(Console.ReadLine(), out decimal precio))
                {
                    productoEncontrado.Precio = precio;
                    Console.WriteLine("Producto actualizado correctamente");

                }
                else
                {
                    Console.WriteLine("Precio no valido. No se realizaron cambios");
                }
                    productoEncontrado.Nombre = Console.ReadLine();
            }
        }
        public static void Eliminar()
        {
            Console.Clear();
            Console.WriteLine("Eliminar Producto");
            Console.Write("Ingrese el ID del producto");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("id no valido");
                Console.ReadKey();
                return;
            }
            int indiceAEliminar = -1;
            for(int i = 0; i < Program.productos.Count; i++)
            {
                if (Program.productos[i].id == id)
                {
                    indiceAEliminar = i;
                    break;
                }
            }
            if (indiceAEliminar != -1) {
                Program.productos.RemoveAt(indiceAEliminar);
                Console.WriteLine("Producto eliminado");
            }
            else
            {
                Console.WriteLine("Producto no encontrado");
            }
            Console.ReadKey();
        }
    }
}
