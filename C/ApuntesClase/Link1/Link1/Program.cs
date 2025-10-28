using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Link1
{
    public class Book2
    {
        public string Title { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Book2[] books =
            //{
            //    new Book2{Title="Linq in ACTION"},
            //    new Book2{Title="LINQ FOR FUN"},
            //    new Book2{Title="Linq extreme"}
            //};

            //var titles = books
            //    .Where(Book => Book.Title.Contains("ACTION"))
            //    .Select(Book => Book.Title).ToList();

            //foreach (var title in titles)
            //{
            //    Console.WriteLine(title);
            //}

            //string[] books = { "Historias divertidas","Todo lo que necesitas",
            //    "Reglas de C#","Good Morning in new York"};

            //var query = (from book in books
            //             where book.Length > 10
            //             orderby book
            //             select new { BOOK = book.ToUpper() }).ToList();//agregando tipo BOOK columna

            //foreach (var q in query)
            //{
            //    Console.WriteLine(q);
            //}

            //var titles = (from book in books
            //              where book.Length > 10
            //              orderby book
            //              select book.ToUpper()).ToList();

            //foreach (var title in titles)
            //{
            //    Console.WriteLine(title);
            //}


            //List<Books> books = Books.GetBooks();
            //var bookTitles = (from b in books
            //                  where b.Title.Length > 10
            //                  orderby b.Price
            //                  select new { b.Title, b.Price }).ToList();

            ////Lo mismo pero asignando nombres personalizados a las propiedades
            //List<Books> book = Books.GetBooks();
            //var bookTitless = (from b in books
            //                  where b.Title.Length > 10
            //                  orderby b.Price
            //                  select new { libro = b.Title, PRecio = b.Price }).ToList();


            ////lo mismo con lamda
            //var listaPrecios =//tipo anonimo
            //    Books.GetBooks()
            //    .Where(b => b.Title.Length > 10)
            //    .OrderBy(b => b.Price)
            //    .Select(b => b.Price).ToList();


            //IEnumerable<Books> books =//hace mismo que List pero es una Iterface de linq para manejar colecciones
            //    Books.GetBooks()
            //    .Where(b => b.Price <= 1500)//El select podemos ovbiarlo
            //    .ToList();

            //List<Books> books1 = Books.GetBooks()
            //    .Where(b => b.Price > 250).ToList();

            //Funciona tanto con lambda como con expresiones consulta(SQL)
            //operador lambda
            //IEnumerable<Books> books =
            //    Books.GetBooks().
            //    Where(b => b.Price <= 1500 || b.Title == "Programming in C#")
            //    .ToList();

            ////forma clasica
            //var books2 = (from b in Books.GetBooks()
            //              where b.Price <= 1500 && b.Title == "Programming in C"
            //              select b).ToList();
            //cuando la info ya esta recogida en a var que quiero volcar no hace
            //el select pero si lo necesito si quiero hacer una criba

            //IEnumerable<string> titles =
            //    Books.GetBooks().Select(book => book.Title).ToList();
            //IEnumerable<decimal> prices =
            //    Books.GetBooks().Select(book => book.Price).ToList();
            //foreach (string title in titles)
            //{
            //    Console.WriteLine(title);
            //}
            //foreach (decimal price in prices)
            //{
            //    Console.WriteLine(price);
            //}


            //var libros = (from book in Books.GetBooks()
            //              select new
            //              {
            //                  Titulo = book.Title,
            //                  Precio = book.Price
            //              }).ToList();

            //var librosLambda = Books.GetBooks()//para trabajar con 2 valores lambda
            //    .Select(b => new
            //    {
            //        Titulo = b.Title,
            //        Precio = b.Price
            //    }).ToList();
            //foreach (var libro in libros)
            //{
            //    Console.WriteLine($"{libro.Titulo}");
            //    Console.WriteLine($"{libro.Precio}");
            //}


            //generar un indice en una secuencia de datos -> etiquetarlos con un indice
            //var books = Books.GetBooks()
            //    .Select((book, index) => new { index, book.Title })
            //    .OrderBy(book => book.Title).ToList();
            //foreach (var libro in books)
            //{
            //    Console.WriteLine($"{libro.index}");
            //    Console.WriteLine($"{libro.Title}");
            //}


            //disctint
            //var authors = (from book in Books.GetBooks()
            //               select new { Autor = book.Author }).ToList();
            ////misma con distinct
            //var authors2 = (from book in Books.GetBooks()
            //                select new { Autor = book.Author }).Distinct().ToList();
            ////misma con lamdba
            //var author3 = Books.GetBooks()
            //    .Select(b => new { Autor = b.Author }).Distinct().ToList();

            ////Operadores de Acumulacion: Sum,Count, min, max avg
            ////devuelven decimal segun el tipo de dato sobre el q trabajan
            //var miPrice = Books.GetBooks().Min(book => book.Price);
            //var maxPrice = Books.GetBooks().Max(book => book.Price);
            //var mediaPrice = Books.GetBooks().Average(book => book.Price);

            //var totalPrice = Books.GetBooks().Sum(book => book.Price);
            //var librosBaratos = Books.GetBooks().Where(b => b.Price < 50).Count();

            //var librosORdenados = (from book in Books.GetBooks()
            //                       orderby book.Author, book.Price descending, book.Title
            //                       select new
            //                       {
            //                           Autor = book.Author,
            //                           Precio = book.Price,
            //                           Titulo = book.Title
            //                       }).ToList();
            //Console.WriteLine("Libros ordenados");
            //foreach (var book in librosORdenados)
            //{
            //    Console.WriteLine(book.Titulo);
            //    Console.WriteLine(book.Autor);
            //    Console.WriteLine(book.Precio);
            //}

            //Encuentros
            //var query = (from publisher in SampleData.Publishers
            //             join book in SampleData.Books
            //             //lo que tengo en publisher que sea igual a lo que
            //             //tenga en book en uno de sus atributos
            //             on publisher equals book.Publisher
            //             select new
            //             {
            //                 Publisher = publisher.Name,//aqui en la proyeccion recupero                                   
            //                 Book = book.Title//los datos q yo quiero
            //             }).ToList();

            //var queryDoble = (from publisher in SampleData.Publishers
            //                  join book in SampleData.Books
            //                  on publisher equals book.Publisher
            //                  join subject in SampleData.Subjects
            //                  on book.Subject equals subject
            //                  select new
            //                  {
            //                      Publisher = publisher.Name,
            //                      Book = book.Title,
            //                      Subject = subject.Name
            //                  }).ToList();

            //join left interior izq exterior derecha
            //var queryLeft = (from publisher in SampleData.Publishers
            //                 join book in SampleData.Books
            //                 on publisher equals book.Publisher into publisherBooks// aqui se vuelca todo
            //                 from book in publisherBooks.DefaultIfEmpty()// tengan o no tengan
            //                 select new
            //                 {
            //                     Publisher = publisher.Name,
            //                     Book = book == null ? "(no books)" : book.Title,
            //                 }).ToList();



            //misma query con lamda mas complicado sugerenci usar la sencilla
            //var queryLambda = SampleData.Publishers
            //    .Join(SampleData.Books, publisher => publisher, book => book.Publisher
            //    , (publisher, book) => new
            //    {
            //        Publisher = publisher.Name,
            //        Book = book.Title
            //    }).ToList();


            //paginadores skip-> desde aqui; take-> cogeme este numero de elementos
            //Skip(): salta un numero determinado de elementos. 
            //Take(): muestra una secuencia de elementos ej quiero q cojas del 1 al 20
                Console.WriteLine("Lista completa de libros");
            var allBooks = SampleData.Books
                .Select((book, index) => new
                {
                    Index = index,
                    Book = book.Title
                }).ToList();
            foreach (var b in allBooks)
            {   //el 2 alinea el indice con 2 espacios a su derecha
                Console.WriteLine($"{b.Index + 1,2}: {b.Book}");
            }

            Console.WriteLine("_______________________");
            int count = SampleData.Books.Count();
            Console.Write($"Elige un numero de inicio (1-{count}): ");
            int startIndex = LeerEntero(1, count);

            Console.WriteLine($"Elije un numero de fin(>= {startIndex} y <={count})");
            int endIndex = LeerEntero(startIndex, count);
            Console.WriteLine("________________________");
            Console.ReadKey();

            //Mostrar el subconjunto
            var partialBooks = SampleData.Books
                .Select((book, index) => new { Index = index, Book = book.Title })
                .Skip(startIndex - 1)
                .Take(endIndex - startIndex + 1).ToList();//+1 por que debemos
                                                          //coger el end index incluido

            Console.WriteLine($"Libros filtrados desde {startIndex} hasta {endIndex}");
            foreach (var b in partialBooks)
            {
                Console.WriteLine($"{b.Index + 1,2}:{b.Book}");
            }
        }
        static int LeerEntero(int min, int max)
        {
            int valor;
            bool valido;
            do
            {
                Console.Write(">");
                //es true si lo que lee lo consigue castear a int y pasarselo a la variable valor y...
                valido = int.TryParse(Console.ReadLine(), out valor)
                    && valor >= min && valor <= max;
                if (!valido)
                    Console.WriteLine($"Por favor ingresa un numero entre el {min} y el {max}");
            } while (!valido);
            return valor;
        }
    }
}
