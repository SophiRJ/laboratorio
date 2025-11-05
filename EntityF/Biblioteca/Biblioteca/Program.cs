using Biblioteca.Data;
using Biblioteca.Model;
using Biblioteca.Repository;
using Microsoft.EntityFrameworkCore;

public class Program
{
    static async Task Main()
    {
        using var context = new BibliotecaContext();
        await context.Database.MigrateAsync();

        var usuRepo = new RepositoryEF<Usuario>(context);
        var bibliotecarioRepo = new RepositoryEF<Bibliotecario>(context);
        var libroRepo= new RepositoryEF<Libro>(context);
        var prestamoRepo= new RepositoryEF<Prestamo>(context);

        Console.WriteLine("Datos iniciales cargados con exito..");

        //Consultas
        //1.	 Listar todos los préstamos con su información detallada
        var query1 = await context.Prestamos
            .Select(x => new
            {
                LibroP = x.Libro.Titulo,
                BibliotecarioP= x.Bibliotecario.Nombre,
                UsuarioP = x.Usuario.Nombre,
                FechaP= x.FechaPrestamo,
                FechaD= x.FechaDevolucion
            }).ToListAsync();

        //2.	Libros más populares (mayor cantidad de préstamos)
        var query2 = await context.Prestamos
            .GroupBy(p => p.Libro.Titulo)
            .Select(g => new
            {
                nombreL = g.Key,
                cantidadP = g.Count()
            }).OrderByDescending(x => x.cantidadP).Take(2).ToListAsync();

        //3.	Préstamos aún no devueltos
        var query3 = await context.Prestamos
            .Where(p=>p.FechaDevolucion==null)
            .Select(x => new
            {
                NombreL= x.Libro.Titulo,
                fechaPrestamo= x.FechaPrestamo,
                BibliotecarioN= x.Bibliotecario.Nombre
            }).ToListAsync();

        //4.	Total de libros por género

        var query4 = await context.Libros
            .GroupBy(l => l.Genero)
            .Select(g => new
            {
                GeneroL = g.Key,
                TotalLibros = g.Count()
            }).ToListAsync();

        //5.	Bibliotecarios con más préstamos gestionados

        var query5 = await context.Prestamos
            .GroupBy(p => p.Bibliotecario.Nombre)
            .Select(g => new
            {
                BiblitecarNombre=g.Key,
                TotalGestiones= g.Count()
            }).OrderByDescending(x=>x.TotalGestiones).Take(2).ToListAsync();

        //6.	Libros no prestados nunca
        var query6 = await context.Libros
            .Where(l => !l.Prestamos.Any()).ToListAsync();

        //7.	Usuarios con préstamos vencidos (más de 30 días sin devolución)
        var fechaLimite = DateTime.UtcNow.AddDays(-30);

        var query7 = await context.Prestamos
            .Where(p => p.FechaPrestamo < fechaLimite)
            .Select(p => p.Usuario)
            .Distinct()
            .ToListAsync();



    }
}
