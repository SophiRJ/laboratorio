using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefugioAnimalesApp.Model
{
    public class Adoption
    {
        public int Id { get; set; }
        //Foreing key con animal
        public int AnimalId { get; set; }
        //Propiedad navegacion para animal
        public virtual Animal Animal { get; set; } = null!;

        //foreing key Adopter
        public int AdoterId { get; set; }
        //propiedad navegacion Adopter
        public virtual Adopter Adopter { get; set; } = null!;
        public DateTime AdoptionDate { get; set; }

    }
}
