using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASColaborativas.Models
{
    public class ProyectoColaborativo
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int EspecializacionId { get; set; }
        public Especializacion Especializacion { get; set; } = null!;//q nunca sea nula
        public ICollection<AIProyecto> AIProyectos { get; set; } = new List<AIProyecto>();
        public ICollection<ProyectoDataSet> ProyectoDataSet { get; set; }= new List<ProyectoDataSet>();
    }
}
