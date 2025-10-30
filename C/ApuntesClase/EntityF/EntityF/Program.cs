using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityF
{
    public class DataSeeder
    {
        public static void Seed(Model1Container context)
        {
            // Solo rellenar si la base de datos está vacía
            if (!context.Clase_Animales.Any() && !context.Personas.Any() && !context.Mascotas.Any())
            {
                // Crear clases de animales
                var clasePerro = new Clase_Animal { Descripcion = "Perro" };
                var claseGato = new Clase_Animal { Descripcion = "Gato" };
                var claseAve = new Clase_Animal { Descripcion = "Ave" };
                context.Clase_Animales.AddRange(new[] { clasePerro, claseGato, claseAve });
                // Crear personas
                var personaJuan = new Persona { Nombre = "Juan Pérez" };
                var personaMaria = new Persona { Nombre = "María López" };
                var personaCarlos = new Persona { Nombre = "Carlos Díaz" };
                context.Personas.AddRange(new[] { personaJuan, personaMaria, personaCarlos });
                // Guardar primero para generar IDs
                context.SaveChanges();
                // Crear mascotas
                var mascotas = new List<Mascota>
        {
            new Mascota
            {
                Nombre = "Firulais",
                Clase_Animal = clasePerro,
                Persona1 = personaJuan,
                Clase = clasePerro.IdClase,
                Persona = personaJuan.IdPersona
            },
            new Mascota
            {
                Nombre = "Luna",
                Clase_Animal = claseGato,
                Persona1 = personaJuan,
                Clase = claseGato.IdClase,
                Persona = personaJuan.IdPersona
            },
            new Mascota
            {
                Nombre = "Michi",
                Clase_Animal = claseGato,
                Persona1 = personaMaria,
                Clase = claseGato.IdClase,
                Persona = personaMaria.IdPersona
            },
            new Mascota
            {
                Nombre = "Piolín",
                Clase_Animal = claseAve,
                Persona1 = personaCarlos,
                Clase = claseAve.IdClase,
                Persona = personaCarlos.IdPersona
            }
        };
                // Agregar mascotas
                context.Mascotas.AddRange(mascotas);
                // Guardar cambios finales
                context.SaveChanges();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Model1Container())
            {
                DataSeeder.Seed(context);
                Console.WriteLine("Datos cargados correctamente");
                Console.WriteLine("Comprueba base de datos..");
                Console.ReadKey();
            }
        }
    }
}
