using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Objetos
{
    internal class Program
    {
        public class Puerta
        {
            public int ancho { get; set; }
            public int alto { get; set; }
            public int color { get; set; }
            //sino le damos ambito es private por defecto           
            public bool abierta;

            public Puerta()
            {
                ancho = 23;
                alto = 120;
                color = 34;
                abierta = false;
            }

            public Puerta(int anch, int alt, int col)
            {
                ancho = anch;
                alto = alt;
                color = col;
            }


            public void Abrir()
            {
                abierta = true;
            }
            public void Cerrar()
            {
                abierta = false;
            }
            public void MostrarEstado()
            {
                Console.WriteLine($"Ancho de la puerta: {ancho}");
                Console.WriteLine($"Ancho de la puerta: {alto}");
                Console.WriteLine($"Ancho de la puerta: {color}");
                Console.WriteLine($"Abierta?: {abierta}");

            }
        }

        public class Porton : Puerta { //herencia : 
            public bool Bloqueado { get; set; }
            public void Bloquear()
            {
                Bloqueado = true;
            }
            public void Desbloquear()
            {
                Bloqueado = false;
            }
            public new void MostrarEstado()//Sobreescibimos el metodo
            {
                Console.WriteLine($"Ancho del porton: {ancho}");
                Console.WriteLine($"Alto del porton: {alto}");
                Console.WriteLine($"color del porton: {color}");
                Console.WriteLine($"Abierta?: {abierta}");
                Console.WriteLine($"Bloqueado?: {Bloqueado}");

            }
        }

        public class Persona
        {
            public string Nombre { get; set; } //prop + tab
            public int Edad { get; set; }
            public DateTime FechaNacimiento { get; set; }

            private int CalcularEdad(DateTime fecha)
            {
                int año = fecha.Year;
                int actual = DateTime.Now.Year;
                return actual - año;
            }
            public void Saludar()
            {
                Console.WriteLine($"Hola me llamo {Nombre} tengo {CalcularEdad(FechaNacimiento)}");
            }
        }

        public class Empleado
        {
            const int sueldo = 1000;
            const string nombre = "Nuevo empleado";
            const string cargo = "Empleado Base";

            public string Nombre { get; set; }
            public int Sueldo { get; set; }
            public string Cargo { get; set; }

            public Empleado()
            {
                Nombre = nombre;
                Sueldo = sueldo;
                Cargo = cargo;
            }

            public Empleado(string _nombre, int _sueldo, string _cargo)
            {
                Nombre = nombre;
                Sueldo = sueldo;
                Cargo = cargo;
            }
            public void Imprimir()
            {
                Console.WriteLine($"El empleado : {Nombre} con cargo {Cargo} cobra {Sueldo}");
            }

        }

        public class Contador//variables static
        {
            public int id;
            public static int totalObjetos = 6;
            public Contador()
            {
                //Incremento la variable de clase
                totalObjetos++;
                id = totalObjetos;
            }
            public static void mostrarTotal()
            {
                Console.WriteLine($"Total objetos: {totalObjetos}");
            }
        }

        public class Person{//herencia virtual, override, base
        
        protected string ssn = "444-555-666";//Solo podran acceder a ellas las clases qeu hereden de esta clase
        protected string name = "Pepe lillo";

        public virtual void getInfo()//virtual->para q quienes hereden de sta lo puedan utilizatr o sobreescribir
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"SSN: {ssn}");
        }

    }
    public class Employe : Person {
        public string id = "ABC456123";
        public override void getInfo()//override -> sobreescibimos el virtual
        {
            base.getInfo();//base-> le pasamos todo lo del metodo anteior
                Console.WriteLine($"Employee ID: {id}");
            }
    }
    public class Emplead
    {
        public int salary;
        //constructor con salario anual
        public Emplead(int annualSalary)
        {
            salary = annualSalary;
            Console.WriteLine($"Cosntructor Empleado salario anual {salary}");
        }
        //Cosntructor con salario semanl y numero de semanas
        public Emplead(int weekSalary, int numberOfWeeks) : this(weekSalary * numberOfWeeks)//herda el cons de arriba q recibe
                                                                                            //un solo àrametro y le llega 2 console.writeline
        {
            //salary = weekSalary * numberOfWeeks;
            Console.WriteLine($"Cosntructor Empleado(weekSlary,numberOfweeks)" +
                $" salario semanal : {weekSalary} numero de semana:{numberOfWeeks}");
        }
    }
    public class Manager : Emplead
    {
        public Manager(int annualSalary) : base(annualSalary)
        {
                Console.WriteLine($"Construcor para el Manager :{salary}");
            }//heredamos de la clase base el salario anual
    }

    public class Rectangulo
    {
        int _x;
        int _y;
        public Rectangulo(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
    public class RectanguloRelleno : Rectangulo
    {
        public RectanguloRelleno(int x, int y) : base(x, y)//En su constructor utiliza el cons de la clse base
        {

        }
    }

    public class Coordenadas//tostring
    {
        private int x, y;

        //primer constructor
        public Coordenadas()
        {
            x = 0; y = 0;
        }
        //segundo constructor
        public Coordenadas(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", x, y);
        }
    }

    //Abstracion-> se puden heredar de ellas pero no se pueden instanciar
    public abstract class Formas
    {
        public const double pi = Math.PI;
        protected double x, y; //solo pueden acceder las clses que hereden de esta
        public Formas(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public abstract double Area();//metodo para que quienes hereden de ella lo rellenen
    }
    //Hereda de clase abstracta
    public class Circulo : Formas
    {
        public Circulo(double radio) : base(radio, 0)
        {

        }

        public override double Area()
        {
            return pi * x * x;
        }
    }
    //hereda de circulo utiliza el constuctor de arriba para su construtor
    //
    public class Cilindro : Circulo
    {
        public Cilindro(double radio, double altura) : base(radio)
        {
            y = altura;
        }
        public override double Area()
        {
                return (2 * base.Area()) + (2 * pi * x * y);
            }
    }
    public class Date//lamdas
    {
        private int _month = 7;
        public int Month
        {
            get => _month;//lamdas le estoy diciendo al get que me consgia lo que tengo en month
            set
            {
                if ((value > 0) && value < 13)//value -> valor month 
                {
                    _month = value;
                }
            }
        }
    }
    public class Person1{//lamdas

        private string _name;
        private string Name
        {
            get => _name;
            set => _name = value;
        }

    }
    public interface IVolador{

        void Volar();

    }
    public class Abeja : IVolador//implementar el metodo explicita e implicita
    {
        public void Volar()
        {
            throw new NotImplementedException();
        }
    }


        static void Main(string[] args)
        {
            Date date = new Date();
            date.Month = 15;
            Console.WriteLine(date);

            double radius = 2.5;
            double altura = 3.0;

            Circulo circulo = new Circulo(radius);
            Cilindro cilindro = new Cilindro(radius, altura);

            Console.WriteLine($"Area de circulo {circulo.Area()}");
            Console.WriteLine($"Area de cilindro {cilindro.Area()}");



            Coordenadas c1 = new Coordenadas();
            Coordenadas c2 = new Coordenadas(3, 6);
            Console.WriteLine(c2.ToString());


            Emplead em1 = new Emplead(30000);
            Emplead em2 = new Emplead(3214, 32);
            Manager m1 = new Manager(50000);

            Console.WriteLine("Resumen de salarios");
            Console.WriteLine($"e1: {em1.salary}");
            Console.WriteLine($"e2: {em1.salary}");
            Console.WriteLine($"manager: {m1.salary}");



            //Herencia
            Employe employe = new Employe();
            employe.getInfo();

            //Static:variable o metodo -> de clase
            //variable static : su valor es el mismo para todos los objetos de esa clase.
            //metodo: es un metodo que se puede usar sin instanciar la clase.

            //Variable clase Static
            Contador ct1 = new Contador();
            Contador ct2 = new Contador();
            Contador ct3 = new Contador();

            Console.WriteLine($"ID de c1 es {ct1.id}");
            Console.WriteLine($"ID de c2 es {ct2.id}");
            Console.WriteLine($"ID de c3 es {ct3.id}");

            Contador.mostrarTotal();//Si es static no necesitamos crear un objeto sino llamrlo con su clase

            //Console.WriteLine($"Total de objetos creados: {}")


            Console.Write("Empleado generico");
            string nombreEmpleado = Console.ReadLine();
            if (nombreEmpleado.Length == 0)
            {
                Empleado empleadoGenerico = new Empleado();
                empleadoGenerico.Imprimir();
            } else
            {
                Console.Write("Suledo: ");
                int sueldeEmpleado = Convert.ToInt32(Console.ReadLine());
                Console.Write("Cargo: ");
                string cargoEmpleado = Console.ReadLine();

                Empleado empleado = new Empleado(nombreEmpleado, sueldeEmpleado, cargoEmpleado);
                empleado.Imprimir();
            }

            Persona persona = new Persona();
            persona.Nombre = "David";
            DateTime fechaNac = new DateTime(2010, 8, 10);
            persona.FechaNacimiento = fechaNac;

            persona.Saludar();

            Puerta puerta1 = new Puerta();
            puerta1.MostrarEstado();

            Puerta puerta2 = new Puerta(45, 190, 56);
            puerta2.MostrarEstado();

            //porton
            Porton porton1 = new Porton();
            porton1.ancho = 65;
            porton1.alto = 238;
            porton1.color = 49;
            porton1.abierta = true;
            porton1.Bloqueado = false;

            porton1.MostrarEstado();

            Console.ReadKey();
        }
    }
}
