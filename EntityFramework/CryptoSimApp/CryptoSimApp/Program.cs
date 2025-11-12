using Microsoft.EntityFrameworkCore;
using CryptoSimApp.Data;
using CryptoSimApp.Models;
using SpaceColoniesSim.Repositories;


Console.WriteLine("💰 Iniciando Simulador de Bolsa de Criptomonedas...");

// Crear contexto y aplicar migraciones
using var context = new CryptoSimContext();
await context.Database.MigrateAsync();

// Inicializar repositorios
var usuarioRepo = new RepositoryEF<Usuario>(context);
var criptoRepo = new RepositoryEF<Criptomoneda>(context);
var operacionRepo = new RepositoryEF<Operacion>(context);
var portafolioRepo = new RepositoryEF<Portafolio>(context);

Console.WriteLine("\n📊 Consultando datos iniciales...");

// ================================
// 🔍 CONSULTAS LINQ
// ================================

// 1️⃣ Ranking de usuarios por saldo
var rankingUsuarios = await context.Usuarios
    .OrderByDescending(u => u.SaldoVirtual)
    .Select(u => new { u.Nombre, u.SaldoVirtual })
    .ToListAsync();

Console.WriteLine("\n🏆 Ranking de usuarios por saldo:");
foreach (var u in rankingUsuarios)
{
    Console.WriteLine($" - {u.Nombre}: ${u.SaldoVirtual:N2}");
}

// 2️⃣ Criptomonedas más populares (por cantidad de usuarios que las poseen)
var criptosPopulares = await context.Portafolios
    .Include(p => p.Criptomoneda)
    .GroupBy(p => p.Criptomoneda.Nombre)
    .Select(g => new { Criptomoneda = g.Key, Usuarios = g.Count() })
    .OrderByDescending(g => g.Usuarios)
    .ToListAsync();

Console.WriteLine("\n💹 Criptomonedas más populares:");
foreach (var c in criptosPopulares)
{
    Console.WriteLine($" - {c.Criptomoneda}: {c.Usuarios} usuarios poseen esta moneda");
}

// 3️⃣ Ganancias o pérdidas por usuario (basado en operaciones)
var ganancias = await context.Operaciones
    .Include(o => o.Usuario)
    .GroupBy(o => o.Usuario.Nombre)
    .Select(g => new
    {
        Usuario = g.Key,
        TotalCompras = g.Where(o => o.TipoOperacion == "Compra").Sum(o => o.Cantidad * o.PrecioUnitario),
        TotalVentas = g.Where(o => o.TipoOperacion == "Venta").Sum(o => o.Cantidad * o.PrecioUnitario),
        Ganancia = g.Where(o => o.TipoOperacion == "Venta").Sum(o => o.Cantidad * o.PrecioUnitario)
                    - g.Where(o => o.TipoOperacion == "Compra").Sum(o => o.Cantidad * o.PrecioUnitario)
    })
    .ToListAsync();

Console.WriteLine("\n📈 Ganancias / Pérdidas por usuario:");
foreach (var g in ganancias)
{
    Console.WriteLine($" - {g.Usuario}: Ganancia neta = ${g.Ganancia:N2}");
}

// 4️⃣ Valor total del portafolio de cada usuario
var valorPortafolios = await context.Portafolios
    .Include(p => p.Usuario)
    .Include(p => p.Criptomoneda)
    .GroupBy(p => p.Usuario.Nombre)
    .Select(g => new
    {
        Usuario = g.Key,
        ValorActual = g.Sum(p => p.CantidadActual * p.Criptomoneda.ValorActual)
    })
    .OrderByDescending(v => v.ValorActual)
    .ToListAsync();

Console.WriteLine("\n💼 Valor actual de portafolios:");
foreach (var v in valorPortafolios)
{
    Console.WriteLine($" - {v.Usuario}: ${v.ValorActual:N2}");
}

Console.WriteLine("\n✅ Simulación de bolsa completada.\n");
