using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coches.Models
{
    public class Coche
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public double Precio { get; set; }
        public Coche(){}
        public Coche(string marca,string modelo, string color, double precio)
        {
            Marca = marca;
            Modelo = modelo;
            Color = color;
            Precio = precio;
        }

    }
}