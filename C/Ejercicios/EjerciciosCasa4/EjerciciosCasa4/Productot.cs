using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    internal class Productot
    {
        public string Nombre  { get; set; }
        public string Categoria { get; set; }
        public double Precio { get; set; }

        public Productot(string _nombre, string _categoria, double _precio)
        {
            Nombre = _nombre;
            Categoria= _categoria;
            Precio = _precio;
        }

    }
}
