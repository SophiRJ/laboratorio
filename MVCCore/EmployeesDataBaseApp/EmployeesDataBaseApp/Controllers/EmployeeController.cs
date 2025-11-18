using EmployeesDataBaseApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesDataBaseApp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDbContext? _db;
        public EmployeeController(EmployeeDbContext db)
        {
            _db = db;
        }
        public IActionResult AllEmployee()
        {
            return View(_db!.Employees);
        }
        public IActionResult AddEmployee() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _db!.Add(employee);
            _db!.SaveChanges();
            return RedirectToAction("AllEmployee");
        }

        //Get: cargar el formulario de edicion
        public IActionResult EditEmployee(int id)
        {
            var employee = _db!.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        //Post:recibe el formulario, guarda cambios
        [HttpPost]
        public IActionResult EditEmployee(Employee employee) 
        {
            _db!.Employees.Update(employee);
            _db!.SaveChanges();
            return RedirectToAction("AllEmployee");
        }

        //borrado
        public IActionResult DeleteEmployee(int id) 
        {
            var employee = _db!.Employees.Find(id);
            return View(employee);
        }

        //post
        [HttpPost]
        public IActionResult DeleteEmployee(Employee employee)
        {
            _db!.Remove(employee);
            _db!.SaveChanges();
            return RedirectToAction("AllEmployee");
        }
    }
}
