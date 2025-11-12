using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
            //Promedio_Notas_Curso();
            //Listar todos los alumnos y sus cursos, incluyendo los cursos que todavía
            //no han sido calificados(nota nula).
            //Alumnos_Cursos_ConYSin_Nota();
            //Listar los alumnos que han realizado más de 3 cursos distintos,
            //mostrando su DNI, nombre y número total de cursos.

            //Alumnos_3Cursos();
            //Obtener todos los cursos impartidos por un profesor concreto, mostrando el título del curso,
            //las fechas de inicio y fin y el número de alumnos matriculados en cada curso.
            //Entrada: DNI del profesor.
            //Cursos_Profesor_CantidadAlumnos();
            //Listar los cursos que no tienen ningún alumno matriculado.
            //Cursos_Sin_Alumnos();
            //Obtener un listado de alumnos trabajadores que hayan realizado algún curso junto
            //con el nombre de su empresa y la nota más alta obtenida por cada alumno.
            //Alumnos_Trabajadores_Empresa_Nota();
            //Listar todos los cursos ordenados por fecha de inicio, incluyendo el nombre del profesor y
            //el número de alumnos matriculados.
            //Cursos_FechaInicio();
            //Obtener los alumnos desempleados que hayan realizado cursos de más de 40 horas de duración,
            //mostrando su nombre, edad y título del curso.
            //Alumnos_Desemp_CursosMasDe40Horas();
            //Listar los cursos que se han impartido más de una vez, mostrando el código de curso, número
            //de veces que se ha impartido y la fecha de la primera y última impartición.
            //Cursos_Impartidos_Mas_DeUna_Vez();
            //Listar los cursos agrupados por profesor, mostrando cuántos alumnos ha tenido cada curso.
            //Cursos_Por_Profesor_Alumnos();
            //Obtener los cursos con mayor duración, mostrando título, horas y el nombre del profesor.
            //Cursos_Mas_Largos();
            //Obtener el promedio de edad de los alumnos que han realizado cursos de más de 50 horas.
            //Promedio_Edad_Alumnos();
            //Listar los cursos que tienen alumnos tanto trabajadores como desempleados, mostrando el título
            //del curso y el número de cada tipo de alumno.
            //Cursos_Alumnos_Trabajadores_Desempleados();
            //Obtener los alumnos que han participado en cursos impartidos por un profesor concreto y han
            //obtenido una nota superior al promedio de ese curso.
            Profesor_Alumnos_Curso_Notas();

            //Obtener el curso con la mayor cantidad de alumnos matriculados y mostrar el título, el profesor y
            //el número total de alumnos.
            //Curso_MaxMatriculados();


        }

        private static void Profesor_Alumnos_Curso_Notas()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query20 = context.Imparticions
                        .Where(i => i.Profesor.Nombre == "Laura")
                        .Select(i => new
                        {
                            Curso = i.Curso.Titulo,
                            MediaCurso = i.Notas.Average(n => n.Valor),
                            Alumnos = i.Notas
                                .Where(n => n.Valor > i.Notas.Average(x => x.Valor)) 
                                .Select(n => n.Alumno.Nombre)
                                .Distinct()
                                .ToList()
                        })
                        .ToList();
                foreach (var item in query20)
                {
                    Console.WriteLine($"Curso: {item.Curso}, Media: {item.MediaCurso:F2}");
                    Console.WriteLine("Alumnos con nota superior a la media:");
                    foreach (var alumno in item.Alumnos)
                    {
                        Console.WriteLine($" - {alumno}");
                    }
                }

            }
        }

        private static void Curso_MaxMatriculados()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query21 = context.Imparticions

                    .Select(i => new
                    {
                        nombre = i.Curso.Titulo,
                        profesor = i.Profesor.Nombre + " " + i.Profesor.Apellidos,
                        cantidad = i.Notas.Select(x => x.Alumno.AlumnoId).Distinct().Count()
                    }).OrderByDescending(x => x.cantidad).FirstOrDefault();

                Console.WriteLine($"Curso con mas alumnos: {query21.nombre}, Profesor:{query21.profesor}," +
                    $" CantidadAlumnos: {query21.cantidad}");
            }
        }

        private static void Cursos_Alumnos_Trabajadores_Desempleados()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query19 = context.Cursoes
                    .Where(c =>
                        c.Imparticions.SelectMany(i => i.Notas)
                                      .Any(n => n.Alumno.EmpresaId == null) &&    
                        c.Imparticions.SelectMany(i => i.Notas)
                                      .Any(n => n.Alumno.EmpresaId != null)       
                    )
                    .Select(c => new
                    {
                        nombre = c.Titulo,
                        alumnosDesempleados = c.Imparticions
                            .SelectMany(i => i.Notas)
                            .Count(n => n.Alumno.EmpresaId == null),
                        alumnosTrabajadores = c.Imparticions
                            .SelectMany(i => i.Notas)
                            .Count(n => n.Alumno.EmpresaId != null)
                    })
                    .ToList();

                foreach (var item in query19)
                {
                    Console.WriteLine(
                        $"Curso: {item.nombre}, " +
                        $"Desempleados: {item.alumnosDesempleados}, " +
                        $"Trabajadores: {item.alumnosTrabajadores}"
                    );
                }
            }
        }


        private static void Promedio_Edad_Alumnos()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query18 = context.Notas
                    .Where(n => n.Imparticion.Curso.Horas > 50)
                    .Select(n => n.Alumno.Edad).Distinct().ToList();
                if (query18.Any())
                {
                    double promedio = query18.Average();
                    Console.WriteLine($"Promedio de edad de alumnos que realizaron cursos de más de 50 horas: {promedio:F2}");

                }
                else
                {
                    Console.WriteLine("No hay alumnos en cursos de más de 50 horas.");
                }
            }
        }

        private static void Cursos_Mas_Largos()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query17 = context.Imparticions
                    .Select(i => new
                    {
                        nombre = i.Curso.Titulo,
                        horas = i.Curso.Horas,
                        profesor = i.Profesor.Nombre + " " + i.Profesor.Apellidos
                    }).OrderByDescending(i => i.horas).Take(2).ToList();
                foreach (var item in query17) { 
                    Console.WriteLine($"Nombre curso: {item.nombre}, Horas: {item.horas}, Profesor: {item.profesor}");
                }
            }
        }

        private static void Cursos_Por_Profesor_Alumnos()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query16 = (from i in context.Imparticions
                               group i.Curso by i.Profesor
                                into g
                               select new
                               {
                                   profesor = g.Key.Nombre + " " + g.Key.Apellidos,
                                   cursos = g.Select(x => new
                                   {
                                       nombre= x.Titulo,
                                       canridadA= x.Imparticions.Select(y=>y.Notas.Select(a=>a.Alumno.AlumnoId)).Count()
                                   }).ToList(),
                                   
                               }).ToList();
                foreach(var item in query16)
                {
                    Console.WriteLine($"Profesor {item.profesor}");
                    foreach(var item2 in item.cursos)
                    {
                        Console.WriteLine($"Nombre curso: {item2.nombre}, Cantidad alumnos: {item2.canridadA}");
                    }
                }
            }
        }

        private static void Cursos_Impartidos_Mas_DeUna_Vez()
        {
            using(var context= new AcademiaClasesDBEntities1())
            {
                var query15 = context.Cursoes
                    .Where(c => c.Imparticions.Count() > 1)
                    .Select(c => new
                    {
                        codigo = c.Codigo,
                        numeroImparticiones = c.Imparticions.Count(),
                        fechaPrimeraImparticion = c.Imparticions.Min(x=>x.FechaInicio),
                        fechaUltimaImparticion = c.Imparticions.Max(x=>x.FechaInicio)
                    }).ToList();
                foreach (var item in query15) {
                    Console.WriteLine($"Codigo: {item.codigo}, Numero de veces Impartido: {item.numeroImparticiones}" +
                        $", Primera Fecha: {item.fechaPrimeraImparticion.ToShortDateString()}, " +
                        $"Ultima Imparticion: {item.fechaUltimaImparticion.ToShortDateString()}");
                }
            }
        }

        private static void Alumnos_Desemp_CursosMasDe40Horas()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                

                var query14a = context.Notas
                    .Where(n => n.Alumno.EmpresaId == null && n.Imparticion.Curso.Horas > 40)
                    .Select(n => new
                    {
                        nombre = n.Alumno.Nombre,
                        edad = n.Alumno.Edad,
                        cursoT = n.Imparticion.Curso.Titulo

                    }).ToList();
                foreach (var item in query14a)
                {
                    Console.WriteLine($"Nombre: {item.nombre}, Edad: {item.edad}, Curso: {item.cursoT}");
                }
            }      
        }

        private static void Cursos_FechaInicio()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query13 = context.Imparticions
                    .Select(i => new
                    {
                        curso = i.Curso.Titulo,
                        fechaI = i.FechaInicio,
                        profesor = i.Profesor.Nombre + " " + i.Profesor.Apellidos,
                        cantidadA = i.Notas.Select(x => x.Alumno.AlumnoId).Distinct().Count()
                    }).OrderBy(x => x.fechaI).ToList();
                foreach (var item in query13) {
                    Console.WriteLine($"Curso {item.curso}, Fecha {item.fechaI.ToShortDateString()}," +
                        $" Profesor: {item.profesor}, Cantidad Alumnos Matrivulados: {item.cantidadA}");
                }
            }
        }

        private static void Alumnos_Trabajadores_Empresa_Nota()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query12 = context.Alumnoes
                    .Where(a => a.EmpresaId != null && a.Notas.Any())

                    .Select(a => new
                    {
                        nombre = a.Nombre,
                        empresa = a.Empresa.Nombre,
                        notaAlta = a.Notas.Max(x => x.Valor)
                    }).ToList();
                //En esta otra se devulve el nombre del curso al q pertenece esa nota
                //mas alta y para ello se guarda en una variable la nota mas alta 
                 var query =
                    (from a in context.Alumnoes
                    where a.EmpresaId != null && a.Notas.Any()
                    let notaMax = a.Notas.Max(n => n.Valor)
                    select new
                    {
                        nombre = a.Nombre,
                        empresa = a.Empresa.Nombre,
                        notaAlta = notaMax,
                        curso = a.Notas
                                .Where(n => n.Valor == notaMax)
                                .OrderBy(n => n.Imparticion.Curso.Titulo)
                                .Select(n => n.Imparticion.Curso.Titulo)
                                .FirstOrDefault()
                    }).ToList();
                foreach ( var a in query)
                {
                    Console.WriteLine($"Alumno: {a.nombre}, Empresa: {a.empresa}, NotaMasAlta: {a.notaAlta}, Curso: {a.curso}");
                }

            }
        }



        private static void Cursos_Sin_Alumnos()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query11 = context.Cursoes
                    .Where(c => c.Imparticions.Count() == 0|| 
                    c.Imparticions.SelectMany(n=>n.Notas).Select(y=>y.AlumnoId).Distinct().Count()==0).ToList();
                foreach(var item in query11)
                {
                    Console.WriteLine(item.Titulo+" "+ item.CursoId);
                }
            }
        }

        private static void Cursos_Profesor_CantidadAlumnos()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query10 = (from n in context.Notas
                               where n.Imparticion.Profesor.DNI == "P1111111"
                               group n by n.Imparticion into g
                               select new
                               {
                                   CursoN = g.Key.Curso.Titulo,
                                   FechaInicioC = g.Key.FechaInicio,
                                   FechaFinC = g.Key.FechaFin,
                                   NumeroAlumns = g.Select(x => x.Alumno.AlumnoId).Distinct().Count()
                               }).ToList();
                foreach (var n in query10)
                {
                    Console.WriteLine($"Curso: {n.CursoN}, FechaI: ´{n.FechaInicioC.ToShortDateString()}, FechaF: {n.FechaFinC.ToShortDateString()}, NumeroA: {n.NumeroAlumns}");
                }
            }
            
        }

        private static void Alumnos_3Cursos()
        {
            using (var context = new AcademiaClasesDBEntities1())
            {
                var query9 = (from n in context.Notas
                              group n by n.Alumno into g
                              where g.Select(x=>x.Imparticion.Curso.CursoId).Distinct().Count()>3

                              select new
                              {
                                  Dni = g.Key.DNI,
                                  NombreA = g.Key.Nombre,
                                  Cursos = g.Select(x => x.Imparticion.Curso.CursoId).Distinct().Count()
                              }
                            ).ToList();
                foreach (var c in query9) {
                    Console.WriteLine($"Nombre: {c.NombreA}, Dni: {c.Dni}, Cursos: {c.Cursos}");
                }
                var query9a = (from n in context.Notas
                                       // 1. Agrupar por alumno
                                   group n by n.Alumno into g

                                   // 2. Calcular el conteo de cursos distintos UNA SOLA VEZ
                                   let cursosDistintos = g.Select(x => x.Imparticion.Curso.CursoId).Distinct().Count()

                                   // 3. Filtrar usando esa variable
                                   where cursosDistintos > 3

                                   // 4. Seleccionar los resultados
                                   select new
                                   {
                                       Dni = g.Key.DNI,
                                       NombreA = g.Key.Nombre,
                                       Cursos = cursosDistintos // Usar la misma variable
                                   }
                    ).ToList();
                foreach (var c in query9a)
                {
                    Console.WriteLine($"Nombre: {c.NombreA}, Dni: {c.Dni}, Cursos: {c.Cursos}");
                }
            }
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
