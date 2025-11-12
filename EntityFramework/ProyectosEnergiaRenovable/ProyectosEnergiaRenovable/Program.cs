using Microsoft.EntityFrameworkCore;
using ProyectosEnergiaRenovable.Data;
using ProyectosEnergiaRenovable.Model;
using ProyectosEnergiaRenovable.Repositories;

public class Program
{
    static async Task Main()
    {
        using var context = new EnergiaRenovableContext();
        await context.Database.MigrateAsync();

        var tipoEnergiaRepo = new RepositoryEF<TipoEnergia>(context);
        var ubiRepo=new RepositoryEF<Ubicacion>(context);
        var proyectRepo= new RepositoryEF<Proyecto>(context);
        var inversorRepo= new RepositoryEF<Inversor>(context);
        var inversionRepo= new RepositoryEF<Inversion>(context);
        var informeRepo= new RepositoryEF<Informe>(context);

        Console.WriteLine("Datos iniciales cargados con éxito.\n");


        //Consultas
        //Total inversion por tipo de energia
        var query1= await context.Proyectos
            .GroupBy(p=>p.TipoEnergia.Nombre)
            .Select(g => new
            {
                TipoEnergia= g.Key,
                TotalInvertido= g.Sum(x=>x.InversionTotal)
            }). ToListAsync();

        //promedio de producción.Mi version
        var query2 = await context.Proyectos
            .Include(p => p.Informes)
            .Include(p => p.Ubicacion)
            .Include(p => p.TipoEnergia)
            .GroupBy(p => new { p.Ubicacion.Pais, p.TipoEnergia.Nombre })
            .Select(g => new
            {
                Lugar = g.Key.Pais,
                Energia = g.Key.Nombre,
                MediaEnergia = g.SelectMany(x => x.Informes).Average(i => i.EnergiaGeneradaMWh)

            }).ToListAsync();


        var query2Optima = await context.Informes
            // Incluimos la ruta desde Informe -> Proyecto -> (Ubicacion y TipoEnergia)
            .Include(i => i.Proyecto.Ubicacion)
            .Include(i => i.Proyecto.TipoEnergia)

            // Agrupamos por los datos que están en las tablas incluidas
            .GroupBy(i => new { i.Proyecto.Ubicacion.Pais, i.Proyecto.TipoEnergia.Nombre })

            .Select(g => new
            {
                Lugar = g.Key.Pais,
                Energia = g.Key.Nombre,

                // El cálculo es más simple porque 'g' ya es un grupo de 'Informes'
                MediaEnergia = g.Average(informe => informe.EnergiaGeneradaMWh)
            })
            .ToListAsync();
    }
}
