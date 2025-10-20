using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorVehiculos
{
    internal class Empresa
    {
        List<Vehiculo> lista;
        public Empresa()
        {
            lista = new List<Vehiculo>();
        }
        public void agregarVehiculo(Vehiculo v)
        {
            lista.Add(v);
        }
        public void mostrarLista()
        {
            Console.WriteLine("Deseas ver la lista detallada? s/n");
            string opcion = Console.ReadLine();
            bool detallado = false;
            if (opcion == "s")
            {
                detallado = true;
            }
            foreach(Vehiculo v in lista)
            {
                if (detallado == true)
                {
                    v.MostrarInfo(detallado);
                }
                else
                {
                    v.MostrarInfo();
                }
            }
            

        }

    }
}
