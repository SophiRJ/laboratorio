using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQEjercicios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Mostrar todos los títulos de libros.
            //var titulos = Books.GetBooks()
            //    .Select(b =>b.Title).ToList();

            //foreach(var titulo in titulos)
            //{
            //    Console.WriteLine(titulo);
            //}

            //Filtrar libros con precio mayor a 500.
            //var libros= Books.GetBooks()
            //    .Where(b=>b.Price > 500)
            //    .Select(b=> new
            //    {
            //        Autor=b.Author,
            //        Titulo=b.Title,
            //        Precio=b.Price
            //    })
            //    .ToList();

            //foreach (var libro in libros)
            //{
            //    Console.WriteLine($"{libro.Autor}, {libro.Precio}, {libro.Titulo}");
            //}

            //Ordenar los libros por fecha de publicación (más recientes primero).
            //var librosOrdenados = Books.GetBooks()
            //    .OrderByDescending(b => b.DateOfRelease)
            //    .Select(b => new
            //    {
            //        Autor = b.Author,
            //        Titulo = b.Title,
            //        FechaPublicacion = b.DateOfRelease
            //    }).ToList();

            //foreach(var l in librosOrdenados)
            //{
            //    Console.WriteLine($"{l.Titulo}-{l.Autor}-{l.FechaPublicacion}");
            //}

            //Contar cuántos libros hay de un autor concreto (por ejemplo, "Bob Robson")
            //var contarLibros = Books.GetBooks()
            //    .Where(b => b.Author == "Bob Robson")
            //    .Count();
            //Console.WriteLine($"Total libros {contarLibros}");


            //Mostrar todos los títulos junto con su editorial
            //var titlesEditorial = (from publisher in SampleData.Publishers
            //                       join book in SampleData.Books
            //                       on publisher equals book.Publisher
            //                       select new
            //                       {
            //                           Titulo = book.Title,
            //                           Editorial = publisher.Name
            //                       }).ToList();
            //foreach (var b in titlesEditorial) {
            //    Console.WriteLine($"{b.Titulo}, Editorial: {b.Editorial}");
            //}

            //Filtrar libros cuyo precio sea menor a 30.
            //var librosB= Books.GetBooks()
            //    .Where(b=>b.Price<300)
            //    .Select(b => new
            //    {
            //        Titulo=b.Title,
            //        Precio=b.Price
            //    }).ToList();
            //foreach (var b in librosB) {
            //    Console.WriteLine($"{b.Titulo} Precio: {b.Precio}");
            //}

            //Obtener todos los libros de un tema específico (por ejemplo, "Terror").

            //var librosTema = (from subject in SampleData.Subjects
            //                  join book in SampleData.Books
            //                  on subject equals book.Subject
            //                  where subject.Name == "Terror"
            //                  select new
            //                  {
            //                      Titulo = book.Title,
            //                      Tema = subject.Name
            //                  }).ToList();

            //foreach(var b in librosTema)
            //{
            //    Console.WriteLine($"Titulo: {b.Titulo}, Tema: {b.Tema}");
            //}

            //Listar los autores (nombre y apellido) de todos
            //los libros publicados por “Joe Publishing”.
            //var autorFiltro = (from publisher in SampleData.Publishers
            //                   join book in SampleData.Books
            //                   on publisher equals book.Publisher
            //                   where publisher.Name == "Joe Publishing"
            //                   select new
            //                   {
            //                       Editor = publisher.Name,
            //                       Book = book.Title
            //                   }).ToList();
            //foreach (var b in autorFiltro)
            //{
            //    Console.WriteLine($"Titulo: {b.Book}, Editor: {b.Editor}");
            //}

            //Obtener el precio promedio de los libros..
            //var precioMedio = Books.GetBooks().Average(b => b.Price);
            //Console.WriteLine($"Precio medio: {precioMedio:0.00}");

            ////Mostrar cada editorial junto con el número de libros que ha publicado.
            //var librosPorEditorial = (from publisher in SampleData.Publishers
            //                          join book in SampleData.Books
            //                          on publisher equals book.Publisher
            //                          group book by publisher.Name into g
            //                          orderby g.Key
            //                          select new
            //                          {
            //                              Editorial = g.Key,
            //                              Libros = g.Count()
            //                          }).ToList();
            //foreach (var book in librosPorEditorial)
            //{
            //    Console.WriteLine($"{book.Editorial}: {book.Libros} Libros");

            //}

            ////Mostrar los autores y el número total de libros que han escrito.
            //var autoresLibros = (from book in Books.GetBooks()
            //                     group book by book.Author into g
            //                     orderby g.Key
            //                     select new
            //                     {
            //                         Autor = g.Key,
            //                         Cantidad = g.Count()
            //                     }).ToList();

            //var autoresLibrosLamda = Books.GetBooks()
            //                    .GroupBy(b => b.Author)
            //                    .OrderBy(g => g.Key)
            //                    .Select(g => new
            //                    {
            //                        Autor = g.Key,
            //                        Cantidad = g.Count()
            //                    })
            //                    .ToList();


            //foreach (var book in autoresLibros)
            //{
            //    Console.WriteLine($"{book.Autor}: {book.Cantidad} Libros");

            //}

            //Mostrar el libro más caro y el más barato.
            decimal masCaro = Books.GetBooks().Max(b => b.Price);
            decimal masBarato = Books.GetBooks().Min(b => b.Price);

            Console.WriteLine($"Mas caro {masCaro}, Mas barato: {masBarato}");

            //Mostrar los títulos de los libros ordenados por número de páginas descendente.

            //Buscar si existe algún libro publicado antes del año 2000.
        }
    }
}
