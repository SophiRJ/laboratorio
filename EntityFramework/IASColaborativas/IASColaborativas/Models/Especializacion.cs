using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASColaborativas.Models
{
    public class Especializacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public ICollection<AIEntity> AIs { get; set; } = new List<AIEntity>();
        public ICollection<ProyectoColaborativo> Proyectos { get; set; }=new List<ProyectoColaborativo>();

    }
}
