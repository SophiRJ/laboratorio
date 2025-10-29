using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miTiendaDbProject
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
                context.Clients.Add(new Clients { CompanyName = "Tech Solutions", Adress = "123 Main Street, New York", Phone = "+1-555-1001" });
                context.Clients.Add(new Clients { CompanyName = "Innovatech Corp", Adress = "742 Evergreen Terrace, Springfield", Phone = "+1-555-2002" });
                context.Clients.Add(new Clients { CompanyName = "Global Traders", Adress = "99 Market Road, San Francisco", Phone = "+1-555-3003" });
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
    public class Program
    {
        static void CargarDatos()
        {
            using (var context = new Model1Container())
            {
                DataSeeder.Seed(context);

                Console.WriteLine("Datos cargados correctamente...");
                Console.WriteLine("Comprueba base de datos");
                var grupacion = (from od in context.Orders
                                 group od by od.Clients.CompanyName into grupo
                                 orderby grupo.Key descending
                                 select grupo).ToList();
            }

        }

        static void Main(string[] args)
        {
            CargarDatos();

            //CONSULTAS
            using (var context = new Model1Container()) {
                var data = context.Clients
                        .Select(c => new
                        {
                            Cliente = c.CompanyName,
                            Direccion = c.Adress,
                            Telefono = c.Phone
                        }).ToList();
            } 

        }
    }
}
