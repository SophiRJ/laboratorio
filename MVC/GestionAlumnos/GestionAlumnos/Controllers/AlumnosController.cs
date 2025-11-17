using GestionAlumnos.Models;
using GestionAlumnos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAlumnos.Controllers
{
    public class AlumnosController : Controller
    {
        private static List<Profesor> Profesores = new List<Profesor>
{
    new Profesor { Id = 1, Nombre = "Prof. García" },
    new Profesor { Id = 2, Nombre = "Profª. López" },
    new Profesor { Id = 3, Nombre = "Ing. Martínez" },
    new Profesor { Id = 4, Nombre = "Prof. Fernández" },
    new Profesor { Id = 5, Nombre = "Lic. Sánchez" }
};

        // Cursos
        private static List<Curso> Cursos = new List<Curso>
{
    new Curso { Id = 1, Nombre = "Matemáticas", ProfesorId = 1 },
    new Curso { Id = 2, Nombre = "Historia Universal", ProfesorId = 2 },
    new Curso { Id = 3, Nombre = "Programación I", ProfesorId = 3 },
    new Curso { Id = 4, Nombre = "Física", ProfesorId = 1 },
    new Curso { Id = 5, Nombre = "Literatura", ProfesorId = 2 },
    new Curso { Id = 6, Nombre = "Bases de Datos", ProfesorId = 3 },
    new Curso { Id = 7, Nombre = "Educación Física", ProfesorId = 4 },
    new Curso { Id = 8, Nombre = "Economía", ProfesorId = 5 }
};

        // Alumnos
        private static List<Alumno> Alumnos = new List<Alumno>
{
    // Matemáticas
    new Alumno { Id = 1,  Nombre = "Ana Torres", CursoId = 1 },
    new Alumno { Id = 2,  Nombre = "Luis Pérez", CursoId = 1 },
    new Alumno { Id = 3,  Nombre = "María Ruiz", CursoId = 1 },

    // Historia Universal
    new Alumno { Id = 4,  Nombre = "Pedro Gómez", CursoId = 2 },
    new Alumno { Id = 5,  Nombre = "Lucía Hernández", CursoId = 2 },
    new Alumno { Id = 6,  Nombre = "Javier Morales", CursoId = 2 },

    // Programación I
    new Alumno { Id = 7,  Nombre = "Carla Ramírez", CursoId = 3 },
    new Alumno { Id = 8,  Nombre = "Andrés Ortega", CursoId = 3 },
    new Alumno { Id = 9,  Nombre = "Elena Vega", CursoId = 3 },

    // Física
    new Alumno { Id = 10, Nombre = "Raúl Sánchez", CursoId = 4 },
    new Alumno { Id = 11, Nombre = "Sara Díaz", CursoId = 4 },

    // Literatura
    new Alumno { Id = 12, Nombre = "Claudia Romero", CursoId = 5 },
    new Alumno { Id = 13, Nombre = "Fernando Rivas", CursoId = 5 },

    // Bases de Datos
    new Alumno { Id = 14, Nombre = "Esteban Núñez", CursoId = 6 },
    new Alumno { Id = 15, Nombre = "Marta Delgado", CursoId = 6 },
    new Alumno { Id = 16, Nombre = "José Muñoz", CursoId = 6 },

    // Educación Física
    new Alumno { Id = 17, Nombre = "Verónica Paredes", CursoId = 7 },
    new Alumno { Id = 18, Nombre = "Iván López", CursoId = 7 },

    // Economía
    new Alumno { Id = 19, Nombre = "Beatriz Castaño", CursoId = 8 },
    new Alumno { Id = 20, Nombre = "Tomás Aguilar", CursoId = 8 }
};

        // GET: Alumnos
        public ActionResult Index()
        {
            var vm = Alumnos.Select(a => new AlumnoProfesorCursoViewModel
            {
                NombreAlumno = a.Nombre,
                NombreCurso = Cursos.FirstOrDefault(c => c.Id == a.CursoId).Nombre,
                NombreProfesor = Profesores.FirstOrDefault(p => p.Id == 
                Cursos.FirstOrDefault(c => c.Id == a.CursoId).ProfesorId).Nombre
            }).OrderByDescending(x => x.NombreProfesor).ToList();
            return View(vm);
        }
    }
}