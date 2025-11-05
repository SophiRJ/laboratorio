using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASColaborativas.Models
{
    public class ProyectoDataSet
    {
        public int ProyectoColaborativoId { get; set; }
        public ProyectoColaborativo ProyectoColaborativo { get; set; } = null!;

        public int DatasetId { get; set; }
        public DataSetIA DataSet { get; set; } = null!;
    }
}
