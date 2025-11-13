using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAlumnosPracticaClase.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CursoId { get; set; }
       
    }
}