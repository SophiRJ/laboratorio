using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    internal class Coche
    {
        private int _id;
        private string _marca;
        private string _modelo;
        private int _km;
        private double _precio;
        public Coche(int id, string marca, string modelo, int km, double precio)
        {
            _id = id;
            _marca = marca;
            _modelo = modelo;
            _km = km;
            _precio = precio;
        }
        public int Id { get => _id;set=> _id = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public int Km { get => _km; set => _km = value; }
        public double Precio { get => _precio; set => _precio = value; }

        public override string ToString() 
        {
            return $"Marca {_marca}- Modelo:{_modelo} -Precio: {_precio}";
        }

    }
}
