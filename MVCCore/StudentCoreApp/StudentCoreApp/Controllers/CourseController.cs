using Microsoft.AspNetCore.Mvc;

namespace StudentCoreApp.Controllers
{
    public class CourseController : Controller
    {
        static List<string> allCourses = new List<string>
        {
            "Jave", "C#","Agile"
        };
        //interface nivel encima del actionresult, lo engloba
        public IActionResult AllCourse()
        {
            ViewData["Courses"] = allCourses;
            return View();
        }
        public IActionResult AddCourse() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddCourse(string courseTitle)
        {
            allCourses.Add(courseTitle);
            return RedirectToAction("AllCourse","Course");
        }
    }
}
