using ColoniasEspaciales.Data;
using ColoniasEspaciales.Model;
using ColoniasEspaciales.Repository;
using Microsoft.EntityFrameworkCore;

public class Program
{
    static async Task Main()
    {
        using var context = new ShelterContext();
        await context.Database.MigrateAsync();
        var coloniaRepo = new RepositoryEF<Colonia>(context);
        var eventoRepo= new RepositoryEF<Evento>(context);
        var habitanteRepo= new RepositoryEF<Habitante>(context);
        var planetaRepo= new RepositoryEF<Planeta>(context);
        var recursoRepo= new RepositoryEF<Recurso>(context);

        Console.WriteLine("Datos cargados");
    }
}
