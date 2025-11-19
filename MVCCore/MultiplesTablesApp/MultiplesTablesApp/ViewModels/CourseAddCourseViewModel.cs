using Microsoft.AspNetCore.Mvc.Rendering;
using MultiplesTablesApp.Models;

namespace MultiplesTablesApp.ViewModels
{
    public class CourseAddCourseViewModel
    {
        public Course? Course { get; set; }
        public Instructor? Instructor { get; set; }
        public SelectList? InstructorList { get; set; }
    }
}
