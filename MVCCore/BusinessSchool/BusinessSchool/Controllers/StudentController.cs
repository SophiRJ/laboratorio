using BusinessSchool.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessSchool.Controllers
{
    public class StudentController : Controller
    {
        BusinessSchoolDbContext _db;
        public StudentController(BusinessSchoolDbContext db)
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


    }
}
