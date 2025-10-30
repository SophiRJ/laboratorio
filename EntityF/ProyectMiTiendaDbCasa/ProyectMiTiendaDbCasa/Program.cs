using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ProyectMiTiendaDbCasa
{
    public static class DataSeeder
    {
        public static void Seed(Model1Container context)
        {
            // === Productos ===
            if (!context.Products.Any())
            {
                context.Products.Add(new Products { ProductName = "Laptop Dell XPS 13", UnitPrice = 1200 });
                context.Products.Add(new Products { ProductName = "iPhone 15", UnitPrice = 999 });
                context.Products.Add(new Products { ProductName = "Smartwatch Samsung", UnitPrice = 299 });
                context.Products.Add(new Products { ProductName = "Auriculares Sony WH-1000XM5", UnitPrice = 399 });
                context.SaveChanges();
            }
            // === Clientes ===
            if (!context.Clients.Any())
            {
                context.Clients.Add(new Clients { CompanyName = "Tech Solutions", Address = "123 Main Street, New York", Phone = "+1-555-1001" });
                context.Clients.Add(new Clients { CompanyName = "Innovatech Corp", Address = "742 Evergreen Terrace, Springfield", Phone = "+1-555-2002" });
                context.Clients.Add(new Clients { CompanyName = "Global Traders", Address = "99 Market Road, San Francisco", Phone = "+1-555-3003" });
                context.SaveChanges();
            }
            // === Pedidos ===
            if (!context.Orders.Any())
            {
                // Recuperar las entidades para usar sus IDs y referencias
                var products = context.Products.ToList();
                var clients = context.Clients.ToList();
                var laptop = products.First(p => p.ProductName.Contains("Laptop"));
                var iphone = products.First(p => p.ProductName.Contains("iPhone"));
                var smartwatch = products.First(p => p.ProductName.Contains("Smartwatch"));
                var auriculares = products.First(p => p.ProductName.Contains("Auriculares"));
                var techSolutions = clients.First(c => c.CompanyName == "Tech Solutions");
                var innovatech = clients.First(c => c.CompanyName == "Innovatech Corp");
                var globalTraders = clients.First(c => c.CompanyName == "Global Traders");
                // Crear órdenes con FK + navegación
                var orders = new List<Orders>
            {
                new Orders { Quantity = 3, Client = techSolutions.Id_Client, Product = laptop.Id_Product, Clients = techSolutions, Products = laptop },
                new Orders { Quantity = 5, Client = techSolutions.Id_Client, Product = auriculares.Id_Product, Clients = techSolutions, Products = auriculares },
                new Orders { Quantity = 2, Client = innovatech.Id_Client, Product = iphone.Id_Product, Clients = innovatech, Products = iphone },
                new Orders { Quantity = 10, Client = globalTraders.Id_Client, Product = smartwatch.Id_Product, Clients = globalTraders, Products = smartwatch }
            };
                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
        }
    }
    internal class Program
    {
        static void CargarDatos()
        {
            using (var context = new Model1Container())
            {
                DataSeeder.Seed(context);
                Console.WriteLine("Datos cargados correctamente. Compruebe base de datos");

            }
        }
        static void Main(string[] args)
        {
            //CargarDatos();
            //using (var context = new Model1Container())
            //{
            //    DataSeeder.Seed(context);
            //}

            //    Console.WriteLine("Datos iniciales insertados correctamente.");

            //Consultas
            //VerClientes();
            //VerPedidos();
            //Productos_Mas_500();
            //Clientes_Con_Pedidos();
            TotalPedidosPorCliente();
            TotalPorCliente();
            ProductoMasVendido();
            MejorCliente();
        }

        private static void MejorCliente()
        {
            using (var context = new Model1Container())
            {
                var data = (from c in context.Clients
                            join o in context.Orders
                            on c.Id_Client equals o.Client
                            join p in context.Products
                            on o.Product equals p.Id_Product
                            group new { o, p } by c.CompanyName into g
                            orderby g.Sum(x => x.o.Quantity * x.p.UnitPrice) descending
                            select new
                            {
                                Cliente = g.Key,
                                TotalComprado = g.Sum(x => x.o.Quantity * x.p.UnitPrice)
                            }).FirstOrDefault();
            }
        }

        private static void ProductoMasVendido()
        {
            using (var context = new Model1Container())
            {
                var data = (from o in context.Orders
                            join p in context.Products
                            on o.Product equals p.Id_Product
                            group o.Quantity by p.ProductName into g
                            orderby g.Sum() descending
                            select new
                            {
                                producto = g.Key,
                                ventas = g.Sum()
                            }).FirstOrDefault();
            }
        }

        private static void TotalPorCliente()
        {
            using (var context = new Model1Container())
            {
                var data = (from o in context.Orders
                            join p in context.Products
                            on o.Product equals p.Id_Product
                            group o.Quantity * p.UnitPrice by o.Client into g
                            select new
                            {
                                Cliente = g.Key,
                                Total = g.Sum()
                            }).OrderByDescending(o => o.Total).ToList();

            }
        }

        private static void TotalPedidosPorCliente()
        {
            using (var context = new Model1Container())
            {
                var data = (from o in context.Orders
                            group o by o.Client into grupo
                            select new
                            {
                                Cliente = grupo.Key,
                                Pedidos = grupo.Sum(x=>x.Quantity)//x=o-> al campo agrupado
                                                                   //si agrupamos varios campos x= todos los campos 
                            }).ToList();
                
            }
        }

        private static void Clientes_Con_Pedidos()
        {
            using (var context = new Model1Container())
            {
                var data = (from c in context.Clients
                           join o in context.Orders
                           on c.Id_Client equals o.Client
                           select c.CompanyName).Distinct().ToList();
            }
        }

        private static void Productos_Mas_500()
        {
            using (var context = new Model1Container())
            {
                var data= (from p in context.Products
                          where p.UnitPrice>500
                          select p).ToList();
            }
        }

        private static void VerPedidos()
        {
            //Listado de pedidos con nombre de producto, agrupados por cliente
            using (var context = new Model1Container()) 
            {
                var data = (from o in context.Orders
                            group o by o.Clients.CompanyName into grupo
                            orderby grupo.Key descending
                            select grupo).ToList();
            }
        }

        private static void VerClientes()
        {
            //Listado de clientes
            using (var context = new Model1Container()) {
                var data = context.Clients
                    .Select(c => new
                    {
                        Cliente = c.CompanyName,
                        Direccion = c.Address,

                    }).ToList();
            }
        }
    }
}
