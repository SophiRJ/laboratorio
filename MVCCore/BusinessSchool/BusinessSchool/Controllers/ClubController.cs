using BusinessSchool.Data;
using BusinessSchool.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessSchool.Controllers
{
    public class ClubController : Controller
    {
        BusinessSchoolDbContext? _db;
        public ClubController(BusinessSchoolDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> AllClub()
        {
            var club = await _db!.Clubs.Include(c => c.Department).ToListAsync();
            return View(club);
        }

        public async Task<IActionResult> AddClub()
        {
            var departmentDisplay = await _db!.Departments.Select(x => new
            {
                Id = x.DepartmentId,
                Value = x.DepartmentName
            }).ToListAsync();
            ClubAddClubViewModel vm= new ClubAddClubViewModel();
            vm.DepartmentList = new Microsoft.AspNetCore.Mvc.Rendering
                .SelectList(departmentDisplay, "Id", "Value");
            return View(vm);
           
        }
        [HttpPost]
        public async Task<IActionResult> AddClub(ClubAddClubViewModel vm)
        {
            //sacamos el departamento elegido en el select
            var departement = await _db!.Departments.
                SingleOrDefaultAsync(d => d.DepartmentId == vm.Department!.DepartmentId);
            vm.Club!.Department = departement;
            _db.Add(vm.Club);
            await _db.SaveChangesAsync();
            return RedirectToAction("AllClub");
        }


 }
}
