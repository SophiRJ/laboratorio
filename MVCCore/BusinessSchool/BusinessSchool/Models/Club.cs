namespace BusinessSchool.Models
{
    public class Club
    {
        public int ClubId { get; set; }
        public string? ClubName { get; set; }
        public int NumberOfStudents { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<StudentClub> StudentClubs { get; set; } = new List<StudentClub>();
    }
}
