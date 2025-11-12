using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioAnimalesApp.Model
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";//puede ser nulo
        public string? Species { get; set; }//puede ser nulo
        public int Age { get; set; }
        public ICollection<Adoption> Adoptions { get; set; } = new List<Adoption>();
    }
}
