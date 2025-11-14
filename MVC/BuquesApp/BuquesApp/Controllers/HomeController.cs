using BuquesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuquesApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {    
            return View();
        }
        public ActionResult Index2()
        {
            List<Barco> barcos = BarcoController.CrearFlota();
            var vm = new ComboBarcosViewModel();
            vm.Barcos = barcos;
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index2(int SelectedBarco)
        {
            List<Barco> barcos=BarcoController.CrearFlota();
            var barcoSeleccionado = barcos.FirstOrDefault(b => b.BarcoId == SelectedBarco).NombreBarco;
            return null;
        }
        private void LlenarDropDownList(int? IdBarco = 0)
        {
            List<SelectListItem> Barcos= new List<SelectListItem>();
            Barcos.Add(new SelectListItem()
            {
                Value = "0",
                Text = "Seleccione",
                Selected = false
            });
            List<Barco> barcos= BarcoController.CrearFlota();
            foreach (var board in barcos)
            {
                Barcos.Add(new SelectListItem()
                {
                    Value=board.BarcoId.ToString(),
                    Text=board.NombreBarco.ToString(),
                    Selected= IdBarco== board.BarcoId?true:false
                });
            }
            ViewData["Barcos"] = Barcos;
        }
    }
}