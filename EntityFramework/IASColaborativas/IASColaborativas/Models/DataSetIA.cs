using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASColaborativas.Models
{
    public class DataSetIA
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Fuente { get; set; } = string.Empty;

        public ICollection<ProyectoDataSet> ProyectoDataSets { get; set; } = new List<ProyectoDataSet>();
    }
}
