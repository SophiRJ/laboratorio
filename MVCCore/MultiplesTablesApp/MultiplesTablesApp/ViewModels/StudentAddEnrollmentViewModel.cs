using Microsoft.AspNetCore.Mvc.Rendering;
using MultiplesTablesApp.Models;

namespace MultiplesTablesApp.ViewModels
{
    public class StudentAddEnrollmentViewModel
    {
        public Enrollment? Enrollment { get; set; }
        public SelectList? StudentList { get; set; }
    }
}
