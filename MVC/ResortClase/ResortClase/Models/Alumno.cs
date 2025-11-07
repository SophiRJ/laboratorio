using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResortClase.Models
{
    public class Alumno
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public bool Trabaja { get; set; }
        public int Nota { get; set; }
    }
}