using IASColaborativas.Data;
using IASColaborativas.Models;
using IASColaborativas.Reposotories;
using Microsoft.EntityFrameworkCore;

public class Program
{
    static async Task Main()
    {
        using var context = new AIColabContext();
        await context.Database.MigrateAsync();

        var aiRepo = new RepositoryEF<AIEntity>(context);
        var datasetRepo = new RepositoryEF<DataSetIA>(context);
        var proyectosRepo = new RepositoryEF<ProyectoColaborativo>(context);
        var mensajeRepo = new RepositoryEF<Mensaje>(context);
        var especializacionesRepo = new RepositoryEF<Especializacion>(context);

        Console.WriteLine("Datos iniciales cargados con éxito.\n");

        // AIs más activas por cantidad de mensajes enviados y recibidos
        var topAIs = await context.AIs
            .Include(a => a.MensajesEnviados)
            .Include(a => a.MensajesRecibidos)
            .OrderByDescending(a => a.MensajesEnviados.Count)
            .OrderByDescending(a => a.MensajesRecibidos.Count)
            .Take(5)
            .ToListAsync();

        // Datasets más utilizados
        var datasetsPopulares = await context.Datasets
            .OrderByDescending(d => d.ProyectoDataSets.Count)
            .Take(5)
            .ToListAsync();

        // Proyectos por especialización
        var proyectosEspecializacion = await context.Proyectos
            .Include(p => p.Especializacion)
            .GroupBy(p => p.Especializacion.Nombre)
            .Select(g => new { Especializacion = g.Key, Cantidad = g.Count() })
            .ToListAsync();

        //Console.ReadKey();

    }
}