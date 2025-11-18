namespace StudentCoreApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public decimal GPA { get; set; }
        public Major? Major { get; set; }
    }
}
