using FacturacionApp.Data;
using FacturacionApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace FacturacionApp
{
    public  static class DataSeeder
    {
        public static void Seed(AppDBContext context)
        {
            // Comprobar si ya hay datos
            if (!context.Clients.Any())
            {
                var client1 = new Client { FirstName = "Ana", LastName = "Pérez" };
                var client2 = new Client { FirstName = "Juan", LastName = "López" };

                var project1 = new Project
                {
                    Title = "Proyecto A",
                    StartDate = DateTime.Now.AddMonths(-3),
                    EndDate = DateTime.Now.AddMonths(3),
                    Client = client1
                };

                var project2 = new Project
                {
                    Title = "Proyecto B",
                    StartDate = DateTime.Now.AddMonths(-1),
                    EndDate = DateTime.Now.AddMonths(5),
                    Client = client2
                };

                var invoice1 = new Invoice { AmountDue = 1500, DueDate = DateTime.Now.AddDays(30), Project = project1 };
                var invoice2 = new Invoice { AmountDue = 2500, DueDate = DateTime.Now.AddDays(45), Project = project2 };

                context.AddRange(client1, client2, project1, project2, invoice1, invoice2);
                context.SaveChanges();
            }

        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
           //CrearDatos();
            //Consultas
            //1. Obtener todos los clientes
            //Clientes();
            //2. Obtener proyectos de un cliente especifico
            //Proyectos_Cliente_Especifico();
            //3. Obtener facturas vencidas
            //Facturas_Vencidas();
            //4. Obtener clientes con Proyectos
            Clientes_Proyectos();

        }

        private static void Clientes_Proyectos()
        {
            using (var context = new AppDBContext())
            {
                var query4 = (from c in context.Clients
                              where c.Projects.Count() > 0
                              select new
                              {
                                  Cliente = c.FirstName + " " + c.LastName,
                                  Pedidos = c.Projects.ToList()

                              }).ToList();
                foreach (var p in query4)
                {
                    Console.WriteLine($"{p.Cliente}");
                    foreach (var p2 in p.Pedidos)
                    {
                        Console.WriteLine($"{p2.EndDate.ToShortDateString()} {p2.StartDate.ToShortDateString()} {p2.Title}");
                    }
                }

                var clientesPorProyectos = context.Clients
                    .Include(c => c.Projects)
                    .ThenInclude(p => p.Invoices).ToList();

                foreach (var cliente in clientesPorProyectos)
                {
                    Console.WriteLine($"Cliente: {cliente.FirstName} {cliente.LastName}");
                    foreach(var projecto in cliente.Projects)
                    {
                        Console.WriteLine($"Proyecto: {projecto.Title}");
                        foreach(var invoice in projecto.Invoices)
                        {
                            Console.WriteLine($"Factura: {invoice.AmountDue} Vence: {invoice.DueDate.ToShortDateString()}");
                        }
                    }
                   
                }
            }
        }

        private static void Facturas_Vencidas()
        {
            using (var context = new AppDBContext())
            {
                var query3 = (from i in context.Invoices
                              where i.DueDate < DateTime.Now
                              select new
                              {
                                  Proyecto = i.Project.Title,
                                  Cliente = i.Project.Client.FirstName + " " + i.Project.Client.LastName,
                                  Monto = i.AmountDue,
                                  FechaVencimiento = i.DueDate,
                                  //DiasVencida = (DateTime.Now - i.DueDate).Days
                              }).ToList();
                foreach ( var f in query3)
                {
                    Console.WriteLine(
                       $"Cliente: {f.Cliente}, Proyecto: {f.Proyecto} | " +
                       $"Vencimiento: {f.FechaVencimiento:d} | " +
                       $"Monto: {f.Monto:C}"
                        );
                }
            }
        }

        private static void Proyectos_Cliente_Especifico()
        {
            using (var context = new AppDBContext())
            {
                var query2 = (from p in context.Projects
                              where p.ClientID == 2
                              select new
                              {
                                  Proyecto = p.Title,
                                  FechaInicio = p.StartDate,
                                  FechaFin = p.EndDate
                              }).ToList();
            }
        }

        private static void Clientes()
        {
            using (var context = new AppDBContext())
            {
                var query1 = (from c in context.Clients
                              select c).ToList();
            }

        }

        private static void CrearDatos()
        {
            using (var context = new AppDBContext())
            {
                DataSeeder.Seed(context);
                Console.WriteLine("Cargando datos...");
                Console.ReadKey();
            }
        }
    }
}
