namespace BusinessSchool.Models
{
    public class StudentClub
    {
        public int StudentId { get; set; }
        public int ClubId { get; set; }
        public Student? Student{ get; set; }
        public Club? Club { get; set; }
    }
}
