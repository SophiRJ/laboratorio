using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventoFotografos.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Coste { get; set; }

        public int FotografoId { get; set; }
        public Fotografo Fotografo { get; set; }
    }

}