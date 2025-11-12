using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoniasE.Model
{
    public class Planeta
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public double TemperaturaPromedio { get; set; }
        public ICollection<Colonia> Colonias { get; set; } = new List<Colonia>();
    }
}
