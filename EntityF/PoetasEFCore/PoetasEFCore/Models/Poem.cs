using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoetasEFCore.Models
{
    public class Poem
    {
        public int PoemId { get; set; }
        public string? Title { get; set; }

        public virtual Poet? Poet { get; set; }
        public virtual Meter? Meter { get; set; }
    }
}
