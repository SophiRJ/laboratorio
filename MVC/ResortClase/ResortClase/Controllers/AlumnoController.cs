using ResortClase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResortClase.Controllers
{
    public class AlumnoController : Controller
    {
        private static List<Alumno> alumnos = new List<Alumno>
        {
            new Alumno{Nombre="Marta", Trabaja=true,Edad=23,Nota=3},
            new Alumno{Nombre="Alejandro",Trabaja=false,Edad=25,Nota=8},
            new Alumno{Nombre="Sandra",Trabaja=true,Edad=19,Nota=9}
        };

        public ActionResult listarAlumnos()
        {
            return View(alumnos);
        }
        public ActionResult AlumnosTrabajan()
        {
            List<Alumno> trabajan=new List<Alumno>();
            foreach (var a in alumnos)
            {
                if (a.Trabaja == true)
                {
                    trabajan.Add(a);
                }
            }
            return View("listarAlumnos", trabajan);
        }

        public ActionResult MayorEdad()
        {
            var mayorEdad = alumnos.OrderByDescending(a => a.Edad).FirstOrDefault();
            ViewBag.Titulo = "Alumno con mas edad";
            return View(mayorEdad);
        }
        public ActionResult AlumnosSuspensosT()
        {
            List<Alumno> suspensos = new List<Alumno>();
            foreach (var a in alumnos)
            {
                if (a.Trabaja == true && a.Nota <= 5)
                {
                    suspensos.Add(a);
                }
            }
            return View("listarAlumnos",suspensos);
        }
        public ActionResult media()
        {
            var media = alumnos.Average(a => a.Nota);
            ViewBag.Nota=media;
            ViewBag.Titulo = "Nota media";
            return View("listarAlumnos", alumnos);
        }
       
        
    }
}