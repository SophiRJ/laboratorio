using System.ComponentModel.DataAnnotations;

namespace CoreAuthenticationApp.Models
{
    public enum LetterGrade
    {
        A,B,C,D,F,I,W,P
    }
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }
        public int CourseId { get; set; }
        [DisplayFormat(NullDisplayText ="No grade")]
        public LetterGrade? LetterGrade { get; set; }
    }
}
