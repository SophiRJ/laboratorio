using Microsoft.AspNetCore.Mvc;
using ProyectoEmpleadosGeneral.Models;
using ProyectoEmpleadosGeneral.ViewModel;

namespace ProyectoEmpleadosGeneral.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> allEmployees = new List<Employee>();

        static List<Departament> allDepartaments= new List<Departament>
        {
            new Departament(){DepartamentId=1,DepartamentName="Accounting"},
            new Departament(){DepartamentId=2,DepartamentName="Information Technology"},
            new Departament(){DepartamentId=3,DepartamentName="Marketing"}
        };
        public decimal CalcularMedia()
        {
            decimal media= allEmployees.Count == 0? 0: allEmployees.Average(e => e.PricePerHour);
            
            return media;
        }
        public IActionResult AllEmployees()
        {
            ViewBag.Media = CalcularMedia(); 
            
            return View(allEmployees);
        }

        public IActionResult AddEmployee()
        {
            var departmentDisplay = allDepartaments.Select(x => new { Id = x.DepartamentId, Value = x.DepartamentName });
            EmployeeAllEmployesViewModel vm = new EmployeeAllEmployesViewModel();
            vm.DepartamentList= new Microsoft.AspNetCore.Mvc.Rendering.SelectList(departmentDisplay,"Id","Value");
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeAllEmployesViewModel vm)
        {
            var department = allDepartaments.SingleOrDefault(d => d.DepartamentId == vm.Departament!.DepartamentId);
            vm.Employee!.Departament = department;
            allEmployees.Add(vm.Employee);
            return RedirectToAction("AllEmployees");
            //allEmployees.Add(employee);
            //return RedirectToAction("AllEmployees");
        }
        [HttpPost]
        public IActionResult DeleteEmployees(List<int> selectedId)
        {
            allEmployees.RemoveAll(e => selectedId.Contains(e.EmployeeId));
            return RedirectToAction("AllEmployees");
            //    var toDelete = allEmployees
            //      .Where(e => selectedId.Contains(e.EmployeeId))
            //      .ToList();

            //    foreach (var emp in toDelete)
            //    {
            //        allEmployees.Remove(emp);
            //    }

            //    return RedirectToAction("AllEmployees");

        }

    }


}
