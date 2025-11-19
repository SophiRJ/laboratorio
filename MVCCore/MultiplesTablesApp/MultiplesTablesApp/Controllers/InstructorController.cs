using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiplesTablesApp.Models;

namespace MultiplesTablesApp.Controllers
{
    public class InstructorController : Controller
    {
        SchoolDbContext? _db;
        public InstructorController(SchoolDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> AllInstructor()
        {
            var instructor = await _db!.Instructors.ToListAsync();
            return View(instructor);
        }
        public IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddInstructor(Instructor instructor)
        {
            _db!.Add(instructor);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllInstructor");
        }

        public async Task<IActionResult> InstructorDetails(int? id)
        {
            Instructor? instructor = await _db!.Instructors
                .SingleOrDefaultAsync(c => c.InstructorId == id);
            return View(instructor);
        }

       
    }
}
