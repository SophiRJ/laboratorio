using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuquesApp.Models
{
    public class Barco
    {
        public int BarcoId { get; set; }
        public string NombreBarco { get; set; }
        public int CosteConstruccion { get; set; }
        public int AñoConstruccion { get; set; }
        public DateTime FechaUltimaReparacion { get; set; }

        public virtual ICollection<Tripulante> tripulacion { get; set; }
    }
}