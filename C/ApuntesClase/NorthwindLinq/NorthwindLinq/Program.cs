using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Linq;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cadena = ConfigurationManager.ConnectionStrings["NORTHWNDConnectionString"].ConnectionString;
            using (DataClasses1DataContext db = new DataClasses1DataContext(cadena))
            {
                //var empleados = db.Employees.ToList();

                //foreach (var emp in empleados) {
                //    Console.WriteLine($"{emp.EmployeeID}: {emp.FirstName} - {emp.LastName}");
                //}

                //una vez eecutado la var anonima ya tiene tipo lista de customers
                //var data = (from c in db.Customers
                //           where c.Country=="Spain"
                //           select c).ToList();
                //       Console.ReadKey();

                //var dataLAmbda = db.Customers
                //    .Where(c => c.Country == "Spain").ToList();

                //foreach (var c in dataLAmbda)
                //{
                //    Console.WriteLine($"{c.CompanyName} -{c.City}");
                //}

                //var clientes = (from c in db.Customers
                //                where c.Country == "Spain"
                //                orderby c.CompanyName, c.ContactName descending
                //                select c).ToList();

                //sacamos dos columnas filtramos
                //var clientesFiltrados = (from c in db.Customers
                //                         where c.Country == "Spain"
                //                         orderby c.CompanyName
                //                         select new
                //                         {
                //                             c.CompanyName,
                //                             c.ContactName
                //                         }).ToList();

                //⦁Ejercicio propuestos(5.1):
                //⦁Crear una aplicación que muestre por consola utilizando LINQ el nombre
                //de la compañía para todos los clientes de la ciudad de Sao Paulo.
                //var query1 = (from c in db.Customers
                //              where c.City == "Sao Paulo"
                //              select new
                //              {
                //                  c.CompanyName,
                //                  c.City
                //              }).ToList();
                //foreach (var c in query1)
                //{
                //    Console.WriteLine($"{c.CompanyName}, {c.City}");
                //}

                //⦁Ejercicio propuestos(5.2):
                //⦁Crear una aplicación que muestre por consola utilizando LINQ el nombre
                //y apellido concatenado y fecha de nacimiento ordenado por edad para todos los
                //empleados de la ciudad de Londres.
                //var query2 = (from e in db.Employees
                //              where e.City == "London"
                //              select new
                //              {
                //                  Nombre = e.FirstName + " " + e.LastName,
                //                  FechaNac = Convert.ToDateTime($"{e.BirthDate}").ToShortDateString(),
                //                  Ciudad = e.City
                //              }).ToList();
                //foreach (var e in query2)
                //{
                //    Console.WriteLine($"{e.Nombre}, {e.FechaNac}, {e.Ciudad}");
                //}

                //⦁Ejercicio propuestos(5.3):
                //⦁Crear una aplicación que muestre por consola utilizando LINQ nombre de
                //producto y unidades en stock para los productos con un precio superior a 50€.
                //⦁
                //var query3 = (from p in db.Products
                //              where p.UnitPrice > 50
                //              select new
                //              {
                //                  Nombre =$"{p.ProductName}" ,
                //                  Stock = Convert.ToInt32($"{p.UnitsInStock}"),
                //                  Precio = p.UnitPrice
                //              }).ToList();

                //foreach (var p in query3)
                //{
                //    Console.WriteLine($"{p.Nombre}, {p.Stock}, {p.Precio:0.00}");
                //}

                //⦁Ejercicio propuestos(5.4):
                //⦁Crear una única aplicación que muestre por consola utilizando Expresiones
                //Lambda las tres prácticas anteriores.

                //var lamda1 = db.Customers
                //    .Where(c => c.City == "Sao Paulo")
                //    .Select(c => c.CompanyName).ToList();


                //var lamda2 = db.Employees
                //    .Where(e => e.City == "London")
                //    .ToList()
                //    .Select(e => new
                //    {
                //        Nombre = $"{e.FirstName} {e.LastName}",
                //        FechaNac = Convert.ToDateTime($"{e.BirthDate}").ToShortDateString(),
                //        Ciudad = e.City
                //    }).OrderByDescending(e => e.FechaNac);

                //foreach (var p in lamda2)
                //{
                //    Console.WriteLine($"{p.Nombre}- {p.FechaNac} - {p.Ciudad}");
                //}

                //var lambda3 = db.Products
                //    .Where(p => p.UnitPrice > 50)
                //    .OrderBy(p=> p.ProductName)
                //    .Select(p => new
                //    {
                //        Nombre = $"{p.ProductName}",
                //        Stock = Convert.ToInt32($"{p.UnitsInStock}"),
                //        Precio = p.UnitPrice
                //    }).ToList();

                //var lambda3a = db.Products
                //    .Where(p => p.UnitPrice > 50)
                //    .ToList()
                //    .Select(p => new

                //    {
                //        Nombre = $"{p.ProductName}",
                //        Stock = Convert.ToInt32($"{p.UnitsInStock}"),
                //        Precio = p.UnitPrice
                //    }).OrderByDescending(p => p.Nombre);

                //foreach (var p in lambda3)
                //{
                //    Console.WriteLine($"{p.Nombre}- {p.Stock} - {p.Precio}");
                //}

                //Propiedades calculadas

                //var clientes = (from c in db.Customers
                //                where c.Country == "Spain"
                //                orderby c.CompanyName
                //                select new
                //                {
                //                    ID = c.CustomerID,
                //                    Nombre = c.ContactName,
                //                    Pais = c.Country,
                //                    Total_Pedidos = c.Orders.Count()// hay relacion entre ambas tablas
                //                                                    // propiedad de navegacion
                //                                                    //me permite sobre esta propiedad
                //                                                    //encontrar los registros de orders
                //                }).ToList();
                //foreach (var c in clientes)
                //{
                //    Console.WriteLine($"{c.Nombre}, {c.Total_Pedidos}");
                //}

                //Select many
                //var cliente = (from c in db.Customers
                //               where c.Country == "Spain"
                //               select c).SelectMany(c => c.Orders).ToList();

                //foreach (var c in cliente)
                //{
                //    Console.WriteLine($"{c.Customers.CompanyName}," +
                //        $" {Convert.ToDateTime(c.OrderDate).ToShortDateString()}");
                //}


                //puedo navegar hacia diferentes datos segun las relaciones que tenga
                //donde ponga select many es la padre desde donde me muevo a todo sitio
                //el filtro se lo pasas a la primera tabla

                //var pedidos = (from c in db.Customers
                //               where c.Country == "Spain"
                //               select c).SelectMany(c => c.Orders).Select(c => new
                //               {
                //                   Comercial = $"{c.Employees.FirstName}-{c.Employees.LastName}",
                //                   Num_Pedido = c.OrderID,
                //                   F_pedido = c.OrderDate,
                //                   Cliente = c.Customers.CompanyName
                //               }).ToList();

                //////mismo con Lambda
                //var pedidosLamda = db.Customers
                //    .Where(c => c.Country == "Spain")
                //    .SelectMany(c => c.Orders).Select(c => new
                //    {
                //        Comercial = $"{c.Employees.FirstName}, {c.Employees.LastName}",
                //        Num_pedid = c.OrderID,
                //        f_pedido = c.OrderDate,
                //        cliente = c.Customers.CompanyName
                //    }).ToList();

                //nombre de la compañia (customers), nombre de empleado(employees)
                //gasto de reparto freight (productos) con proveedores de la ciudad de manchester

                //var query = db.Products
                //    .SelectMany(p => p.Order_Details)
                //    .Where(p => p.Products.Suppliers.City == "Manchester")
                //    .Select(p => new
                //    {
                //        Cliente = p.Orders.Customers.CompanyName,
                //        Comercial = $"{p.Orders.Employees.FirstName} {p.Orders.Employees.LastName}",
                //        Gastos_envio = p.Orders.Freight
                //    }).ToList();

                //COMERCIAL(EMPLOYEE), Nombre de Producto(PRODUCTS), Precio de Pedido(ORDERS_DETAILS),
                //Cantidad de Pedido(ORDERS_DETAILS) y Fecha de Pedido(ORDERS)
                //Para todos los pedidos realizados por empleados que vivan en "LONDON"
                //Ordenados por nombre Empleado, Nombre de Producto, Cantidad descendente

                //var query1 = db.Orders
                //    .SelectMany(od => od.Order_Details)
                //    .Where(od => od.Orders.Employees.City == "London")
                //    .OrderBy(od => od.Orders.Employees.LastName)
                //    .ThenBy(od => od.Products.ProductName)
                //    .ThenByDescending(od => od.Quantity)
                //    .Select(od => new
                //    {
                //        Comercial = $"{od.Orders.Employees.LastName},{od.Orders.Employees.FirstName}",
                //        Producto = od.Products.ProductName,
                //        Precio = od.Quantity,
                //        Fecha_pedido = od.Orders.OrderDate.Value.ToShortDateString()
                //    }).ToList();

                //Nombre de Producto(PRODUCT), Categoriade Producto(CATEGORY), Fecha de Pedido(ORDERS),
                //Importe de Pedido(ORDERS_DETAILS) para todos los Productos con PrecioUnitario> 10
                //var query3 = db.Products
                //    .SelectMany(p => p.Order_Details)
                //    .Where(p => p.UnitPrice > 10)
                //    .Select(p => new
                //    {
                //        NombreProducto = p.Products.ProductName,
                //        Categoria = p.Products.Categories.CategoryName,
                //        F_pedido = p.Orders.OrderDate.Value.ToShortDateString(),
                //        Importe = $"{p.UnitPrice * p.Quantity}"
                //    }).ToList();
                //foreach (var item in query3) {
                //    Console.WriteLine($"{item.NombreProducto} {item.Categoria} {item.F_pedido} " +
                //        $"{item.Importe}");
                //}

                //Empleado y fecha de pedido ordenado por fecha de pedido y apellido de empleado

                //var quer4 = db.Employees
                //.SelectMany(em => em.Orders)
                //.OrderBy(em => em.OrderDate)
                //.ThenBy(em => em.Employees.LastName)
                //.Select(em => new
                //{
                //    Employee = $"{em.Employees.FirstName} {em.Employees.LastName}",
                //    Order_date = Convert.ToDateTime(em.OrderDate).ToShortDateString()
                //}).ToList();

                //Media de ventas realizadas por michael suyama
                //var query5 = db.Orders
                //    .SelectMany(od => od.Order_Details)
                //    .Where(od => od.Orders.Employees.FirstName == "Michael" && od.Orders.Employees.LastName == "Suyama")
                //    .Select(od => od.Quantity * od.UnitPrice).Average().ToString("#.##");


                //Nombre de Comercial(EMPLOYEE), Zona Comercial(REGION) y Territorio Comercial(TERRITORY)
                //Para todos los empleados con Domicilio en "London"
                //Ordenadodescendente porapellido empleadoy ascendente porterritorio
                //var query6 = db.Employees
                //    .SelectMany(em => em.EmployeeTerritories)
                //    .Where(em => em.Employees.City == "London")
                //    .OrderByDescending(em => em.Employees.LastName)
                //    .ThenBy(em => em.Territories.TerritoryDescription)
                //    .Select(em => new
                //    {
                //        Comercial = $"{em.Employees.LastName} {em.Employees.FirstName}",
                //        Zona = em.Territories.Region.RegionDescription,
                //        Territorio = em.Territories.TerritoryDescription
                //    }).ToList();

                //join
                //var query7 = (from c in db.Customers
                //              join o in db.Orders
                //              on c.CustomerID equals o.CustomerID
                //              select new
                //              {
                //                  Contact = c.ContactName,
                //                  Fecha_pedido = o.OrderDate.Value.ToShortDateString()
                //              }).ToList();

                ////Funciones de agregacion
                //var data = (from od in db.Order_Details
                //            where od.OrderID == 10250
                //            select od.Quantity * od.UnitPrice).Sum();



                //var datos= (from o in db.Orders
                //           join em in db.Employees
                //           on o.EmployeeID equals em.EmployeeID
                //           select new
                //           {
                //               Fecha_pedidos= Convert.ToDateTime(o.OrderDate).ToShortDateString(),
                //               Empleado= $"{em.FirstName} {em.LastName}"

                //           }).ToList();
                //foreach (var od in datos)
                //{
                //    Console.WriteLine($"{od.Fecha_pedidos}, ({od.Empleado})");
                //}

                //Particiones
                //var data1 = (from c in db.Customers
                //             select c).Take(10).ToList();

                //var data2 = (from c in db.Customers
                //             select c).Skip(30).Take(10).ToList();

                //recuperar un unico registro
                //para recuperar el primero q encuentre -> first
                // single-> si tengo claro que solo hay uno en todo
                //alumno/a mide 175 ---> si no hay ninguno con first y con sigle me devuelve un error
                //cuando quiero encontrar y puede que no haya nadie que lo tenga-> firstOrDefault, SingleOrDefault
                //ambos devuelven 0

                // primer cliente de usa (company name, country, order_date) que tenga pedidos del mes de mayo de 1998
                //var data4 = (from c in db.Customers
                //             join o in (from t in db.Orders
                //                        where t.OrderDate.Value.Year == 1998
                //                        && t.OrderDate.Value.Month == 5
                //                        select t)
                //             on c.CustomerID equals o.CustomerID
                //             select new
                //             {
                //                 Cliente = c.CompanyName,
                //                 Pais = c.Country,
                //                 F_pedido = Convert.ToDateTime(o.OrderDate).ToString()

                //             }).FirstOrDefault(x => x.Pais == "USA");

                //var data4a = (from c in db.Customers
                //              join o in db.Orders
                //              on c.CustomerID equals o.CustomerID
                //              where o.OrderDate.Value.Year == 1998
                //              && o.OrderDate.Value.Month == 5
                //              select new
                //              {
                //                  Cliente = c.CompanyName,
                //                  Pais = c.Country,
                //                  F_pedido = Convert.ToDateTime(o.OrderDate).ToString()
                //              }).FirstOrDefault(x => x.Pais == "USA");



                //Agrupaciones
                //var agrupaciones = (from p in db.Order_Details
                //                    group p by p.ProductID into grupo
                //                    select grupo).ToList();

                //foreach (var grupo in agrupaciones)
                //{
                //    Console.WriteLine($"PRoducto: {grupo.Key}");
                //    foreach (var objeto in grupo)
                //    {
                //        Console.WriteLine($"Pedido Nº: {objeto.OrderID} precio: {objeto.UnitPrice}");
                //    }

                //}

                //var agrupacion = (from od in db.Order_Details
                //                  join p in db.Products
                //                  on od.ProductID equals p.ProductID
                //                  group od by new
                //                  {
                //                      od.OrderID,
                //                      p.ProductName
                //                  }
                //                  into grupo
                //                  orderby grupo.Key.ProductName descending
                //                  select grupo).ToList();

                //foreach (var grupo in agrupacion)
                //{
                //    Console.WriteLine($"PRoducto: {grupo.Key.ProductName}");
                //    foreach (var objeto in grupo)
                //    {
                //        Console.WriteLine($"Pedido Nº: {objeto.OrderID} precio: {objeto.UnitPrice}");
                //    }
                //}

                //CRUD
                //Alta baja y modificacion de elementos

                //Employees empleadoNuevo = new Employees();
                //empleadoNuevo.EmployeeID = 999;
                //empleadoNuevo.FirstName = "Javier";
                //empleadoNuevo.LastName = "Vazquez";

                //db.Employees.InsertOnSubmit(empleadoNuevo);
                //db.SubmitChanges();

                //var listaEmpleado = db.Employees.ToList();

                //Region region = new Region();
                //region.RegionID = 22;
                //region.RegionDescription = "Vallecas";

                //db.Region.InsertOnSubmit(region);
                //db.SubmitChanges();

                //var listRegion=db.Region.ToList();

                ////Modificar
                //var empleadoModificar = db.Employees.SingleOrDefault(e => e.EmployeeID == 8);
                //if (empleadoModificar != null)
                //{
                //    empleadoModificar.City = "Madrid";
                //    db.SubmitChanges();
                //}
                //var listaEmpleados = db.Employees.ToList();

                ////Borrar
                //var empleadoBorrar = db.Employees.SingleOrDefault(e => e.EmployeeID == 12);
                //if (empleadoBorrar != null)
                //{
                //    db.Employees.DeleteOnSubmit(empleadoBorrar);
                //    db.SubmitChanges();
                //}
                //var listaEmpleados1 = db.Employees.ToList();



            }
        }
    }
}
