using ColoniasE.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoniasE.Data
{
    public class ColoniasContext: DbContext
    {
        public ColoniasContext() { }
        public ColoniasContext(DbContextOptions<ColoniasContext> options) : base(options) { }

        //DbSets
        public DbSet<Colonia> Colonia => Set<Colonia>();
        public DbSet<Habitante> Habitantes => Set<Habitante>();
        public DbSet<Recurso> Recursos=> Set<Recurso>();
        public DbSet<ColoniaRecurso> coloniaRecursos => Set<ColoniaRecurso>();
        public DbSet<Evento> Evento => Set<Evento>();
        public DbSet<Planeta> Planeta => Set<Planeta>();

        //Conexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ColoniasDatabase;Trusted_Connection=True;");
            }
        }
        //Configuracion de modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ColoniaRecurso>().HasKey(cr => new { cr.ColoniaId, cr.RecursoId });

            //Relaciones
            modelBuilder.Entity<Colonia>()
                .HasOne(c=>c.Planeta)
                .WithMany(p=>p.Colonias)
                .HasForeignKey(c=>c.PlanetaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Habitante>()
                 .HasOne(c => c.Colonia)
                 .WithMany(c => c.Habitantes)
                 .HasForeignKey(h => h.ColoniaId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Colonia)
                .WithMany(c => c.Eventos)
                .HasForeignKey(e => e.ColoniaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ColoniaRecurso>()
                .HasOne(cr => cr.Colonia)
                .WithMany(c => c.ColoniaRecursos)
                .HasForeignKey(cr => cr.ColoniaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ColoniaRecurso>()
                .HasOne(cr=>cr.Recurso)
                .WithMany(r=>r.ColoniaRecurso)
                .HasForeignKey(cr=>cr.RecursoId)
                .OnDelete(DeleteBehavior.Restrict);

            //semilla
            modelBuilder.Entity<Planeta>().HasData(
        new Planeta { Id = 1, Nombre = "Marte", Tipo = "Rocoso", TemperaturaPromedio = -60 },
        new Planeta { Id = 2, Nombre = "Europa", Tipo = "Helado", TemperaturaPromedio = -150 },
        new Planeta { Id = 3, Nombre = "Kepler-442b", Tipo = "Habitable", TemperaturaPromedio = 22 }
    );

            modelBuilder.Entity<Colonia>().HasData(
                new Colonia { Id = 1, Nombre = "Nova Terra", PlanetaId = 3, NivelSostenibilidad = 85 },
                new Colonia { Id = 2, Nombre = "Mars Alpha", PlanetaId = 1, NivelSostenibilidad = 60 },
                new Colonia { Id = 3, Nombre = "Europa Base", PlanetaId = 2, NivelSostenibilidad = 45 }
            );

            modelBuilder.Entity<Habitante>().HasData(
                new Habitante { Id = 1, Nombre = "Lena", Rol = "Ingeniera", ColoniaId = 1 },
                new Habitante { Id = 2, Nombre = "Kai", Rol = "Científico", ColoniaId = 1 },
                new Habitante { Id = 3, Nombre = "Ronan", Rol = "Agricultor", ColoniaId = 2 }
            );

            modelBuilder.Entity<Recurso>().HasData(
                new Recurso { Id = 1, Nombre = "Agua", CantidadTotal = 1000 },
                new Recurso { Id = 2, Nombre = "Oxígeno", CantidadTotal = 800 },
                new Recurso { Id = 3, Nombre = "Comida", CantidadTotal = 500 }
            );

            modelBuilder.Entity<ColoniaRecurso>().HasData(
                new ColoniaRecurso { ColoniaId = 1, RecursoId = 1, Cantidad = 400 },
                new ColoniaRecurso { ColoniaId = 1, RecursoId = 3, Cantidad = 300 },
                new ColoniaRecurso { ColoniaId = 2, RecursoId = 2, Cantidad = 200 }
            );

            modelBuilder.Entity<Evento>().HasData(
                new Evento { Id = 1, Tipo = "Meteorito", Descripcion = "Impacto menor en las cercanías.", Fecha = new DateTime(2125, 5, 12), ColoniaId = 2 },
                new Evento { Id = 2, Tipo = "Descubrimiento", Descripcion = "Nueva fuente de agua subterránea.", Fecha = new DateTime(2125, 6, 18), ColoniaId = 1 }
            );
        }
        }
}
