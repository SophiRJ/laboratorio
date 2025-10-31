using Microsoft.EntityFrameworkCore;
using RefugioAnimalesApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioAnimalesApp.Data
{
    public class ShelterContext:DbContext
    {
        public DbSet<Animal> Animals => Set<Animal>();
        public DbSet<Adopter> Adopters=>Set<Adopter>();
        public DbSet<Adoption> Adoption=> Set<Adoption>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AnimalShelterDB;Trusted_Connection=True;");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relaciones
            modelBuilder.Entity<Adoption>()
                .HasOne(a => a.Animal)
                .WithMany(an => an.Adoptions)
                .HasForeignKey(a => a.AnimalId);

            modelBuilder.Entity<Adoption>()
                .HasOne(a => a.Adopter)
                .WithMany(ad => ad.Adoptions)
                .HasForeignKey(a => a.AdoterId);

            //Semilla de datos 
            modelBuilder.Entity<Animal>().HasData(
               new Animal { Id = 1, Name = "Rex", Species = "Perro", Age = 3 },
               new Animal { Id = 2, Name = "Misu", Species = "Gato", Age = 2 },
               new Animal { Id = 3, Name = "Luna", Species = "Conejo", Age = 1 }
           );

            modelBuilder.Entity<Adopter>().HasData(
                new Adopter { Id = 1, FullName = "Carla Núñez", Phone = "123-456-789" },
                new Adopter { Id = 2, FullName = "Mario Rivas", Phone = "555-111-222" }
            );

            modelBuilder.Entity<Adoption>().HasData(
                new Adoption
                {
                    Id = 1,
                    AnimalId = 1,
                    AdoterId = 1,
                    AdoptionDate = new DateTime(2025, 10, 1)
                },
                new Adoption
                {
                    Id = 2,
                    AnimalId = 2,
                    AdoterId = 2,
                    AdoptionDate = new DateTime(2025, 10, 15)
                }
            );
        }
    }
}
