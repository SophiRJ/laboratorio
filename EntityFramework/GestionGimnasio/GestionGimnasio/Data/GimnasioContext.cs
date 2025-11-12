using GestionGimnasio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGimnasio.Data
{
    public class GimnasioContext:DbContext
    {
        public GimnasioContext()
        {}
        public GimnasioContext(DbContextOptions<GimnasioContext>options):base(options)
        {}

        //DbSets
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }

        //conexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GimnasioDatabase;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Clase>()
                .HasOne(c=>c.Entrenador)
                .WithMany(e=>e.Clases)
                .HasForeignKey(c=>c.EntrenadorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Clase)
                .WithMany(c => c.Inscripciones)
                .HasForeignKey(i => i.ClaseId);
                
            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Socio)
                .WithMany(s => s.Inscripciones)
                .HasForeignKey(i => i.SocioId);
            

            //semilla dats
            // Socios
            modelBuilder.Entity<Socio>().HasData(
                new Socio { Id = 1, Nombre = "Ana Pérez", Email = "ana@example.com" },
                new Socio { Id = 2, Nombre = "Luis Gómez", Email = "luis@example.com" },
                new Socio { Id = 3, Nombre = "Marta Ruiz", Email = "marta@example.com" },
                new Socio { Id = 4, Nombre = "Carlos Díaz", Email = "carlos@example.com" },
                new Socio { Id = 5, Nombre = "Sofía López", Email = "sofia@example.com" }
            );

            // Entrenadores
            modelBuilder.Entity<Entrenador>().HasData(
                new Entrenador { Id = 1, Nombre = "Pedro Sánchez", Especialidad = "Yoga" },
                new Entrenador { Id = 2, Nombre = "Laura Torres", Especialidad = "Crossfit" },
                new Entrenador { Id = 3, Nombre = "Javier Martín", Especialidad = "Pilates" },
                new Entrenador { Id = 4, Nombre = "Elena García", Especialidad = "Boxeo" },
                new Entrenador { Id = 5, Nombre = "Andrés Molina", Especialidad = "Natación" }
            );

            // Clases
            modelBuilder.Entity<Clase>().HasData(
                 new Clase { Id = 1, Nombre = "Yoga Básico", Nivel = "Principiante", PrecioMensual = 30m, EntrenadorId = 1 },
                 new Clase { Id = 2, Nombre = "Crossfit Avanzado", Nivel = "Avanzado", PrecioMensual = 50m, EntrenadorId = 2 },
                 new Clase { Id = 3, Nombre = "Pilates Intermedio", Nivel = "Intermedio", PrecioMensual = 40m, EntrenadorId = 3 },
                 new Clase { Id = 4, Nombre = "Boxeo Intensivo", Nivel = "Avanzado", PrecioMensual = 45m, EntrenadorId = 4 },
                 new Clase { Id = 5, Nombre = "Natación Infantil", Nivel = "Principiante", PrecioMensual = 35m, EntrenadorId = 5 }
             );


            // Inscripciones (varias para que haya clases más populares)
            modelBuilder.Entity<Inscripcion>().HasData(
                new Inscripcion { Id = 1, SocioId = 1, ClaseId = 1, FechaInicio = new DateTime(2025, 1, 10) },
                new Inscripcion { Id = 2, SocioId = 1, ClaseId = 2, FechaInicio = new DateTime(2025, 2, 5) },
                new Inscripcion { Id = 3, SocioId = 2, ClaseId = 2, FechaInicio = new DateTime(2025, 2, 7) },
                new Inscripcion { Id = 4, SocioId = 2, ClaseId = 3, FechaInicio = new DateTime(2025, 3, 1) },
                new Inscripcion { Id = 5, SocioId = 3, ClaseId = 2, FechaInicio = new DateTime(2025, 3, 15) },
                new Inscripcion { Id = 6, SocioId = 3, ClaseId = 4, FechaInicio = new DateTime(2025, 4, 1) },
                new Inscripcion { Id = 7, SocioId = 4, ClaseId = 2, FechaInicio = new DateTime(2025, 4, 10) },
                new Inscripcion { Id = 8, SocioId = 4, ClaseId = 5, FechaInicio = new DateTime(2025, 5, 1) },
                new Inscripcion { Id = 9, SocioId = 5, ClaseId = 1, FechaInicio = new DateTime(2025, 5, 5) },
                new Inscripcion { Id = 10, SocioId = 5, ClaseId = 2, FechaInicio = new DateTime(2025, 6, 1) }
            );
        }
    }
}
