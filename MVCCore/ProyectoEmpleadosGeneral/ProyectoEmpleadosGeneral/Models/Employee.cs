namespace ProyectoEmpleadosGeneral.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public decimal PricePerHour { get; set; }
        public Departament? Departament  { get; set; }

    }
}
