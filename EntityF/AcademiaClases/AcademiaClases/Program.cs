using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaClases
{
    public static class DataSeeder {
        public static void Seed(AcademiaClasesDBEntities1 context)
        {
            // Evitar duplicar datos
            if (context.Alumnoes.Any()) return;
            // === Empresas ===
            var empresas = new List<Empresa>
    {
        new Empresa { CIF = "A11111111", Nombre = "TechCorp", Telefono = "911111111", Direccion = "Calle 1" },
        new Empresa { CIF = "B22222222", Nombre = "DataSoft", Telefono = "922222222", Direccion = "Calle 2" },
        new Empresa { CIF = "C33333333", Nombre = "WebSolutions", Telefono = "933333333", Direccion = "Calle 3" }
    };
            context.Empresas.AddRange(empresas);
            context.SaveChanges();
            // === Alumnos ===
            var alumnos = new List<Alumno>
    {
        new Alumno { DNI = "11111111A", Nombre = "Pablo", Direccion = "Calle A", Telefono = "600111111", Edad = 28, Empresa = empresas[0] },
        new Alumno { DNI = "22222222B", Nombre = "Maria", Direccion = "Calle B", Telefono = "600222222", Edad = 32, Empresa = empresas[1] },
        new Alumno { DNI = "33333333C", Nombre = "Luis", Direccion = "Calle C", Telefono = "600333333", Edad = 25, Empresa = null }, // desempleado
        new Alumno { DNI = "44444444D", Nombre = "Ana", Direccion = "Calle D", Telefono = "600444444", Edad = 40, Empresa = empresas[2] },
        new Alumno { DNI = "55555555E", Nombre = "Sofia", Direccion = "Calle E", Telefono = "600555555", Edad = 30, Empresa = null }, // desempleado
        new Alumno { DNI = "66666666F", Nombre = "Carlos", Direccion = "Calle F", Telefono = "600666666", Edad = 27, Empresa = null } // alumno sin cursos
    };
            context.Alumnoes.AddRange(alumnos);
            context.SaveChanges();

            // === Profesores ===
            var profesores = new List<Profesor>
    {
        new Profesor { DNI = "P1111111", Nombre = "Laura", Apellidos = "Gomez", Direccion = "Calle P1", Telefono = "911111111" },
        new Profesor { DNI = "P2222222", Nombre = "Jose", Apellidos = "Martinez", Direccion = "Calle P2", Telefono = "922222222" },
        new Profesor { DNI = "P3333333", Nombre = "Ana", Apellidos = "Lopez", Direccion = "Calle P3", Telefono = "933333333" }
    };
            context.Profesors.AddRange(profesores);
            context.SaveChanges();
            // === Cursos ===
            var cursos = new List<Curso>
    {
        new Curso { Codigo = "C001", Titulo = "C# Básico", Programa = "Introducción a C#", Horas = 40 },
        new Curso { Codigo = "C002", Titulo = "ASP.NET Core", Programa = "Web con .NET", Horas = 50 },
        new Curso { Codigo = "C003", Titulo = "LINQ Avanzado", Programa = "Consultas y agregaciones", Horas = 30 },
        new Curso { Codigo = "C004", Titulo = "JavaScript", Programa = "JS moderno", Horas = 35 } // curso sin alumnos
    };
            context.Cursoes.AddRange(cursos);
            context.SaveChanges();
            // === Imparticiones de Cursos ===
            var imparticiones = new List<Imparticion>
    {
        new Imparticion { Curso = cursos[0], Numero = 1, FechaInicio = new DateTime(2025,1,10), FechaFin = new DateTime(2025,1,20), Profesor = profesores[0] },
        new Imparticion { Curso = cursos[1], Numero = 1, FechaInicio = new DateTime(2025,2,5), FechaFin = new DateTime(2025,2,25), Profesor = profesores[1] },
        new Imparticion { Curso = cursos[2], Numero = 1, FechaInicio = new DateTime(2025,3,1), FechaFin = new DateTime(2025,3,10), Profesor = profesores[2] },
        new Imparticion { Curso = cursos[0], Numero = 2, FechaInicio = new DateTime(2025,4,1), FechaFin = new DateTime(2025,4,15), Profesor = profesores[0] }
    };
            context.Imparticions.AddRange(imparticiones);
            context.SaveChanges();
            // === Notas de Alumnos ===
            var notas = new List<Nota>
    {
        new Nota { Alumno = alumnos[0], Imparticion = imparticiones[0], Valor = 9 },
        new Nota { Alumno = alumnos[1], Imparticion = imparticiones[0], Valor = 8 },
        new Nota { Alumno = alumnos[0], Imparticion = imparticiones[1], Valor = 7 },
        new Nota { Alumno = alumnos[2], Imparticion = imparticiones[1], Valor = 6 },
        new Nota { Alumno = alumnos[3], Imparticion = imparticiones[2], Valor = 9 },
        new Nota { Alumno = alumnos[4], Imparticion = imparticiones[2], Valor = 7 },
        new Nota { Alumno = alumnos[0], Imparticion = imparticiones[3], Valor = 10 },
        new Nota { Alumno = alumnos[1], Imparticion = imparticiones[3], Valor = 9 }
    };
            context.Notas.AddRange(notas);
            context.SaveChanges();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //CargarDatos();
            //Listar todos los alumnos trabajadores junto con el nombre de la empresa en la que trabajan.
            //Mostrar: DNI del alumno, nombre del alumno, nombre de la empresa.
            //Alumnos_Trabajadores();
            //Obtener la lista de cursos que ha realizado un alumno concreto, indicando las fechas de inicio
            //y fin de cada curso y la nota obtenida.
            //Entrada: DNI del alumno.
            //Cursos_Alumno();
            //Listar los profesores junto con el número de cursos que han impartido.
            //Incluir solo aquellos profesores que hayan impartido al menos un curso.
            //Profesores_NumeroCursos();
            //Obtener todos los alumnos, independientemente de si han hecho algún curso o no, y mostrar su DNI,
            //nombre y el número de cursos realizados.
            //Esto implica un LEFT JOIN o equivalente en LINQ.
            //Alumnos_ConYSin_Cursos();
            //Listar los cursos con su duración total(horas) y el número de alumnos matriculados en cada curso.
            //Cursos_Horas_TotalAlumnos();
            //Listar todos los alumnos trabajadores mayores de 30 años que hayan obtenido una nota superior
            //a 8 en algún curso.
            //Alumnos_Trabajadores_Nota8();
            //Obtener el promedio de notas por curso, mostrando el código de curso y
            //el promedio de todos los alumnos que lo han realizado.
            Promedio_Notas_Curso();
            //Listar todos los alumnos y sus cursos, incluyendo los cursos que todavía
            //no han sido calificados(nota nula).
            Alumnos_Cursos_ConYSin_Nota();
            //Listar los alumnos que han realizado más de 3 cursos distintos,
            //mostrando su DNI, nombre y número total de cursos.

        }

        private static void Alumnos_Cursos_ConYSin_Nota()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query8= (from a in context.Alumnoes
                            join n in context.Notas
                            on a.AlumnoId equals n.AlumnoId into an
                            from n in an.DefaultIfEmpty()
                            join i in context.Imparticions
                            on n.ImparticionId equals i.ImparticionId into ni
                            from i in ni.DefaultIfEmpty()
                            group i.Curso by a into grupo
                            select new
                            {
                                Alumno = grupo.Key.Nombre,
                                Cursos= grupo.Where(x=>x!=null).Select(x=>x.Titulo).ToList()//e faltaba el where
                            }).ToList();

                foreach(var item  in query8)
                {
                    Console.WriteLine($"Alumno {item.Alumno}");
                    foreach(var item2 in item.Cursos)
                    {
                        Console.WriteLine($" {item2}");
                    }
                }
                var query8a = (from c in context.Cursoes
                               join i in context.Imparticions
                               on c.CursoId equals i.CursoId into ci
                               from i in ci.DefaultIfEmpty()
                               join n in context.Notas
                               on i.ImparticionId equals n.ImparticionId into ni
                               from n in ni.DefaultIfEmpty()
                               group new { i, n } by n.Alumno into grupo
                               select new
                               {
                                   AlumnoNombre = grupo.Key.Nombre,
                                   CursosN = grupo
                                              .Where(x => x.i != null)
                                              .Select(x => new
                                              {
                                                  CursoNombre = x.i.Curso.Titulo,
                                                  Nota = x.n != null ? (double?)x.n.Valor : null
                                              })
                                              .Distinct()
                                              .ToList()
                                   
                               }).ToList();
                foreach (var item in query8a)
                {
                    Console.WriteLine($"Alumno: {item.AlumnoNombre}");
                    if (item.CursosN.Any())
                    {
                        foreach (var curso in item.CursosN)
                            Console.WriteLine($"   {curso.CursoNombre}  Nota: {curso.Nota}");
                    }
                    else
                    {
                        Console.WriteLine("   (sin cursos)");
                    }
                }
            }
        }

        private static void Promedio_Notas_Curso()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query7 = (from i in context.Imparticions
                              join n in context.Notas
                              on i.ImparticionId equals n.ImparticionId
                              group n by i.Curso into g
                              select new
                              {
                                  NombreC = g.Key.Titulo,
                                  PromedioNotas = g.Average(x => x.Valor)
                              }).ToList();
                foreach(var item in query7)
                {
                    Console.WriteLine($"Curso: {item.NombreC}- Promedio: {item.PromedioNotas:0.00} ");
                }
            }
        }

        private static void Alumnos_Trabajadores_Nota8()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query6 = context.Notas
                    .Where(n => n.Valor>=8 && n.Alumno.EmpresaId == null && n.Alumno.Edad >= 30)
                    .Select(x => new
                    {
                        AlumnoNombre = x.Alumno.Nombre,
                        EdadAlumno = x.Alumno.Edad,
                        NotaA = x.Valor
                    }).ToList();

                foreach (var item in query6)
                {
                    Console.WriteLine($"Alumno {item.AlumnoNombre}, Edad: {item.EdadAlumno}, Nota: {item.NotaA}");
                }
            }
            }

        private static void Cursos_Horas_TotalAlumnos()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query5 = (from i in context.Imparticions
                              group i by i.Curso into grupo
                              select new
                              {
                                  curso = grupo.Key.Titulo,
                                  Duracion = DbFunctions.DiffHours(grupo.Min(x => x.FechaInicio), grupo.Max(x => x.FechaFin)),//revisar esto
                                  Cantidad = grupo.SelectMany(x => x.Notas).Select(x => x.AlumnoId).Distinct().Count()
                              }).ToList();
                foreach(var item in query5)
                {
                    Console.WriteLine($"Curso: {item.curso}, Duracion: {item.Duracion} horas, CantidadInscritos: {item.Cantidad}");
                }
                            
            }
        }

        private static void Alumnos_ConYSin_Cursos()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query4 = (from a in context.Alumnoes
                              join n in context.Notas
                              on a.AlumnoId equals n.AlumnoId into an
                              from n in an.DefaultIfEmpty()
                              join i in context.Imparticions
                              on n.ImparticionId equals i.ImparticionId into alumnoImparticion
                              from i in alumnoImparticion.DefaultIfEmpty()
                              group n.Imparticion by a into g
                              select new
                              {
                                  AlumnoNombre = g.Key.Nombre,
                                  Dni = g.Key.DNI,
                                  NumeroCursos = g.Count(x => x != null)//(x => x != null)revisar esto
                              }).ToList();
                foreach (var item in query4)
                {
                    Console.WriteLine($"Alumno : {item.AlumnoNombre}, Dni: {item.Dni}, NumeroCursos: {item.NumeroCursos}");
                }

            }
        }

        private static void Profesores_NumeroCursos()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query3 = context.Profesors
                    .Where(p => p.Imparticions.Count() > 0)
                    .Select(p => new
                    {
                        NombreProfesor = p.Nombre,
                        NumeroCursos = p.Imparticions.Count()

                    }).ToList();
                foreach(var item in query3)
                {
                    Console.WriteLine($"Profesor: {item.NombreProfesor}, NumeroCursos: {item.NumeroCursos}");
                }
            }
        }

        private static void Cursos_Alumno()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query2 = context.Alumnoes
                    .Where(a => a.DNI == "11111111A")
                    .SelectMany(a => a.Notas)
                    .ToList()//para hacer la conversion de la fechas antes debemos listar
                    .Select(a => new
                    {
                        Curso = a.Imparticion.Curso.Titulo,
                        FechaInicioCurso = a.Imparticion.FechaInicio.ToShortDateString(),
                        FechaFinCurso = a.Imparticion.FechaFin.ToShortDateString(),
                        NotaObtenida = a.Valor
                    }).ToList();

                foreach(var item in query2)
                {
                    Console.WriteLine($"Nombre Curso: {item.Curso}, FechaInicio: {item.FechaInicioCurso}, " +
                        $"FechaFin: {item.FechaFinCurso}, Nota: {item.NotaObtenida}");
                }


                
            }
        }

        private static void Alumnos_Trabajadores()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query1 = context.Alumnoes
                    .Where(a => a.EmpresaId != null)
                    .Select(a => new
                    {
                        Dni = a.DNI,
                        Alumno = a.Nombre,
                        EmpresaAlumno = a.Empresa.Nombre
                    }).ToList();

                foreach(var item in query1)
                {
                    Console.WriteLine($"Dni: {item.Dni} Nombre: {item.Alumno} Empresa: {item.EmpresaAlumno}");
                }
            }

        }

        private static void CargarDatos()
        {
            using(var context = new AcademiaClasesDBEntities1())
            {
                DataSeeder.Seed(context);
                Console.WriteLine("Datos cargados");
            }
        }
    }
}
