using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLinqSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cadena = ConfigurationManager.ConnectionStrings["NORTHWNDConnectionString"].ConnectionString;
            using (DataClasses1DataContext db = new DataClasses1DataContext(cadena))
            {
                //* Listado de clientes por ciudad:
                //Mostrar CustomerID, CompanyName, City.
                //Ordenar alfabéticamente por ciudad.

                //var query1 = db.Customers
                //    .OrderBy(c => c.City)
                //    .Select(c => new
                //    {
                //        Id = c.CustomerID,
                //        Nombre = c.CompanyName,
                //        Ciudad = c.City,
                //    }).ToList();
                //foreach (var c in query1) {
                //    Console.WriteLine($"{c.Id}. {c.Nombre}, {c.Ciudad}");
                //}
                //Console.ReadKey();

                //*Pedidos de un cliente específico
                //Pedir al usuario ingresar un CustomerID.
                //Listar todos sus pedidos(OrderID, OrderDate, ShipCountry).
                //Console.WriteLine("Ingresa un Cliente: ");
                //string Clienteid= Console.ReadLine();

                //var query2 = db.Orders
                //    .Where(o => o.CustomerID == Clienteid)
                //    .Select(o => new
                //    {
                //        id = o.OrderID,
                //        f_pedido = Convert.ToDateTime(o.OrderDate).ToShortDateString(),
                //        pais_envio = o.ShipCountry
                //    }).ToList();

                //foreach (var o in query2) {
                //    Console.WriteLine($"{o.id}, {o.f_pedido}, {o.pais_envio}");
                //}


                //*Productos más vendidos
                //Consultar la suma de Quantity por producto.
                //Mostrar los 5 productos más vendidos con ProductName y total vendido
                var query3 = db.Order_Details
                    .GroupBy(p => p.Products.ProductName)
                    .Select(p => new
                    {
                        Producto = p.Key,
                        Cantidad = p.Sum(o => o.Quantity)
                    })
                    .OrderByDescending(g => g.Cantidad)
                    .Take(5).ToList();

                //foreach (var item in query3)
                //{
                //    Console.WriteLine($"{item.Producto} {item.Cantidad}");
                //}

                //* Ventas por categoría
                //Realizar un join entre Products y Categories.
                //Mostrar el total de ventas por categoría(CategoryName, TotalSales).

                //var query4 = (from p in db.Products
                //              join c in db.Categories
                //              on p.CategoryID equals c.CategoryID
                //              group p.ProductID by c.CategoryName into g
                //              select new
                //              {
                //                  Nombre = g.Key,
                //                  TotalVentas = g.Sum()
                //              }).ToList();
                //foreach (var item in query4) {
                //    Console.WriteLine($"{item.Nombre}, {item.TotalVentas}");
                //}

                //* Empleados y su número de pedidos
                //Mostrar EmployeeName y cantidad de pedidos que gestionó.
                //var query5 = db.Orders
                //    .GroupBy(o => o.Employees.FirstName)
                //    .Select(g => new
                //    {
                //        nombre = g.Key,
                //        cantidad = g.Count()
                //    }).ToList();

                //foreach (var item in query5) {
                //    Console.WriteLine($"{item.nombre} {item.cantidad}");
                //}

                //* Filtrado avanzado
                //Consultar todos los pedidos enviados a “USA” en el año 1997.
                //Mostrar OrderID, CustomerID, EmployeeID, OrderDate.

                var query6 = db.Orders
                    .Where(o => Convert.ToDateTime(o.OrderDate).Year.ToString() == "1997"
                    && o.ShipCountry == "USA")
                    .Select(o => new
                    {
                        OrderId = o.OrderID,
                        Customer = o.CustomerID,
                        Employee = o.EmployeeID,
                        Fecha = Convert.ToDateTime(o.OrderDate).ToShortDateString()
                    }).ToList();
                foreach (var item in query6) {
                    Console.WriteLine($"{item.OrderId}, {item.Customer}, {item.Employee}, {item.Fecha}");
                }

            }
        }
    }
}
