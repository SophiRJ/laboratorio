using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EcoFitness
{
    public class Program
    {
        static void Main(string[] args)
        {
            string cadena = ConfigurationManager.ConnectionStrings["EcoFitness.Properties.Settings.EcoFitnessConnectionString"].ConnectionString;

            //Consultas
            //1.Listado de miembros por ciudad
            Miembros_Por_Ciudad(cadena);
            //2.Clases de un miembro específico
            Clases_Miembro_Especifico(cadena);
            //3.Clases más populares
            Clases_Mas_Populares(cadena);
            //4.Ingresos por categoría de clase
            Ingresos_Por_Categoria_Clase(cadena);
            //5.Entrenadores y número de clases que dan
            Entrenadores_Num_Clases(cadena);
            //6.Filtrado avanzado: pagos mayores a 15 en 2025
            Pagos_Mayores(cadena);
            //7.Miembros con más inscripciones
            Miembros_Con_MAs_Inscripciones(cadena);
            //8.Clases sin inscripciones
            Clases_Sin_Inscripciones(cadena);
            //9.Ingresos totales por miembro
            Ingresos_totales_Por_Miembro(cadena);
            //10.Entrenadores con ingresos generados por sus clases
            Entrenadores_Ingresos_Clases(cadena);

           
            Console.ReadKey();
        }

        private static void Pagos_Mayores(string cadena)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext(cadena))
            {
                var query6 = db.Payments
                    .Where(p => p.Amount > 15 && p.PaymentDate.Year == 2025)
                    .Select(p => new
                    {
                        nombreMiembroPAgador = p.Members.FullName,
                        clasePagada = p.Classes.ClassName,
                        montoPagado = p.Amount,
                        fechaDePago = p.PaymentDate.ToShortDateString()
                    }).ToList();
                Console.WriteLine("\nPagos mayores a 15 en 2025");
                foreach (var item in query6)
                {
                    Console.WriteLine($"Miembro pagador: {item.nombreMiembroPAgador}, " +
                        $"Clase Pagada: {item.clasePagada}, Monto: {item.montoPagado}, Fecha: {item.fechaDePago}");
                }
            }
        }

        private static void Clases_Sin_Inscripciones(string cadena)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext(cadena))
            {
                var query8 = db.Classes
                    .Where(c=>!c.Enrollments.Any())
                    .Select(c => new
                    {
                        nombre=c.ClassName,
                    }).ToList();
                Console.WriteLine("\nClases sin inscripcones");
                foreach (var item in query8)
                {     
                    Console.WriteLine($"Nombre Clase: {item.nombre}");
                }
            }
        }

        private static void Entrenadores_Ingresos_Clases(string cadena)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext(cadena))
            {
                var query10 = db.Classes
                    .SelectMany(c => c.Payments)
                    .GroupBy(c => c.Classes.Trainers)
                    .ToList()
                    .Select(g => new
                    {
                        Entrenador = $"{g.Key.FirstName} {g.Key.LastName}",
                        Ingresos = g.Sum(x => x.Amount)
                    }).ToList();
                Console.WriteLine("\nEntrenadores con ingresos generados por sus clases");
                foreach (var item in query10)
                {
                    Console.WriteLine($"Entrenador: {item.Entrenador}- Ingresos: {item.Ingresos}");
                }
                var query10a= db.Classes
                    .GroupBy(c => c.Trainers)
                    .ToList()
                    .Select(g => new
                    {
                        Entrenador= g.Key.FirstName + g.Key.LastName,
                        Ingreso= g.Sum(c=>c.Price * c.Enrollments.Count())
                    }).ToList();
            }
        }

        private static void Ingresos_totales_Por_Miembro(string cadena)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext(cadena))
            {
                var query9 = db.Payments
                    .GroupBy(p => p.Members)
                    .OrderByDescending(g=>g.Sum(x=>x.Amount))
                    .Select(g => new
                    {
                        Miembro = g.Key.FullName,
                        TotalIngresos = g.Sum(x => x.Amount)
                    }).ToList();


                Console.WriteLine("\nEIngresos totales por miembro");

                foreach (var item in query9)
                {
                    Console.WriteLine($"Nombre: {item.Miembro}- IngresoTotal: {item.TotalIngresos}");
                }
            }
        }

        private static void Miembros_Con_MAs_Inscripciones(string cadena)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext(cadena))
            {
                var query7 = db.Enrollments
                    .GroupBy(e => e.Members)
                    .OrderByDescending(g => g.Count())
                    .Select(g => new
                    {
                        Miembro = g.Key.FullName,
                        NumeroInscripciones = g.Count()
                    }).ToList().Take(3);

                Console.WriteLine("\nMiembros con mas inscripciones");
                foreach (var item in query7)
                {
                    Console.WriteLine($"Miembro {item.Miembro} Inscripciones: {item.NumeroInscripciones}");
                }
            }
        }

        private static void Entrenadores_Num_Clases(string cadena)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext(cadena))
            {
                var query5 = db.Classes
                    .GroupBy(c => c.Trainers)
                    .ToList()
                    .Select(g => new
                    {
                        Trainer = $"{g.Key.FirstName} {g.Key.LastName}",
                        NumeroClases = g.Count()
                    }).ToList();

                Console.WriteLine("\nEntrenadores y numero de clases que dan");

                foreach (var item in query5)
                {
                    Console.WriteLine($"Entrenador: {item.Trainer} Numero Clases: {item.NumeroClases}");
                }
                //var query5a = (from c in db.Classes
                //               group c.ClassName by c.Trainers into g
                //               select new
                //               {
                //                   Trainer = g.Key.FirstName + " " + g.Key.LastName,
                //                   NumeroClases = g.Count()
                //               }).ToList();
                //foreach (var item in query5a)
                //{
                //    Console.WriteLine($"Entrenador-: {item.Trainer} Numero Clases: {item.NumeroClases}");
                //}
                             
                             
            }
        }

        private static void Ingresos_Por_Categoria_Clase(string cadena)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext(cadena))
            {
                //Empece la consulta por Payments ya que tiene el n y me puedo mover mas facilmente hacia 
                //las otras tablas por las propiedades de navegacion, agrupe los precios por las categorias
                // ordene por el valor total del pago (.Sum()) y proyecte la categoria y el ingreso de cada 
                var query4 = (from p in db.Payments
                              group p.Amount by p.Classes.Categories into g
                              orderby g.Sum() descending
                              select new
                              {
                                  Categoria = g.Key.CategoryName,
                                  Ingreso = g.Sum()
                              }).ToList();

                Console.WriteLine("\nIngresos por categoria de clases");

                foreach (var item in query4)
                {
                    Console.WriteLine($"Categoria: {item.Categoria}");
                    Console.WriteLine($"Ingresos Totales: {item.Ingreso}");
                }
            }
        }

        private static void Clases_Mas_Populares(string cadena)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext(cadena))
            {
                var query3 = (from e in db.Enrollments
                              group e by e.Classes into g
                              orderby g.Count() descending
                              select new
                              {
                                  NombreClase = g.Key.ClassName,
                                  NumeroInscripciones = g.Count()
                              }).ToList().Take(2);

                Console.WriteLine("\nClases mas populares");

                foreach (var e in query3)
                {
                    Console.WriteLine($"Nombre Clase {e.NombreClase}");
                    Console.WriteLine($"Numero inscripciones: {e.NumeroInscripciones}");
                }
                
            }
        }

        private static void Clases_Miembro_Especifico(string cadena)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext(cadena))
            {//empiezo la consuta en la tabla Enrollments ya que de aqui puedo moverme por las demas a traves de la 
                //la prpiedad de navegacion, agrupo los nombres de las clases por los miembros, filtro por el miembro
                //que quiero consultar y lo listo. Recorro la lista que me devuelve la consulta para sacar la Key, y despues
                //recorro los item que me devuelve la agrupacion y muestro cada registro
                var query2 = (from e in db.Enrollments
                             group e.Classes.ClassName by e.Members into grupo
                             where grupo.Key.MemberID==1
                             select grupo ).ToList();

                Console.WriteLine("\nClases de un miembro especifico");

                foreach (var item in query2)
                {
                    Console.WriteLine($"Miembro: {item.Key.FullName}");
                    foreach (var clase in item) {
                        Console.WriteLine($"Clase: {clase}");
                    }
                }

            }
        }

        private static void Miembros_Por_Ciudad( string cadena)
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext(cadena))
            {
                //agrupo los nombres de los miembros por el campo ciudad y al proyectar un objeto nuevo 
                //establezco la key -> el campo de agrupacion como ciudad y en miembros hago una lista 
                // de los nombres que pertenecen a esa ciudad
                var query1 = (from m in db.Members
                              group m.FullName by m.City into g
                              select new
                              {
                                  Ciudad = g.Key,
                                  Miembros = g.ToList()
                              }).ToList();

                Console.WriteLine("\nListado de miembros por ciudad");

                foreach (var item in query1)
                {
                    Console.WriteLine($"{item.Ciudad}");
                    foreach(var item2 in item.Miembros)
                    {
                        Console.WriteLine($"{item2}");
                    }
                }
            }
        }
    }
}

