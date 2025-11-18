using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoEmpleadosGeneral.Models;

namespace ProyectoEmpleadosGeneral.ViewModel
{
    public class EmployeeAllEmployesViewModel
    {
        public Employee? Employee { get; set; }
        public Departament? Departament { get; set; }
        public SelectList? DepartamentList { get; set; }
    }
}
