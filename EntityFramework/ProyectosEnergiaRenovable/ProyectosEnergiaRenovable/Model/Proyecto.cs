using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectosEnergiaRenovable.Model
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public double InversionTotal { get; set; }
        public int TipoEnergiaId { get; set; }
        public TipoEnergia TipoEnergia { get; set; } = null!;
        public int UbicacionId { get; set; }
        public Ubicacion Ubicacion { get; set; } = null!;
        public ICollection<Inversion> Inversiones { get; set; } = new List<Inversion>();
        public ICollection<Informe> Informes { get; set; } = new List<Informe>();
    }
}
