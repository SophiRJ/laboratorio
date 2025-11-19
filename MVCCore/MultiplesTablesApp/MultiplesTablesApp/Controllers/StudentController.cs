using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiplesTablesApp.Models;
using MultiplesTablesApp.ViewModels;

namespace MultiplesTablesApp.Controllers
{
    public class StudentController : Controller
    {
        SchoolDbContext _db;
        public StudentController(SchoolDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> AllStudent()
        {
            var student = await _db.Students.ToListAsync();
            return View(student);
        }
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            _db.Add(student);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllStudent");
        }

        public async Task<IActionResult> EnrollCourse(int? id)
        {
            var studentDisplay = await _db.Students
        .Select(x => new { Id = x.StudentId, Value = x.StudentName })
        .ToListAsync();

            var course = await _db.Courses.SingleOrDefaultAsync(c => c.CourseId == id);

            StudentAddEnrollmentViewModel vm = new StudentAddEnrollmentViewModel();

            vm.StudentList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(studentDisplay, "Id", "Value");

            // ---- SOLUCIÓN ----
            vm.Enrollment = new Enrollment
            {
                Student = new Student(),
                Course = new Course()
            };
            // ---------------------

            ViewBag.Course = course;
            return View(vm);
            //var studentDisplay = await _db.Students.Select(x => new
            //{
            //    Id = x.StudentId,
            //    Value = x.StudentName
            //}).ToListAsync();

            //StudentAddEnrollmentViewModel vm = new StudentAddEnrollmentViewModel();
            //vm.StudentList = new Microsoft.AspNetCore.Mvc.Rendering.
            //    SelectList(studentDisplay, "Id", "Value");

            //var course = await _db.Courses.SingleOrDefaultAsync(c => c.CourseId == id);
            //ViewBag.Course = course;
            //return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnrollCourse(StudentAddEnrollmentViewModel vm)
        {
            //Comprobar si ya esta matriculado
            if(await Comprueba(vm.Enrollment!.Course!.CourseId, 
                vm.Enrollment!.Student!.StudentId))
            {
                return RedirectToAction("Information");
            }

            var student = await _db.Students.
                SingleOrDefaultAsync(s => s.StudentId == vm.Enrollment!.Student!.StudentId);
            var course = await _db.Courses.
                SingleOrDefaultAsync(c => c.CourseId == vm.Enrollment!.Course!.CourseId);
            
            course!.SeatCapacity--;
            Enrollment enrollment = new Enrollment();
            enrollment.Course = course;
            enrollment.Student = student;

            _db.Add(enrollment);

            await _db.SaveChangesAsync();
            return RedirectToAction("AllCourse", "Course");
        }
        public ActionResult Information()
        {
            return View();
        }
        private async Task<bool> Comprueba(int courseId, int studentId)
        {
            bool encontrado;
            var enrollment = await _db.Enrollments.
                Where(e => e.Course!.CourseId == courseId &&
            e.Student!.StudentId == studentId).FirstOrDefaultAsync();
            encontrado= enrollment != null;
            return encontrado;
        }
        public async Task<IActionResult> AllClassmate(int? id)
        {
            var enrollCourse= await _db.Enrollments.
                Where(e=>e.Course!.CourseId== id).
                Include(e=>e.Student).ToListAsync();
            List<Student> classmate=new List<Student>();
            foreach (var e in enrollCourse) {
                var student = await _db.Students.
                    SingleOrDefaultAsync(s => s.StudentId == e.Student!.StudentId);
                classmate.Add(student!);
            }
            ViewData["course"] = _db.Courses.Find(id)!.CourseTitle;
            return View(classmate);
        }
    }
}
