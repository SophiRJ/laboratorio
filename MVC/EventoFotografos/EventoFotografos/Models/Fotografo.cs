using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventoFotografos.Models
{
    public class Fotografo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public  List<Evento> Eventos { get; set; }=new List<Evento>();
        public decimal TotalSueldo => Eventos.Sum(e => e.Coste);
    }
}