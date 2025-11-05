using Criptomonedas.Data;
using Criptomonedas.Model;
using Criptomonedas.Repository;
using Microsoft.EntityFrameworkCore;

public class Program
{
    static async Task Main()
    {
        using var context = new CriptoContext();
        await context.Database.MigrateAsync();

        var criptoRepo = new RepositoryEF<Criptomoneda>(context);
        var opeRepo= new RepositoryEF<Operacion>(context);
        var portRepo = new RepositoryEF<Portafolio>(context);
        var usuRepo= new RepositoryEF<Usuario>(context);

        Console.WriteLine("Datos iniciales cargados con éxito.\n");

        //Consultas
        // ranking de usuarios por saldo
        var ranking = await context.Usuarios
            .OrderByDescending(u => u.SaldoVirtual)
            .Select(u => new
            {
                u.Nombre,
                u.SaldoVirtual
            }).ToListAsync();

        //Cripto mas populares
        var query = await context.Portafolios
            .Include(p => p.Criptomoneda)
            .GroupBy(p => p.Criptomoneda.Nombre)
            .Select(g => new
            {
                Criptom = g.Key,
                Usuarios = g.Count()
            }).OrderByDescending(g => g.Usuarios).ToListAsync();

        //ganacias o perdidas usuarios
        var query2 = await context.Operaciones
            .Include(o => o.Usuario)
            .GroupBy(o => o.Usuario.Nombre)
            .Select(g => new
            {
                Usuario = g.Key,
                TotalCompras = g.Where(o => o.TipoOperacion == "Compra").Sum(o => o.Cantidad * o.PrecioUnitario),
                TotalVentas = g.Where(o => o.TipoOperacion == "Venta").Sum(o => o.Cantidad * o.PrecioUnitario),
                Ganacia = g.Where(o => o.TipoOperacion == "Ventas").Sum(o => o.Cantidad * o.PrecioUnitario) -
                g.Where(o => o.TipoOperacion == "Compra").Sum(o => o.Cantidad * o.PrecioUnitario)
            }).ToListAsync();

        //Valor toal del portafolio de cad a usuario
        var query3 = await context.Portafolios
            .Include(p => p.Usuario)
            .Include(p => p.Criptomoneda)
            .GroupBy(p => p.Usuario.Nombre)
            .Select(g => new
            {
                Usuario = g.Key,
                ValorTotal = g.Sum(P => P.CantidadActual * P.Criptomoneda.ValorActual)
            }).OrderByDescending(v=>v.ValorTotal).ToListAsync();
    }
}
