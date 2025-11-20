using BusinessSchool.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessSchool.ViewModels
{
    public class ClubAddClubViewModel
    {
        public Department? Department { get; set; }
        public Club? Club { get; set; }
        public SelectList? DepartmentList { get; set; }
    }
}
