using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoetasAppCasa
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
            //CargarDatos();
            //1 Listar todos los poetas con su cantidad de poemas
            Poetas_con_Numero_Poemas();
            //2. Obtener todos los titulos de poemas junto con el nombre del poeta ordenados
            //por titulo del poema 
            Poemas_Poeta();
            //3. Listar todos los poetas y sus poemas incluso los que no tienen poemas
            Poetas_Poemas_Left();
            //4Agrupar los poemas por tipo de metrica y contarlos
            Numero_Poemas_Metrica();
            //5 Obtener todos los titulos de poemas en soneto
            Titulos_Soneto();
            //6 Obtener los poetas que tienen poemas en mas de un tipo de metrica
            Poetas_Muchas_Metricas();
            //7 Select many 
            SelectManyPoems();
        }

        private static void Poetas_Poemas_Left()
        {
            using (var context = new PoetasEntities())
            {
                var query3 = (from poet in context.Poets
                              join poem in context.Poems
                                  on poet.PoetId equals poem.PoetId into poetPoems
                              from poem in poetPoems.DefaultIfEmpty() // LEFT JOIN
                              select new
                              {
                                  PoetName = poet.FirstName + " " + poet.LastName,
                                  PoemTitle = poem != null ? poem.Title : "(sin poemas)"
                              }).ToList();

            }
        }

        private static void Poemas_Poeta()
        {
            using (var context = new PoetasEntities())
            {
                var query2 = (from poems in context.Poems
                              .ToList()
                              select new
                              {
                                  poeta = $"{poems.Poet.FirstName} {poems.Poet.LastName}",
                                  Poema = poems.Title,
                              }).OrderBy(p => p.Poema).ToList();
            }
        }

        private static void Poetas_con_Numero_Poemas()
        {
            using (var context = new PoetasEntities())
            {
                //usamos la propiedad de navegacion del 1 al n nos devuelve
                //la lista de poemas q tiene este poeta
                var query1 = (from poet in context.Poets
                             select new
                             {
                                 Poeta = poet.FirstName + " " + poet.LastName,
                                 CantidadPoemas = poet.Poems.Count()
                            }).ToList();
                var query1a = context.Poets
                    .ToList()
                    .Select(p => new
                    {
                        Poeta = $"{p.FirstName} {p.LastName}",
                        Cantidad = p.Poems.Count()
                    }).OrderBy(p => p.Cantidad).ToList();
            }
        }

        private static void SelectManyPoems()
        {
            using (var context = new PoetasEntities())
            {
                var query7 = context.Poets
                    .SelectMany(p => p.Poems.Select(poem => new
                    {
                        Poet = p.FirstName + " " + poem.Poet.LastName,
                        Titulo = poem.Title,
                        Metrica = poem.Meter.MeterName
                    })).ToList();
            }
        }

        private static void Poetas_Muchas_Metricas()
        {
            using (var context = new PoetasEntities())
            {
                var query6 = (from poem in context.Poems
                              group poem by (poem.Poet.FirstName + " " + poem.Poet.LastName)
                              into g
                              where g.Select(p => p.MeterId).Distinct().Count() > 1
                              select new
                              {
                                  Poeta = g.Key,
                                  TiposMetrica = g.Select(p => p.MeterId).Distinct().Count()
                              }).ToList();


            }
        }

        private static void Titulos_Soneto()
        {
            using (var context = new PoetasEntities())
            {
                var query5= (from poem in context.Poems
                            where poem.Meter.MeterName=="soneto"
                            select new
                            {
                                Poema= poem.Title,
                                Poeta= poem.Poet.FirstName+" "+poem.Poet.LastName,
                                Metrica= poem.Meter.MeterName
                            }).ToList();
            }
        }

        private static void Numero_Poemas_Metrica()
        {//Estamos viajando de la tabla n hacia el 1 y accedemos a la propiedad de navegacion 
            //la cual devuelve el objeto con sus propiedades por eso -> meterName
            using (var context = new PoetasEntities())
            {
                var query4 = (from p in context.Poems
                              group p by p.Meter.MeterName into g
                              select new
                              {
                                  Metrica = g.Key,
                                  NumeroPoemas = g.Count()
                              }).ToList();


            }
        }

        private static void CargarDatos()
        {
            using (var context = new PoetasEntities())
            {
                DataSeeder.Seed(context);
                Console.WriteLine("Datos cargados");


            }
        }
    }
}
