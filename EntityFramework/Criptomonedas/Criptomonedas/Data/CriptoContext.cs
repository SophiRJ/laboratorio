using Criptomonedas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptomonedas.Data
{
    public class CriptoContext:DbContext
    {
        public CriptoContext() { }
        public CriptoContext(DbContextOptions<CriptoContext> options) : base(options) { }

        //DbSets

        public DbSet<Criptomoneda> Criptomonedas => Set<Criptomoneda>();
        public DbSet<Operacion> Operaciones => Set<Operacion>();
        public DbSet<Portafolio> Portafolios => Set<Portafolio>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();

        //Conexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CriptoDatabase;Trusted_Connection=True;");
            }
        }
        //modle
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Portafolio>().HasKey(cu => new { cu.UsuarioId, cu.CriptomonedaId });

            //Relaciones
            modelBuilder.Entity<Operacion>()//controlar cuando borro una operacion como afecta al usuario
                .HasOne(o=>o.Usuario)
                .WithMany(us=>us.Operaciones)
                .HasForeignKey(o=>o.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Operacion>()
                .HasOne(o=>o.Criptomoneda)
                .WithMany(cr=>cr.Operaciones)
                .HasForeignKey(o=>o.CriptomonedaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Portafolio>()
                .HasOne(p => p.Criptomoneda)
                .WithMany(cr => cr.Portafolios)
                .HasForeignKey(p => p.CriptomonedaId);
                //.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Portafolio>()
                .HasOne(p => p.Usuario)
                .WithMany(us => us.Portafolios)
                .HasForeignKey(p => p.UsuarioId);//si un portfolio seboora no afecta a un usuario 
                //.OnDelete(DeleteBehavior.Restrict);//no hace falta el ondelete

            // Semilla de Datos (Data Seeding)

            // 1. Entidades sin claves foráneas primero
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nombre = "Ana García", SaldoVirtual = 10000, Email = "ana@mail.com" },
                new Usuario { Id = 2, Nombre = "Luis Torres", SaldoVirtual = 5000, Email = "luis@mail.com" }
            );

            modelBuilder.Entity<Criptomoneda>().HasData(
                new Criptomoneda { Id = 1, Nombre = "Bitcoin", Simbolo = "BTC", ValorActual = 60000 },
                new Criptomoneda { Id = 2, Nombre = "Ethereum", Simbolo = "ETH", ValorActual = 3000 },
                new Criptomoneda { Id = 3, Nombre = "Solana", Simbolo = "SOL", ValorActual = 150 }
            );

            // 2. Entidades de unión (con claves foráneas)

            // Portafolios (Qué posee cada usuario)
            modelBuilder.Entity<Portafolio>().HasData(
                // Ana (1) posee Bitcoin (1)
                new Portafolio { UsuarioId = 1, CriptomonedaId = 1, CantidadActual = 1 },
                // Ana (1) posee Ethereum (2)
                new Portafolio { UsuarioId = 1, CriptomonedaId = 2, CantidadActual = 5 },
                // Luis (2) posee Solana (3)
                new Portafolio { UsuarioId = 2, CriptomonedaId = 3, CantidadActual = 20 }
            );

            // Operaciones (Historial de transacciones)
            modelBuilder.Entity<Operacion>().HasData(
                new Operacion
                {
                    Id = 1,
                    UsuarioId = 1,
                    CriptomonedaId = 1,
                    TipoOperacion = "Compra",
                    Cantidad = 1,
                    PrecioUnitario = 58000,
                    // VALOR ESTÁTICO (HARDCODEADO)
                    Fecha = new DateTime(2025, 10, 20, 10, 30, 0, DateTimeKind.Utc)
                },
                new Operacion
                {
                    Id = 2,
                    UsuarioId = 1,
                    CriptomonedaId = 2,
                    TipoOperacion = "Compra",
                    Cantidad = 5,
                    PrecioUnitario = 2900,
                    // VALOR ESTÁTICO (HARDCODEADO)
                    Fecha = new DateTime(2025, 10, 25, 11, 0, 0, DateTimeKind.Utc)
                },
                new Operacion
                {
                    Id = 3,
                    UsuarioId = 2,
                    CriptomonedaId = 3,
                    TipoOperacion = "Compra",
                    Cantidad = 20,
                    PrecioUnitario = 145,
                    // VALOR ESTÁTICO (HARDCODEADO)
                    Fecha = new DateTime(2025, 11, 1, 12, 15, 0, DateTimeKind.Utc)
                    //Fecha = new DateTime(2025, 3, 1)
                }
            );
        }
    }
}
