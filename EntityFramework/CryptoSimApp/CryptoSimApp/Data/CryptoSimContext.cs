using CryptoSimApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSimApp.Data
{
    public class CryptoSimContext : DbContext
    {
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Criptomoneda> Criptomonedas => Set<Criptomoneda>();
        public DbSet<Operacion> Operaciones => Set<Operacion>();
        public DbSet<Portafolio> Portafolios => Set<Portafolio>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=CryptoSimDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Portafolio>().HasKey(p => new { p.UsuarioId, p.CriptomonedaId });

            // Relaciones
            modelBuilder.Entity<Portafolio>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Portafolios)
                .HasForeignKey(p => p.UsuarioId);

            modelBuilder.Entity<Portafolio>()
                .HasOne(p => p.Criptomoneda)
                .WithMany(c => c.Portafolios)
                .HasForeignKey(p => p.CriptomonedaId);

            modelBuilder.Entity<Operacion>()
                .HasOne(o => o.Usuario)
                .WithMany(u => u.Operaciones)
                .HasForeignKey(o => o.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Operacion>()
                .HasOne(o => o.Criptomoneda)
                .WithMany(c => c.Operaciones)
                .HasForeignKey(o => o.CriptomonedaId)
                .OnDelete(DeleteBehavior.Restrict);

            // --- SEED DATA ---
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nombre = "Alice", Email = "alice@crypto.com", SaldoVirtual = 10000 },
                new Usuario { Id = 2, Nombre = "Bob", Email = "bob@crypto.com", SaldoVirtual = 7500 },
                new Usuario { Id = 3, Nombre = "Charlie", Email = "charlie@crypto.com", SaldoVirtual = 5000 }
            );

            modelBuilder.Entity<Criptomoneda>().HasData(
                new Criptomoneda { Id = 1, Nombre = "Bitcoin", Simbolo = "BTC", ValorActual = 68000 },
                new Criptomoneda { Id = 2, Nombre = "Ethereum", Simbolo = "ETH", ValorActual = 3800 },
                new Criptomoneda { Id = 3, Nombre = "Cardano", Simbolo = "ADA", ValorActual = 1.2 }
            );

            modelBuilder.Entity<Portafolio>().HasData(
                new Portafolio { UsuarioId = 1, CriptomonedaId = 1, CantidadActual = 0.15 },
                new Portafolio { UsuarioId = 1, CriptomonedaId = 2, CantidadActual = 1.5 },
                new Portafolio { UsuarioId = 2, CriptomonedaId = 3, CantidadActual = 1000 },
                new Portafolio { UsuarioId = 3, CriptomonedaId = 2, CantidadActual = 0.8 }
            );

            modelBuilder.Entity<Operacion>().HasData(
                new Operacion { Id = 1, UsuarioId = 1, CriptomonedaId = 1, TipoOperacion = "Compra", Cantidad = 0.1, PrecioUnitario = 60000, Fecha = new DateTime(2025, 1, 10) },
                new Operacion { Id = 2, UsuarioId = 1, CriptomonedaId = 2, TipoOperacion = "Compra", Cantidad = 1.0, PrecioUnitario = 3500, Fecha = new DateTime(2025, 2, 15) },
                new Operacion { Id = 3, UsuarioId = 2, CriptomonedaId = 3, TipoOperacion = "Compra", Cantidad = 1000, PrecioUnitario = 1.0, Fecha = new DateTime(2025, 3, 1) }
            );
        }
    }
}
