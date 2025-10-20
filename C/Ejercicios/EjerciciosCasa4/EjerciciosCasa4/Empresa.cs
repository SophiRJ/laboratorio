using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    internal class Empresa
    {
        List<Empleado> lista;
        public Empresa()
        {
            lista = new List<Empleado>();

            Empleado empleado1 = new Empleado("Juan", "Gerente", 3000);
            Empleado empleado2 = new Empleado("Ana", "Contadora", 2500);
            Empleado empleado3 = new Empleado("Luis", "Vendedor", 2000);

            lista.Add(empleado1);
            lista.Add(empleado2);
            lista.Add(empleado3);
        }

        public void mostrarEmpleados()
        {
            foreach(Empleado e in lista)
            {
                Console.WriteLine($"Empleado: {e.nombre} Puesto: {e.puesto} Salario: {e.salario}");
            }
        }
        public void salarioMedio()
        {
            int media = 0;
            int suma = 0;
            foreach (Empleado e in lista)
            {
                suma += e.salario;
            }
            media = suma / lista.Count();
            Console.WriteLine($"El promedio es: {media}");
        }
    }
}
