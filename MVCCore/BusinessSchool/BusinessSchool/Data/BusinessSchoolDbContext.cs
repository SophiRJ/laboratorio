using BusinessSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessSchool.Data
{
    public class BusinessSchoolDbContext:DbContext
    {
        //tablas BD
        public DbSet<Department> Departments { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClub> StudentClubs { get; set; }



        //constructor
        public BusinessSchoolDbContext(DbContextOptions<BusinessSchoolDbContext> 
            options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // **** RELACIÓN N-M Student <-> Club ****
            modelBuilder.Entity<StudentClub>()
                .HasKey(sc => new { sc.StudentId, sc.ClubId });

            modelBuilder.Entity<StudentClub>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentClubs)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentClub>()
                .HasOne(sc => sc.Club)
                .WithMany(c => c.StudentClubs)
                .HasForeignKey(sc => sc.ClubId);



            // ******** SEED DATA ********
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "Computer Science",
                    PhoneNumber = "555-1001",
                    Email = "cs@businessschool.edu",
                    OfficeLocation = "Building A - Room 101"
                },
                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "Business Administration",
                    PhoneNumber = "555-2001",
                    Email = "ba@businessschool.edu",
                    OfficeLocation = "Building B - Room 205"
                },
                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "Economics",
                    PhoneNumber = "555-3001",
                    Email = "economics@businessschool.edu",
                    OfficeLocation = "Building C - Room 310"
                }
            );


            modelBuilder.Entity<Club>().HasData(
                new Club { ClubId = 1, ClubName = "AI Club", NumberOfStudents = 25, DepartmentId = 1 },
                new Club { ClubId = 2, ClubName = "Entrepreneurship Club", NumberOfStudents = 40, DepartmentId = 2 },
                new Club { ClubId = 3, ClubName = "Finance Club", NumberOfStudents = 30, DepartmentId = 3 }
            );

            // ***** SEED STUDENTS *****
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, StudentName = "Alice Johnson" },
                new Student { StudentId = 2, StudentName = "Bob Martinez" },
                new Student { StudentId = 3, StudentName = "Charlie Smith" },
                new Student { StudentId = 4, StudentName = "Diana Williams" },
                new Student { StudentId = 5, StudentName = "Ethan Brown" }
            );
            // ***** SEED STUDENTCLUB (RELACIONES N-M) *****
            modelBuilder.Entity<StudentClub>().HasData(

                // AI Club (ClubId = 1)
                new StudentClub { StudentId = 1, ClubId = 1 },
                new StudentClub { StudentId = 2, ClubId = 1 },

                // Entrepreneurship Club (ClubId = 2)
                new StudentClub { StudentId = 2, ClubId = 2 },
                new StudentClub { StudentId = 3, ClubId = 2 },

                // Finance Club (ClubId = 3)
                new StudentClub { StudentId = 4, ClubId = 3 },
                new StudentClub { StudentId = 5, ClubId = 3 }
            );

        }



    }
}
