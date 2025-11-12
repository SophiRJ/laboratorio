using Biblioteca.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class BibliotecaContext:DbContext
    {
        public BibliotecaContext(){}
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }
        public DbSet<Bibliotecario> Bibliotecarios => Set<Bibliotecario>();
        public DbSet<Prestamo> Prestamos=>Set<Prestamo>();
        public DbSet<Libro> Libros => Set<Libro>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BibliotecaDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relaciones
            modelBuilder.Entity<Prestamo>()
                .HasOne(p=>p.Usuario)
                .WithMany(u=>u.Prestamos)
                .HasForeignKey(p=>p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p=>p.Libro)
                .WithMany(l=>l.Prestamos)
                .HasForeignKey(p=>p.LibroId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p=>p.Bibliotecario)
                .WithMany(b=>b.Prestamos)
                .HasForeignKey(p=>p.BibliotecarioId)
                .OnDelete(DeleteBehavior.Restrict);

            //semilla
            // Usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nombre = "Ana", Edad = 25 },
                new Usuario { Id = 2, Nombre = "Luis", Edad = 30 },
                new Usuario { Id = 3, Nombre = "Sofía", Edad = 22 },
                new Usuario { Id = 4, Nombre = "Pedro", Edad = 40 }
            );

            // Libros
            modelBuilder.Entity<Libro>().HasData(
                new Libro { Id = 1, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", Genero = "Novela" },
                new Libro { Id = 2, Titulo = "El Principito", Autor = "Antoine de Saint-Exupéry", Genero = "Infantil" },
                new Libro { Id = 3, Titulo = "1984", Autor = "George Orwell", Genero = "Distopía" },
                new Libro { Id = 4, Titulo = "Don Quijote", Autor = "Miguel de Cervantes", Genero = "Clásico" },
                new Libro { Id = 5, Titulo = "Libro sin préstamos", Autor = "Autor X", Genero = "Ficción" }
            );

            // Bibliotecarios
            modelBuilder.Entity<Bibliotecario>().HasData(
                new Bibliotecario { Id = 1, Nombre = "Marta", Turno = "Mañana" },
                new Bibliotecario { Id = 2, Nombre = "Carlos", Turno = "Tarde" },
                new Bibliotecario { Id = 3, Nombre = "Lucía", Turno = "Noche" }
            );

            // Préstamos
            modelBuilder.Entity<Prestamo>().HasData(
                new Prestamo { Id = 1, FechaPrestamo = new DateTime(2025, 10, 1), FechaDevolucion = null, LibroId = 1, UsuarioId = 1, BibliotecarioId = 1 },
                new Prestamo { Id = 2, FechaPrestamo = new DateTime(2025, 9, 15), FechaDevolucion = null, LibroId = 2, UsuarioId = 2, BibliotecarioId = 2 },
                new Prestamo { Id = 3, FechaPrestamo = new DateTime(2025, 10, 6), FechaDevolucion = null, LibroId = 1, UsuarioId = 3, BibliotecarioId = 1 },
                new Prestamo { Id = 4, FechaPrestamo = new DateTime(2025, 9, 10), FechaDevolucion = null, LibroId = 3, UsuarioId = 4, BibliotecarioId = 2 },
                new Prestamo { Id = 5, FechaPrestamo = new DateTime(2025, 9, 20), FechaDevolucion = new DateTime(2025, 10, 5), LibroId = 4, UsuarioId = 1, BibliotecarioId = 3 }
            );



        }
    }
}
