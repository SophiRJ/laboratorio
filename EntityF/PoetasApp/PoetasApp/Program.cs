using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace PoetasApp
{
    public static class DataSeeder
    {
        public static void Seed(PoetasEntities context)
        {
            // Evitar duplicar datos si ya existen
            if (context.Poets.Any()) return;

            // === Metros poéticos ===
            var meters = new List<Meter>
{
new Meter { MeterName = "Soneto" },
new Meter { MeterName = "Haiku" },
new Meter { MeterName = "Verso libre" },
new Meter { MeterName = "Lira" },
new Meter { MeterName = "Décima" },
new Meter { MeterName = "Oda" },
new Meter { MeterName = "Elegía" },
new Meter { MeterName = "Romance" },
new Meter { MeterName = "Redondilla" },
new Meter { MeterName = "Copla" }
};
            context.Meters.AddRange(meters);
            context.SaveChanges();

            // === Poetas ===
            var poets = new List<Poet>
{
new Poet { FirstName = "Pablo", MiddleName = "", LastName = "Neruda" },
new Poet { FirstName = "Federico", MiddleName = "", LastName = "García Lorca" },
new Poet { FirstName = "Emily", MiddleName = "", LastName = "Dickinson" },
new Poet { FirstName = "William", MiddleName = "", LastName = "Shakespeare" },
new Poet { FirstName = "Gabriela", MiddleName = "", LastName = "Mistral" },
new Poet { FirstName = "Octavio", MiddleName = "", LastName = "Paz" },
new Poet { FirstName = "Jorge Luis", MiddleName = "", LastName = "Borges" },
new Poet { FirstName = "Walt", MiddleName = "", LastName = "Whitman" },
new Poet { FirstName = "Sor", MiddleName = "Juana", LastName = "Inés de la Cruz" },
new Poet { FirstName = "Antonio", MiddleName = "", LastName = "Machado" },
new Poet { FirstName = "PoetaSinPoema", MiddleName = "", LastName = "Nuevo" }
};
            context.Poets.AddRange(poets);
            context.SaveChanges();

            // === Poemas ===
            var poems = new List<Poem>
{
new Poem { Title = "Walking Around", Poet = poets[0], Meter = meters[2] },
new Poem { Title = "Veinte poemas de amor y una canción desesperada", Poet = poets[0], Meter = meters[0] },
new Poem { Title = "Romance Sonámbulo", Poet = poets[1], Meter = meters[7] },
new Poem { Title = "La Guitarra", Poet = poets[1], Meter = meters[4] },
new Poem { Title = "Hope is the Thing with Feathers", Poet = poets[2], Meter = meters[2] },
new Poem { Title = "Because I could not stop for Death", Poet = poets[2], Meter = meters[6] },
new Poem { Title = "Sonnet 18", Poet = poets[3], Meter = meters[0] },
new Poem { Title = "Sonnet 116", Poet = poets[3], Meter = meters[0] },
new Poem { Title = "Piececitos", Poet = poets[4], Meter = meters[9] },
new Poem { Title = "Desolación", Poet = poets[4], Meter = meters[6] },
new Poem { Title = "Piedra de sol", Poet = poets[5], Meter = meters[2] },
new Poem { Title = "El cántaro roto", Poet = poets[5], Meter = meters[5] },
new Poem { Title = "El Golem", Poet = poets[6], Meter = meters[2] },
new Poem { Title = "Los Justos", Poet = poets[6], Meter = meters[5] },
new Poem { Title = "Leaves of Grass", Poet = poets[7], Meter = meters[2] },
new Poem { Title = "Song of Myself", Poet = poets[7], Meter = meters[2] },
new Poem { Title = "Hombres necios que acusáis", Poet = poets[8], Meter = meters[7] },
new Poem { Title = "A su retrato", Poet = poets[8], Meter = meters[0] },
new Poem { Title = "Campos de Castilla", Poet = poets[9], Meter = meters[5] },
new Poem { Title = "A un olmo seco", Poet = poets[9], Meter = meters[6] }
};

            context.Poems.AddRange(poems);
            context.SaveChanges();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //CrearDatos();
            //Consultas
            //listar todos los poetas con su cantidad de poemas
            //PoetasCantidadPoemas();
            //Obtener todos los titulos de poemas junto con el
            //nombre del poeta ordenados por 
            //titulo del poema
            PoetasPoema();

        }

        private static void PoetasPoema()
        {
            using (var context = new PoetasEntities())
            {
                var query = (from pt in context.Poets
                             join pm in context.Poems
                             on pt.PoetId equals pm.PoetId
                             select new
                             {
                                 Poeta = $"{pt.FirstName} {pt.LastName}",
                                 Poema = pm.Title
                             }).OrderBy(x => x.Poema).ToList();


            }
        }

        private static void PoetasCantidadPoemas()
        {
            using(var context= new PoetasEntities())
            {
                var query = (from pm in context.Poems
                             join pt in context.Poets
                             on pm.PoetId equals pt.PoetId
                             group pm.Title by pt.PoetId into g
                             select new
                             {
                                 Poeta = g.Key,
                                 NumeroPoemas = g.Count(),
                             }).ToList();
                //usando la propiedad de navegacion del 1 al n se
                //puede pero te devuelve el objeto 
                var querya = context.Poets
                    .ToList()
                    .Select(p => new
                    {
                        Nombre = $"{p.FirstName} {p.LastName}",
                        TotalPoemas = p.Poems.Count()
                    }).OrderBy(p => p.TotalPoemas).ToList();
            }
        }

        private static void CrearDatos()
        {
            using (var context = new PoetasEntities())
            {
                DataSeeder.Seed(context);
                Console.WriteLine("Datos cargados");


            }
        }
    }
}
