using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAlumnos.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProfesorId { get; set; }
    }
}