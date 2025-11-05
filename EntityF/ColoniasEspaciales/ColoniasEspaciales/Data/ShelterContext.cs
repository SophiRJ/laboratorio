using ColoniasEspaciales.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoniasEspaciales.Data
{
    public class ShelterContext:DbContext
    {
        public DbSet<Colonia> Colonias => Set<Colonia>();
        public DbSet<Habitante> Habitantes => Set<Habitante>();
        public DbSet<Evento> Eventos => Set<Evento>();
        public DbSet<Planeta> Planetas => Set<Planeta>();
        public DbSet<Recurso> Recursos => Set<Recurso>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ColoniasShelterDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PLANETAS
            modelBuilder.Entity<Planeta>().HasData(
                new Planeta { Id = 1, Nombre = "Tierra" },
                new Planeta { Id = 2, Nombre = "Marte" },
                new Planeta { Id = 3, Nombre = "Europa" }
            );

            // COLONIAS
            modelBuilder.Entity<Colonia>().HasData(
                new Colonia { Id = 1, Nombre = "Colonia Alpha", PlanetaId = 1 },
                new Colonia { Id = 2, Nombre = "Colonia Beta", PlanetaId = 2 },
                new Colonia { Id = 3, Nombre = "Colonia Gamma", PlanetaId = 3 }
            );

            // RECURSOS
            modelBuilder.Entity<Recurso>().HasData(
                new Recurso { Id = 1, Nombre = "Agua", Cantidad = 5000 },
                new Recurso { Id = 2, Nombre = "Oxígeno", Cantidad = 8000 },
                new Recurso { Id = 3, Nombre = "Comida", Cantidad = 3000 },
                new Recurso { Id = 4, Nombre = "Energía", Cantidad = 12000 }
            );

            // HABITANTES
            modelBuilder.Entity<Habitante>().HasData(
                new Habitante { Id = 1, Nombre = "Alicia Vega", Genero = "F", ColoniaId = 1 },
                new Habitante { Id = 2, Nombre = "Carlos Ruiz", Genero = "M", ColoniaId = 1 },
                new Habitante { Id = 3, Nombre = "Lucía Torres", Genero = "F", ColoniaId = 2 },
                new Habitante { Id = 4, Nombre = "Héctor Ramírez", Genero = "M", ColoniaId = 3 }
            );

            // EVENTOS
            modelBuilder.Entity<Evento>().HasData(
                new Evento { Id = 1, Name = "Tormenta de arena", Descripcion = "Una fuerte tormenta afecta los paneles solares.", ColoniaId = 2 },
                new Evento { Id = 2, Name = "Descubrimiento de agua", Descripcion = "Se ha encontrado una fuente de agua subterránea.", ColoniaId = 3 },
                new Evento { Id = 3, Name = "Epidemia leve", Descripcion = "Una pequeña gripe afecta a algunos colonos.", ColoniaId = 1 }
            );

            // RELACIÓN MUCHOS A MUCHOS (COLONIA - RECURSO)
            // Como EF Core crea automáticamente la tabla intermedia, también puedes poblarla:
            modelBuilder.Entity<Colonia>()
                .HasMany(c => c.Recursos)
                .WithMany(r => r.Colonias)
                .UsingEntity(j => j.HasData(
                    // Colonia Alpha (Tierra)
                    new { ColoniasId = 1, RecursosId = 1 }, // Agua
                    new { ColoniasId = 1, RecursosId = 2 }, // Oxígeno
                    new { ColoniasId = 1, RecursosId = 3 }, // Comida

                    // Colonia Beta (Marte)
                    new { ColoniasId = 2, RecursosId = 2 }, // Oxígeno
                    new { ColoniasId = 2, RecursosId = 4 }, // Energía

                    // Colonia Gamma (Europa)
                    new { ColoniasId = 3, RecursosId = 1 }, // Agua
                    new { ColoniasId = 3, RecursosId = 4 }  // Energía
                ));
        }

    }
}
