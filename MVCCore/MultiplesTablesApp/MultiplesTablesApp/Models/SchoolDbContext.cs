using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Emit;

namespace MultiplesTablesApp.Models
{
    public class SchoolDbContext:DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student > Students { get; set; }
        public DbSet<Enrollment> Enrollments{ get; set; }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

      
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Semilla existente de Instructors---
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { InstructorId = 1, InstructorName = "Prof.AliceJohnson", Email = "alice@academy.com", Phone = "555-1234", Office = "Room 101"},
            new Instructor { InstructorId = 2, InstructorName = "Dr.BobSmith", Email = "bob@academy.com", Phone = "555-5678", Office = "Room 102"},
            new Instructor { InstructorId = 3, InstructorName = "Dra.CarolBrown", Email = "carol@academy.com", Phone = "555-9012", Office = "Room 103"}
        );

            // --- Semilla existente de Courses---
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseTitle = "Introduction to Programming",SeatCapacity = 30, InstructorId = 1 },
            new Course { CourseId = 2, CourseTitle = "Database Systems", SeatCapacity = 25, InstructorId = 2 },
            new Course { CourseId = 3, CourseTitle = "Advanced Mathematics", SeatCapacity = 20, InstructorId = 3 }
        );

            // --- Semilla de Students---
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, StudentName = "John Doe"},
            new Student { StudentId = 2, StudentName = "Jane Smith" },
            new Student { StudentId = 3, StudentName = "Alice Brown" }
        );

            // --- Semilla de Enrollments---
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 1 },
            new Enrollment { EnrollmentId = 2, StudentId = 1, CourseId = 2 },
            new Enrollment { EnrollmentId = 3, StudentId = 2, CourseId = 1 },
            new Enrollment { EnrollmentId = 4, StudentId = 3, CourseId = 3 }
        );
        }
    }
}

