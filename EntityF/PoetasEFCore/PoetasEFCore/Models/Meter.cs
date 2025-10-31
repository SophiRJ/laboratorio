using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoetasEFCore.Models
{
    public class Meter
    {
        public int MeterId { get; set; }
        public string? MeterName { get; set; }
        public virtual ICollection<Poem> Poems { get; set; }
    }
}
