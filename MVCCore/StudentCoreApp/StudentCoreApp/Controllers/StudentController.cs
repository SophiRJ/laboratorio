using Microsoft.AspNetCore.Mvc;
using StudentCoreApp.Models;
using StudentCoreApp.ViewModel;

namespace StudentCoreApp.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> allStudents = new List<Student>();
        static List<Major> allMajors= new List<Major>
        {
            new Major(){MajorId=1,MajorName="Computer Science"},
            new Major(){MajorId=2,MajorName="Business Computer"},
            new Major(){MajorId=999,MajorName="Undecided"}
        };
        public IActionResult AllStudent()
        {
            return View(allStudents);
        }
        public IActionResult AddStudent()
        {
            var majorDisplay = allMajors.Select(x => new { Id = x.MajorId, Value = x.MajorName });
            StudentAllStudentViewModel vm= new StudentAllStudentViewModel();
            vm.MajorList = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(majorDisplay, "Id", "Value");
            return View(vm);
        }
        [HttpPost]
        public IActionResult AddStudent(StudentAllStudentViewModel vm)
        {
            var major = allMajors.SingleOrDefault(m => m.MajorId == vm.Major!.MajorId);
            vm.Student!.Major = major;
            allStudents.Add(vm.Student);
            return RedirectToAction("AllStudent");

            //allStudents.Add(student);
            //return RedirectToAction("AllStudent");
        }
    }
}
;