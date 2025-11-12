using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    internal class Empleado
    {
        public string nombre { get; set; }
        public string puesto { get; set; }
        public int salario { get; set; }
        public Empleado(string nombre, string puesto, int salario)
        {
            this.nombre = nombre;
            this.puesto = puesto;
            this.salario = salario;
        }
    }
}
