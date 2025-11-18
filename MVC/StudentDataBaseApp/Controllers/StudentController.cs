using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDataBaseApp.Data;
using StudentDataBaseApp.Models;

namespace StudentDataBaseApp.Controllers
{
    public class StudentController : Controller
    {
        StudentDBContext? _db;

        public StudentController(StudentDBContext db)
        {
            _db = db;
        }

        public IActionResult AllStudent()
        {
            return View("AllStudentView", _db!.Students);
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _db!.Add(student);
            _db!.SaveChanges();

            return RedirectToAction("AllStudent");
        }

        // GET: Cargar el formulario de edición
        public IActionResult EditStudent(int id)
        {
            var student = _db!.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Guardar los cambios
        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            _db!.Students.Update(student);
            _db!.SaveChanges();

            return RedirectToAction("AllStudent");
        }

        public IActionResult DeleteStudent(int id)
        {
            var student = _db!.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult DeleteStudent(Student student)
        {
            _db!.Students.Remove(student);
            _db!.SaveChanges();
            return RedirectToAction("AllStudent");
        }
    }
}
