using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ClientID { get; set; }//foranea
        public virtual Client? Client { get; set; }//PropiedadDe navegacion
        public virtual ICollection<Invoice>? Invoices { get; set; }

    }
}
