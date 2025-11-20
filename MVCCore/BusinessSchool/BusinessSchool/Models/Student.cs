namespace BusinessSchool.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public ICollection<StudentClub> StudentClubs { get; set; } = new List<StudentClub>();
    }
}

