using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjLecturaCSV
{
    class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string rutaArchivo = "productos.csv";
            List<Producto> productos= new List<Producto>();

            try
            {
                using (StreamReader sr = new StreamReader(rutaArchivo))
                {
                    string linea;
                    bool primeraLinea = true;

                    while ((linea = sr.ReadLine()) != null){
                        if (primeraLinea)
                        {
                            primeraLinea = false;
                            continue;
                        }
                        string[] columnas = linea.Split(',');
                        Producto producto = new Producto()
                        {
                            Id = int.Parse(columnas[0]),
                            Nombre = columnas[1],
                            Categoria = columnas[2],
                            Precio = double.Parse(columnas[3]),
                            Stock = int.Parse(columnas[4]),
                        };
                        productos.Add(producto);
                    }
                }
                //Filto por categoria
                Console.WriteLine("Precios filtrados por categoria");
                Dictionary<string, double> valorPorCategoria = new Dictionary<string, double>();
                double totalPrecioCategoria=0;
                foreach (var producto in productos) 
                {
                    totalPrecioCategoria = producto.Precio * producto.Stock;
                    if (valorPorCategoria.ContainsKey(producto.Categoria))
                    {
                        valorPorCategoria[producto.Categoria] += totalPrecioCategoria;
                    }
                    else
                    {
                        valorPorCategoria[producto.Categoria] = totalPrecioCategoria;
                    }
                }
                foreach(var dic in valorPorCategoria)
                {
                    Console.WriteLine($"{dic.Key} -Valor total: {dic.Value:0.00}");
                }
                

                //Mayor y Meor precio por categoria
                Dictionary<string, Producto> masCaroPorCategoria = new Dictionary<string, Producto>();
                Dictionary<string, Producto> masBaratoPorCategoria = new Dictionary<string, Producto>();
                
                
                foreach (var producto in productos)
                {
                    if (!masBaratoPorCategoria.ContainsKey(producto.Categoria)&& !masCaroPorCategoria.ContainsKey(producto.Categoria))
                    {
                        masBaratoPorCategoria[producto.Categoria] = producto;
                        masCaroPorCategoria[producto.Categoria] = producto;
                    }
                    else if(producto.Precio> masCaroPorCategoria[producto.Categoria].Precio)
                    {
                        masCaroPorCategoria[producto.Categoria]=producto;
                    }else if(producto.Precio< masBaratoPorCategoria[producto.Categoria].Precio)
                    {
                        masBaratoPorCategoria[producto.Categoria] = producto;
                    }
                }
                Console.WriteLine("Productos mas baratos por categoria");
                foreach(var dic in masBaratoPorCategoria)
                {
                    Console.WriteLine($"{dic.Key} - Valor {dic.Value.Precio:0:00}");
                }
                Console.WriteLine("Productos mas caros por categoria");
                foreach (var dic in masCaroPorCategoria)
                {
                    Console.WriteLine($"{dic.Key} - Valor {dic.Value.Precio:0:00}");
                }


                //Escribir
                string rutaSalida = "inventario_resultados.csv";
                using (StreamWriter sw = File.CreateText(rutaSalida))
                {
                    sw.WriteLine("Categoria,ValorTotal,ProductoMasBarato,PrecioMasBarato,ProductoMasCaro,PrecioMasCaro");
                    foreach (var categoria in valorPorCategoria.Keys)
                    {
                        string linea = $"{categoria},{valorPorCategoria[categoria]:0.00}," +
                                       $"{masBaratoPorCategoria[categoria].Nombre},{masBaratoPorCategoria[categoria].Precio:0.00}," +
                                       $"{masCaroPorCategoria[categoria].Nombre},{masCaroPorCategoria[categoria].Precio:0.00}";
                        sw.WriteLine(linea);
                    }
                }

                Console.WriteLine("\nResumen guardado en inventario_resultados.csv");

            }
            catch (Exception ex) { 
            Console.WriteLine(ex.ToString());
            }
        }
    }
}
