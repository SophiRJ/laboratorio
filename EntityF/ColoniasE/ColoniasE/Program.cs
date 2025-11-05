using ColoniasE.Data;
using ColoniasE.Model;
using ColoniasE.Repository;
using Microsoft.EntityFrameworkCore;

public class Program
{
    static async Task Main()
    {
        using var context = new ColoniasContext();
        await context.Database.MigrateAsync();

        var coloniaRepo = new RepositoryEF<Colonia>(context);
        var planetaRepo = new RepositoryEF<Planeta>(context);
        var recursoRepo = new RepositoryEF<Recurso>(context);
        var habitanteRepo = new RepositoryEF<Habitante>(context);
        var eventoRepo = new RepositoryEF<Evento>(context);

        //CONSULTAS
        //Colonias más sostenibles
        var topColonias = await context.Colonia
            .Include(c => c.Planeta)
            .OrderByDescending(c => c.NivelSostenibilidad)
            .Take(5)
            .ToListAsync();

        //Recursos más escasos (menor cantidad total)
        var recursosEscasos = await context.Recursos
            .OrderBy(r => r.CantidadTotal)
            .Take(5)
            .ToListAsync();

        //Población por planeta
        var poblacionPorPlaneta = await context.Planeta
            .Include(p => p.Colonias)
            .ThenInclude(c => c.Habitantes)
            .Select(p => new
            {
                p.Nombre,
                Poblacion = p.Colonias.Sum(c => c.Habitantes.Count)
            })
            .ToListAsync();
        //Simulación de evento aleatorio (impacta sostenibilidad y recursos)
        var random = new Random();
        var colonias = await context.Colonia.ToListAsync();
        var recursos = await context.Recursos.ToListAsync();

        if (colonias.Any())
        {
            var coloniaAfectada = colonias[random.Next(colonias.Count)];

            string[] tipos = { "Tormenta Solar", "Epidemia", "Descubrimiento", "Averia", "Escasez" };
            string tipoEvento = tipos[random.Next(tipos.Length)];
            string descripcion = tipoEvento switch
            {
                "Tormenta Solar" => "Radiacion daño parte de los sistemas electricos",
                "Epidemia" => "Una enfermedad afectó a varios habitantes.",
                "Descubrimiento" => "Se halló un nuevo mineral en el subsuelo.",
                "Averia" => "El generador principal falló temporalmente.",
                "Escasez" => "Disminuyeron las reservas de oxigeno.",
                _ => "Evento desconocido"
            };

            if (tipoEvento == "Escasez" && recursos.Any())
            {
                var recurso = recursos[random.Next(recursos.Count)];
                recurso.CantidadTotal = Math.Max(0, recurso.CantidadTotal - random.Next(50, 150));
                context.Recursos.Update(recurso);
                Console.WriteLine($"{coloniaAfectada.Nombre} sufrio escasez de {recurso.Nombre}");
            }
            else if (tipoEvento == "Descubrimiento")
            {
                coloniaAfectada.NivelSostenibilidad = Math.Min(100, coloniaAfectada.NivelSostenibilidad + random.Next(5, 15));
                context.Colonia.Update(coloniaAfectada);
                Console.WriteLine($"{coloniaAfectada.Nombre} aumentó su sostenibilidad tras un descubrimiento.");
            }
            else
            {
                coloniaAfectada.NivelSostenibilidad = Math.Max(0, coloniaAfectada.NivelSostenibilidad - random.Next(5, 20));
                context.Colonia.Update(coloniaAfectada);
                Console.WriteLine($"{coloniaAfectada.Nombre} afectada por {tipoEvento}: {descripcion}");
            }

            var evento = new Evento
            {
                Tipo = tipoEvento,
                Descripcion = descripcion,
                Fecha = DateTime.Now,
                ColoniaId = coloniaAfectada.Id
            };
            await eventoRepo.AddAsync(evento);
            await context.SaveChangesAsync();

            Console.WriteLine($"Evento registrado: {tipoEvento} en {coloniaAfectada.Nombre}.");

            Console.ReadKey();
        }
    } }
        
