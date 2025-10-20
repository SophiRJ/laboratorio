using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    internal class Coche
    {
        private string marca;
        string modelo;
        int año;
        public Coche(string _marca,string _modelo,int _año)
        {
            marca = _marca;
            modelo = _modelo;
            año=_año;
        }
        public string Marca { get => marca;set=> marca=value; }
        public string Modelo { get => modelo;set=> modelo=value; }
        public int Año { get => año; set => año = value; }
        public void MostrarDatos()
        {
            Console.WriteLine("Marca: {0}, Modelo:{1}, Año: {2}", Marca, Modelo, Año);
        }
    }
}
