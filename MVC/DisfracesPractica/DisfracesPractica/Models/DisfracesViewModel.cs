using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisfracesPractica.Models
{
    public class DisfracesViewModel
    {
        public TemaDisfraz? SelectedTema { get; set; }
        public IEnumerable<Asistente> Asistentes { get; set; }
    }
}