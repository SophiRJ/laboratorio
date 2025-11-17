using GetPeople.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetPeople.Controllers
{
    public class PeopleController : Controller
    {
        private readonly Person[] personData = {
           new Person { FirstName = "Adam", LastName = "Freeman", Role = Role.Admin },
           new Person { FirstName = "Steven", LastName = "Sanderson", Role = Role.Admin },
           new Person { FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User },
           new Person { FirstName = "John", LastName = "Smith", Role = Role.User },
           new Person { FirstName = "Anne", LastName = "Jones", Role = Role.Guest }
       };

        // GET: People
        public ActionResult GetPeople()
        {
            var model = new PeopleViewModel
            {
                People = personData,
                SelectedRole = null
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] /*impide la inyeccion de codigo malicioso*/
        public JsonResult FilterPeople(Role? selectedRole)
        {
            var filtered = !selectedRole.HasValue 
                ? personData : personData.Where(p => p.Role == selectedRole).ToArray();
            //lo que rellenare para pasar a la vista para que pinte la tabla
            var result = filtered.Select(p => new
            {
                firstName = p.FirstName,
                lastName = p.LastName,
                role = p.Role.ToString()
            });
            return Json(result);
        }
    }
}