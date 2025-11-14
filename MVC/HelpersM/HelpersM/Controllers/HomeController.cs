using HelpersM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpersM.Controllers
{
    public class HomeController : Controller
    {
        public static List<Pais> CrearPaises()
        {
            List<Pais> paises = new List<Pais>
            {
                new Pais() {IdPais=1,Nombre="Francia" },
                new Pais() {IdPais=2,Nombre="Argentina" },
                new Pais() {IdPais=3,Nombre="Islandia" },
                new Pais() {IdPais=4,Nombre="Inglaterra" },
            };
            var ordenados=
                paises.OrderBy(p=>p.Nombre).ToList();
            return ordenados;
            }
        // GET: Home
        public ActionResult Index()
        {
            List<Pais> paises = CrearPaises();
            var vm = new ComboPaisesViewModel();
            vm.Paises = paises;
            //LlenarDropDownList();
             return View(vm);
        }
        [HttpPost]
        public ActionResult Index(int SelectedPais)
        {
            List<Pais> paises= CrearPaises();
            var paisSeleccionado= paises.FirstOrDefault(c=>c.IdPais==SelectedPais)
                .Nombre;
            return null;
        }
        private void LlenarDropDownList(int? IdPais=0)
        {
            List<SelectListItem> Paises= new List<SelectListItem>();
            Paises.Add(new SelectListItem()
            {
                Value = "0",
                Text = "Seleccione",
                Selected = false
            });
            List<Pais> paises = CrearPaises();
            foreach(var country in paises)
            {
                Paises.Add(new SelectListItem()
                {
                    Value = country.IdPais.ToString(),
                    Text = country.Nombre.ToString(),
                    Selected = IdPais == country.IdPais ? true : false
                });
            }
            ViewData["Paises"] = Paises;
        }

        public ActionResult Pruebas()
        {
            return View();
        }
        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            return View("DisplayPerson",person);
        }
    }
}