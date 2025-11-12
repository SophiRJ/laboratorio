using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioAnimalesApp.Model
{
    public class Adopter
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Phone { get; set; } = "";
        public ICollection<Adoption> Adoptions { get; set; } = new List<Adoption>();
    }
}
