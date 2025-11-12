using GestionGimnasio.Data;
using GestionGimnasio.Model;
using GestionGimnasio.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

public class Program
{
   static async Task Main()
    {
        using var context = new GimnasioContext();
        await context.Database.MigrateAsync();

        //repo
        var claseRepo = new RepositoryEF<Clase>(context);
        var entrenadorRepo= new RepositoryEF<Entrenador>(context);  
        var inscripcionRepo= new RepositoryEF<Inscripcion>(context);
        var socioRepo= new RepositoryEF<Socio>(context);

        //Console.WriteLine("Datos iniciales cargados con exito");
        //1.Listar todas las inscripciones, mostrando el nombre del socio,
        //la clase y el entrenador.
        //await Inscripciones_Lista();
        //2.Mostrar los socios con mayor gasto mensual total, calculando
        //la suma de las clases a las que están inscritos.
        //await Socios_Mas_Inscripciones();
        //3.Listar las clases más populares, ordenadas por cantidad de
        //socios inscritos.
        //await Clases_Mas_Populares();
        //4.Registrar una nueva inscripción desde consola:
        //o El usuario selecciona un socio existente.
        //o Selecciona una clase disponible.
        //o Se registra la inscripción en la base de datos con la fecha actual
        //await Registro_Inscripcion(socioRepo, claseRepo, inscripcionRepo);
        await MenuPrincipal(socioRepo, claseRepo, inscripcionRepo);



    }
    private static async Task MenuPrincipal(RepositoryEF<Socio> socioRepo,RepositoryEF<Clase> claseRepo,RepositoryEF<Inscripcion> inscripcionRepo)
    {
        int opcion = 0;
        do
        {
            Console.WriteLine(" Menu PRincipal-Escoja una opcion ");
            Console.WriteLine("1. Listar inscripciones");
            Console.WriteLine("2. Socios con mayor gasto mensual");
            Console.WriteLine("3. Clases mas populares");
            Console.WriteLine("4. Registrar nueva inscripcion");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida, seleccione una opcion.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    await Inscripciones_Lista();
                    break;
                case 2:
                    await Socios_Mas_Inscripciones();
                    break;
                case 3:
                    await Clases_Mas_Populares();
                    break;
                case 4:
                    await Registro_Inscripcion(socioRepo, claseRepo, inscripcionRepo);
                    break;
                case 5:
                    Console.WriteLine("saliendo del programa");
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }

        } while (opcion != 5);
    }


    private static async Task Registro_Inscripcion(RepositoryEF<Socio> socioRepo,
        RepositoryEF<Clase> claseRepo,RepositoryEF<Inscripcion> inscripcionRepo)
    {
        Console.WriteLine("Registrar inscripcion");

        //socios
        var socios = await socioRepo.GetAllAsync();
        Console.WriteLine("Socios disponibls:");
        foreach (var socio in socios)
            Console.WriteLine($"IdSocio: {socio.Id}, Nombre: {socio.Nombre}");

        Console.Write("Seleccione el numero de socio: ");
        int numeroSocio = Convert.ToInt32(Console.ReadLine());

        //clases
        var clases = await claseRepo.GetAllAsync();
        Console.WriteLine("Clases disponibles: ");
        foreach (var clase in clases)
            Console.WriteLine($"IdClase {clase.Id}, Nombre {clase.Nombre}");

        Console.Write("Seleccione el numero de la clase ");
        int numeroClase = Convert.ToInt32(Console.ReadLine());

        
        var yaInscrito = await inscripcionRepo.FindAsync(
            i => i.SocioId == numeroSocio && i.ClaseId == numeroClase);

        if (yaInscrito.Any())
        {
            Console.WriteLine("El socio ya esta inscrito en esta clase.");
        }
        else
        {
            var nuevaInscripcion = new Inscripcion
            {
                SocioId = numeroSocio,
                ClaseId = numeroClase,
                FechaInicio = DateTime.Now
            };

            await inscripcionRepo.AddAsync(nuevaInscripcion);
            Console.WriteLine("Inscripción realizada con exito.");
        }
    }



    private static async Task Clases_Mas_Populares()
    {
        using (var context = new GimnasioContext())
        {
            var clasesPopulares = await context.Inscripciones
                .GroupBy(i => i.Clase.Nombre)
                .Select(g => new
                {
                    nombreClase = g.Key,
                    cantidadInscritos = g.Select(x => x.SocioId).Distinct().Count()
                }).OrderByDescending(x => x.cantidadInscritos).Take(2).ToListAsync();
            foreach(var item in clasesPopulares)
            {
                Console.WriteLine($"Nombre Clase: {item.nombreClase}- Cantidad Inscritos: {item.cantidadInscritos}");
            }
        }
    }

    private static async Task Socios_Mas_Inscripciones()
    {
        using (var context = new GimnasioContext())
        {
            var sociosInscripciones = await context.Inscripciones
                .Include(i=>i.Clase)
                .GroupBy(i => i.Socio.Nombre)
                .Select(g => new
                {
                    nombreSocio = g.Key,
                    dineroInvertido = g.Sum(x => x.Clase.PrecioMensual),
                    totalClasesInscrito = g.Count()

                }).OrderByDescending(x => x.dineroInvertido).Take(3).ToListAsync();
            foreach(var item in sociosInscripciones)
            {
                Console.WriteLine($"Nombre Socio: {item.nombreSocio}, Dinero Invertido: {item.dineroInvertido}," +
                    $" Cantidad De Clases inscrito: {item.totalClasesInscrito}");
            }
        }
        }

    private static async Task Inscripciones_Lista()
    {
        using(var context = new GimnasioContext())
        {
            var inscripciones = await context.Inscripciones
                .Include(i=>i.Clase)
                .ThenInclude(c=>c.Entrenador)
                .Select(i => new
                {
                    idInsc= i.Id,
                    socio= i.Socio.Nombre,
                    clase= i.Clase.Nombre,
                    entrenador=i.Clase.Entrenador.Nombre
                }).ToListAsync();

            foreach(var item in inscripciones)
            {
                Console.WriteLine($"IdInscripcion: {item.idInsc}, Socio {item.socio}, Clase: {item.clase}" +
                    $", Entrenador: {item.entrenador}");
            }
        }
    }
}
