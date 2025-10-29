using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Model1Container())
            {
                var person = new Person
                {
                    FirstName = "Robert",
                    MidelName = "Allen",
                    LastName = "Doe",
                    PhoneNumber = "867-5309"
                };
                context.People.Add(person);
                person = new Person
                {
                    FirstName = "John",
                    MidelName = "K.",
                    LastName = "Smith",
                    PhoneNumber = "824-3031"
                };
                context.People.Add(person);
                person = new Person
                {
                    FirstName = "Billy",
                    MidelName = "Albert",
                    LastName = "Minor",
                    PhoneNumber = "907-2212"
                };
                context.People.Add(person);
                person = new Person
                {
                    FirstName = "Kathy",
                    MidelName = "Anne",
                    LastName = "Ryan",
                    PhoneNumber = "722-0038"
                };
                context.People.Add(person);
                context.SaveChanges();
            }
            Visualizar_Personas();

        }
        static void Visualizar_Personas()
        {
            using (var context = new Model1Container())
            {
                foreach (var person in context.People)
                {
                    Console.WriteLine($"{person.FirstName}, " +
                        $"{person.LastName}, " +
                        $"Phone: {person.PhoneNumber}");
                }
                Console.ReadKey();
            }
        }  
    }
}
