using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisfracesPractica.Models

{
    public enum TemaDisfraz
    {
        Vampiros,
        Zombies,
        Brujas,
        Otros
    }
    public class Asistente
    {
        public string Nombre { get; set; }
        public bool Acompañado { get; set; }
        public TemaDisfraz Tema { get; set; }
    }
}