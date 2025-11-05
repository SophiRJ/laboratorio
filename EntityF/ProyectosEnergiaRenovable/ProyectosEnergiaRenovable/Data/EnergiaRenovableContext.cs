using Microsoft.EntityFrameworkCore;
using ProyectosEnergiaRenovable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosEnergiaRenovable.Data
{
    public class EnergiaRenovableContext:DbContext
    {
        public EnergiaRenovableContext()
        {}
        public EnergiaRenovableContext(DbContextOptions<EnergiaRenovableContext> options) : base(options) { }

        //DbSets
        public DbSet<TipoEnergia> TipoEnergias => Set<TipoEnergia>();
        public DbSet<Ubicacion> Ubicaciones => Set<Ubicacion>();
        public DbSet<Proyecto> Proyectos => Set<Proyecto>();
        public DbSet<Inversor> Inversores => Set<Inversor>();
        public DbSet<Inversion> Inversiones => Set<Inversion>();

        public DbSet<Informe> Informes => Set<Informe>();

        //Conexion 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EnergiaRenvDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Inversion>().HasKey(i => new { i.ProyectoId, i.InversorId });

            //Relaciones
            modelBuilder.Entity<Proyecto>()
                .HasOne(p=>p.TipoEnergia)
                .WithMany(te=>te.Proyectos)
                .HasForeignKey(p=>p.TipoEnergiaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Proyecto>()
                .HasOne(p=>p.Ubicacion)
                .WithMany(u=>u.Proyectos)
                .HasForeignKey(p=>p.UbicacionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inversion>()
                .HasOne(i => i.Inversor)
                .WithMany(iv => iv.Inversiones)
                .HasForeignKey(i => i.InversorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Inversion>()
                .HasOne(i=>i.Proyecto)
                .WithMany(p=>p.Inversiones)
                .HasForeignKey(i=>i.ProyectoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Informe>()
                .HasOne(im => im.Proyecto)
                .WithMany(p => p.Informes)
                .HasForeignKey(im => im.ProyectoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Semilla de Datos (Data Seeding)

            // 1. Entidades sin claves foráneas (Tipos, Ubicaciones, Inversores)
            modelBuilder.Entity<TipoEnergia>().HasData(
                new TipoEnergia { Id = 1, Nombre = "Solar" },
                new TipoEnergia { Id = 2, Nombre = "Eólica" },
                new TipoEnergia { Id = 3, Nombre = "Geotérmica" }
            );

            modelBuilder.Entity<Ubicacion>().HasData(
                new Ubicacion { Id = 1, Ciudad = "Sevilla", Pais = "España" },
                new Ubicacion { Id = 2, Ciudad = "Tarifa", Pais = "España" },
                new Ubicacion { Id = 3, Ciudad = "Reykjavik", Pais = "Islandia" }
            );

            modelBuilder.Entity<Inversor>().HasData(
                new Inversor { Id = 1, Nombre = "EcoEnergy Ventures", CapitalDisponible = 5000000 },
                new Inversor { Id = 2, Nombre = "GreenFuture Capital", CapitalDisponible = 10000000 }
            );

            // 2. Entidades que dependen de las anteriores (Proyectos)
            modelBuilder.Entity<Proyecto>().HasData(
                new Proyecto { Id = 1, Nombre = "Planta Solar Andalucía", InversionTotal = 1500000, TipoEnergiaId = 1, UbicacionId = 1 },
                new Proyecto { Id = 2, Nombre = "Parque Eólico del Estrecho", InversionTotal = 3000000, TipoEnergiaId = 2, UbicacionId = 2 },
                new Proyecto { Id = 3, Nombre = "Central Geotérmica Krafla", InversionTotal = 7000000, TipoEnergiaId = 3, UbicacionId = 3 }
            );

            // 3. Entidades de unión y dependientes (Inversiones, Informes)
            modelBuilder.Entity<Inversion>().HasData(
                // EcoEnergy (1) invierte en Solar (1)
                new Inversion { ProyectoId = 1, InversorId = 1, MontoInvertido = 1000000 },
                // EcoEnergy (1) invierte en Eólica (2)
                new Inversion { ProyectoId = 2, InversorId = 1, MontoInvertido = 500000 },
                // GreenFuture (2) invierte en Geotérmica (3)
                new Inversion { ProyectoId = 3, InversorId = 2, MontoInvertido = 7000000 }
            );

            modelBuilder.Entity<Informe>().HasData(
                new Informe { Id = 1, ProyectoId = 1, Fecha = new DateTime(2025, 1, 15), EnergiaGeneradaMWh = 500 },
                new Informe { Id = 2, ProyectoId = 2, Fecha = new DateTime(2025, 2, 20), EnergiaGeneradaMWh = 1200 },
                new Informe { Id = 3, ProyectoId = 1, Fecha = new DateTime(2025, 2, 15), EnergiaGeneradaMWh = 550 },
                new Informe { Id = 4, ProyectoId = 3, Fecha = new DateTime(2025, 3, 1), EnergiaGeneradaMWh = 3000 }
            );

        }

    }
}
