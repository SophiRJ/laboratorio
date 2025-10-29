using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioLinqClase
{
    public static class DataSeeder
    {
        public static void Seed(Model2Container context)
        {
            // === Productos ===
            if (!context.Productos.Any())
            {
                context.Productos.Add(new Producto { ProductName = "Laptop Dell XPS 13", UnitPrice = 1200 });
                context.Productos.Add(new Producto { ProductName = "iPhone 15", UnitPrice = 999 });
                context.Productos.Add(new Producto { ProductName = "Smartwatch Samsung", UnitPrice = 299 });
                context.Productos.Add(new Producto { ProductName = "Auriculares Sony WH-1000XM5", UnitPrice = 399 });
                context.SaveChanges();
            }

            // === Clientes ===
            if (!context.Clientes.Any())
            {
                context.Clientes.Add(new Cliente { CompanyName = "Tech Solutions", Address = "123 Main Street, New York", Phone = "+1-555-1001" });
                context.Clientes.Add(new Cliente { CompanyName = "Innovatech Corp", Address = "742 Evergreen Terrace, Springfield", Phone = "+1-555-2002" });
                context.Clientes.Add(new Cliente { CompanyName = "Global Traders", Address = "99 Market Road, San Francisco", Phone = "+1-555-3003" });
                context.SaveChanges();
            }

            // === Órdenes ===
            if (!context.Ordenes.Any())
            {
                // Recuperar las entidades para usar sus IDs y referencias
                var products = context.Productos.ToList();
                var clients = context.Clientes.ToList();

                var laptop = products.First(p => p.ProductName.Contains("Laptop"));
                var iphone = products.First(p => p.ProductName.Contains("iPhone"));
                var smartwatch = products.First(p => p.ProductName.Contains("Smartwatch"));
                var auriculares = products.First(p => p.ProductName.Contains("Auriculares"));

                var techSolutions = clients.First(c => c.CompanyName == "Tech Solutions");
                var innovatech = clients.First(c => c.CompanyName == "Innovatech Corp");
                var globalTraders = clients.First(c => c.CompanyName == "Global Traders");

                // Crear órdenes con FK + navegación correctas
                var orders = new List<Orden>
                {
                    new Orden { Quantity = 3, Cliente = techSolutions.IdCliente, Producto = laptop.IdProducto, Cliente1 = techSolutions, Producto1 = laptop },
                    new Orden { Quantity = 5, Cliente = techSolutions.IdCliente, Producto = auriculares.IdProducto, Cliente1 = techSolutions, Producto1 = auriculares },
                    new Orden { Quantity = 2, Cliente = innovatech.IdCliente, Producto = iphone.IdProducto, Cliente1 = innovatech, Producto1 = iphone },
                    new Orden { Quantity = 10, Cliente = globalTraders.IdCliente, Producto = smartwatch.IdProducto, Cliente1 = globalTraders, Producto1 = smartwatch }
                };

                context.Ordenes.AddRange(orders);
                context.SaveChanges();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            //using (var context = new Model1Container())
            //{
            //    DataSeeder.Seed(context);
            //}

            //Console.WriteLine("Datos iniciales insertados correctamente.");

            //CONSULTAS 
            VerClientes();

            VerPedidos();

            ProductosMas500();

            ClientesConPedidos();
            TotalPedidoClientes();
            TotalCliente();
            ProductMasVendido();
            MejorCliente();

        }
        private static void VerPedidos()
        {
            //Listado de pedidos con nombre de producto, cantidad agrupados por cliente
            using (var context = new Model2Container())
            {
                var agrupacion = (from od in context.Ordenes
                                  group od by od.Cliente1.CompanyName into grupo
                                  orderby grupo.Key descending
                                  select grupo).ToList();


            }
        }

        private static void VerClientes()
        {
            using (var context = new Model2Container())
            {
                var data = context.Clientes
                    .Select(c => new
                    {

                        CLIENTE = c.CompanyName,
                        DIRECCION = c.Address,
                        TELEFONO = c.Phone


                    }).ToList();

                foreach (var item in data)
                {
                    Console.WriteLine(item);
                }

            }
        }


        private static void ProductosMas500()
        {

            using (var context = new Model2Container())
            {
                var query = (from p in context.Productos
                             where p.UnitPrice > 500
                             select p).ToList();

            }


        }


        private static void ClientesConPedidos()
        {

            using (var context = new Model2Container())
            {


                var query = (from c in context.Clientes
                             join o in context.Ordenes
                             on c.IdCliente equals o.Cliente
                             select c.CompanyName
            ).Distinct();


            }
        }

        private static void TotalPedidoClientes()
        {

            using (var context = new Model2Container())
            {


                var query = (from o in context.Ordenes
                             group o by o.Cliente into g
                             select new
                             {
                                 NumeroCliente = g.Key,
                                 total = g.Sum(x => x.Quantity)
                             }).ToList();

            }
        }
        private static void TotalCliente()
        {
            using (var context = new Model2Container())
            {
                var query = (from o in context.Ordenes
                             join c in context.Clientes on o.Cliente equals c.IdCliente
                             join p in context.Productos on o.Producto equals p.IdProducto
                             group new { o, p } by c.CompanyName into g
                             select new
                             {
                                 cliente = g.Key,
                                 total = g.Sum(x => x.o.Quantity * x.p.UnitPrice)
                             }).ToList();
            }

            }
        private static void ProductMasVendido()
        {
            using(var context = new Model2Container())
            {
                var query = (from o in context.Ordenes
                             join p in context.Productos
                             on o.Producto equals p.IdProducto
                             group o by p.ProductName into g
                             orderby g.Sum(x => x.Producto) descending
                             select new
                             {
                                 producto = g.Key,
                                 ventas = g.Sum(x => x.Producto)
                             }).FirstOrDefault();
            }
        }
        private static void MejorCliente()
        {
            using (var context = new Model2Container())
            {
                var query = (from o in context.Ordenes
                             group o by o.Cliente1.CompanyName into g
                             orderby g.Sum(x => x.Quantity) descending
                             select new
                             {
                                 Cliente = g.Key,
                                 Total = g.Sum(x => x.Quantity)
                             }).FirstOrDefault();
            }
        }


    }
}

