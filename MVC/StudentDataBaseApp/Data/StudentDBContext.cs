using Microsoft.EntityFrameworkCore;
using StudentDataBaseApp.Models;

namespace StudentDataBaseApp.Data
{
    public class StudentDBContext : DbContext
    {

        public DbSet<Student> Students { get; set; }

        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options) { }



    }
}
