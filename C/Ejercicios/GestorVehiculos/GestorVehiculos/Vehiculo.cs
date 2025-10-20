using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorVehiculos
{
    internal abstract class Vehiculo
    {
        protected const double IVA = 0.21;
        protected string marca;
        protected string modelo;
        protected int año;
        protected string color;
        protected int peso;
        protected double precioBase;
        protected double precioFinal;
        protected int velocidadMAx;
        
        
        
        public Vehiculo(string _marca, string _modelo, int _año, string _color, int _peso, double _precio, int _velMaxima)
        {
            marca= _marca;
            modelo= _modelo;
            color= _color;
            año = _año;
            peso= _peso;
            precioBase= _precio;
            precioFinal= 0;
            velocidadMAx= _velMaxima;
        }
        

        public abstract void CalcularImpuesto();
        public abstract void MostrarInfo();
        public abstract void MostrarInfo(bool detallado);

    }
}
