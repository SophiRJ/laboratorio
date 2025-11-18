using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCoreApp.Models;

namespace StudentCoreApp.ViewModel
{
    public class StudentAllStudentViewModel
    {
        public Student? Student { get; set; }
        public Major? Major { get; set; }

        public SelectList? MajorList { get; set; }
    }
}
