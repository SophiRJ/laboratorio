using BusinessSchool.Data;
using BusinessSchool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessSchool.Controllers
{
    public class DepartmentController : Controller
    {
        BusinessSchoolDbContext? _db;
        public DepartmentController(BusinessSchoolDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> AllDepartment()
        {
            var department =await _db!.Departments.ToListAsync();
            return View(department);
        }
        public IActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department department)
        { 
            _db!.Add(department);// genérico _db.Departments.Add(department); // explícito
            await _db.SaveChangesAsync();
            return RedirectToAction("AllDepartment");
        }
        public async Task<IActionResult> DepartmentDetails(int? id)
        {
            Department? department= await _db!.Departments.
                SingleOrDefaultAsync(d=>d.DepartmentId == id);  
            return View(department);
        }
        
    }
}
