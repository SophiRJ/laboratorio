using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    
    public abstract class Figura
    {
        protected const double PI = Math.PI;
        protected double dim1 {  get; set; }
        protected double dim2 { get; set; }
        public Figura(double _lado,double _lado1)
        {
            this.dim1 = _lado;
            this.dim2 = _lado1;
        }
        public abstract void CalcularArea();       
    }
    public class Cuadrado : Figura
    {
        public Cuadrado(double x, double y):base(x, y) { }
        public override void CalcularArea()
        {
            double area = Convert.ToDouble(dim1 * dim2);
            Console.WriteLine($"El area del cuadrado es: {area:F2}");
        }
    }
    public class Circulo : Figura
    {
        public Circulo(double radio) : base(radio, 0) { }
        public override void CalcularArea()
        {
            double area = PI * (dim1*dim1);
            Console.WriteLine($"El area del circulo es{area:F2}");
        }
    }
}
