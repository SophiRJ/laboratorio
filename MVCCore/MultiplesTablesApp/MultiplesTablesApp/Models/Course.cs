namespace MultiplesTablesApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public int SeatCapacity { get; set; }
        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
