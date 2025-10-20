using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEscolar
{
    public abstract class Ppersona {
        protected string Nombre { get; set; }
        protected int Edad { get; set; }
        public Ppersona(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }
        public abstract void MostrarDatos();
    }
    interface IEevaluable {
        void Evaluar();
    }
    public class Aalumno : Ppersona, IEevaluable
    {
        public double Nota { get; set; }
        public Aalumno(string nombre, int edad, double nota) : base(nombre, edad)
        {
            Nota = nota;
        }

        public override void MostrarDatos()
        {
            Console.WriteLine($"Alumno {Nombre} Edad {Edad} Nota {Nota}");
        }

        public void Evaluar()
        {
            if (Nota >= 7)
            {
                Console.WriteLine($"Alumno Aprobado");
            }
            else
            {
                Console.WriteLine("Reprobado");
            }
        }
    }
    public class Pprofesor : Ppersona, IEevaluable 
    {
        public string Asignatura { get; set; }
        public Pprofesor(string nombre, int edad, string asignatura) : base(nombre, edad)
        {
            Asignatura = asignatura;
        }

        public override void MostrarDatos()
        {
            Console.WriteLine($"Profesor: {Nombre}, Edad {Edad}, Asignatura {Asignatura}");
        }

        public void Evaluar()
        {
            Console.WriteLine($"Profesor  {Nombre} esta evaluando");
        }
    }
    /*3.	Sistema de gestión de Animales del Zoológico”
•	El zoológico necesita un sistema para registrar animales y mostrar información básica de cada uno.
Cada animal tiene una especie, un nombre, una edad, y un hábitat (por ejemplo: terrestre, acuático o aéreo).
•	Cada tipo de animal puede emitir un sonido y tiene una forma de alimentarse diferente.
•	El programa debe permitir crear algunos animales y mostrar su información por consola.
*/
    public enum Habitat
    {
        Terrestre,
        Acuatico,
        Aereo
    }
    interface IAnimal
    {
        void HacerSonido();
        void Alimentarse();
        void MostrarInfo();
    }
    public abstract class Animal : IAnimal
    {
        protected string Nombre {  get; set; }
        protected int Edad {  get; set; }
        protected Habitat TipoHabitat {  get; set; }

        public Animal (string nombre, int edad, Habitat habitat)
        {
            Nombre = nombre;
            Edad = edad;
            TipoHabitat = habitat;
        }
        public abstract void HacerSonido();
        public abstract void Alimentarse();
        public virtual void MostrarInfo()
        {
            Console.WriteLine($"Nombre {Nombre} Edad {Edad} Habitat {TipoHabitat}");
        }
    }
    public class Leon : Animal
    {
        public Leon(string nombre, int edad) : base(nombre, edad, Habitat.Terrestre)
        {

        }
        public override void HacerSonido() => Console.WriteLine($"{Nombre} ruge");
        public override void Alimentarse() => Console.WriteLine($"´{Nombre} se alimenta");
    }
    public class Delfin : Animal
    {
        public Delfin(string nombre, int edad) : base(nombre, edad, Habitat.Acuatico){ }
        public override void HacerSonido() => Console.WriteLine($"{Nombre} delfinea");
        public override void Alimentarse() => Console.WriteLine($"´{Nombre} come pescado");
    }
    public class Aguila : Animal
    {
        public Aguila(string nombre, int edad) : base(nombre, edad, Habitat.Aereo) { }
        public override void HacerSonido() => Console.WriteLine($"{Nombre} aguilea");
        public override void Alimentarse() => Console.WriteLine($"´{Nombre} come pescado");
    }

    /*4.	Sistema de facturación (interfaces + herencia + sobrecarga)
•	Crea una interfaz IImprimible con un método Imprimir().
Crea clases Cliente, Producto y Factura.
La factura debe tener una lista de productos, calcular el total y poder imprimirse
*/
    interface IImprimible
    {
        void Imprimir();
    }
    public class Cliente 
    {
        public string Nombre { get; set; }
        public string NI { get; set; }
        public Cliente(string nombre, string ni)
        {
            Nombre = nombre;
            NI = ni;
        }
    }
    public class Producto 
    {
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }

        public Producto(string descripcion, double precio, int cantidad)
        {
            Descripcion = descripcion;
            Precio = precio;
            Cantidad = cantidad;
        }
        public double SubTotal() => Precio * Cantidad;
    }
    public class Factura : IImprimible
    {
        public string Numero{ get; set; }
        public Cliente Cliente { get; set; }
        public List<Producto> Productos = new List<Producto>();
        public Factura(string numero, Cliente cliente)
        {
            Numero = numero;
            Cliente = cliente;
            
        }
        public void AgregarProducto(Producto p)
        {
            Productos.Add(p);
        }
        public double CalcularTotal()
        {
            double total = 0;
            foreach (var p in Productos)
            {
                total += p.SubTotal();
            }
            return total;   
        }

        public void Imprimir()
        {
            Console.WriteLine($"Factura nº: {Numero}" +
                $"\nCliente: {Cliente.Nombre}- NI: {Cliente.NI}" +
                $"\nDetalle de Productos");
            foreach (var p in Productos)
            {
                Console.WriteLine($"{p.Descripcion}- Cantidad: {p.Cantidad}- Subtotal{p.SubTotal()}");
            }
            Console.WriteLine($"Total Factura: {CalcularTotal()}");
        }
    }
    /*5.	Sistema de alquiler de vehículos (herencia + polimorfismo + sobreescritura)
•	Crea una clase base Vehiculo con propiedades Marca, Modelo y PrecioPorDia.
Deriva Auto y Moto.
Ambas deben implementar su propio cálculo del costo de alquiler según la duración y posibles descuentos.
*/  public abstract class Vehiculo
    {
        protected string Marca { get; set; }
        protected string Modelo { get; set; }
        protected double PrecioDia {  get; set; }
        public abstract double CalcularCoste(int dias);
        public Vehiculo(string marca, string modelo, double precio)
        {
            Marca = marca;
            Modelo = modelo;
            PrecioDia = precio;
        }
        public virtual void MostrarInfo()
        {
            Console.WriteLine($"{GetType().Name}: {Marca} {Modelo} - Pre/Dia: {PrecioDia}");
        }

    }
    public class Auto : Vehiculo
    {
        public bool TieneGPS { get; set; }
        public Auto(string marca, string modelo, double precio, bool gps) : base(marca, modelo, precio)
        {
            TieneGPS = gps;
        }
        public override double CalcularCoste(int dias)
        {
            double costo = dias * PrecioDia;
            if (TieneGPS) costo += 5 * dias;
            if (dias > 7) costo *= 0.9;//descuento 10%
                    return costo;
        }
    }
    public class Moto : Vehiculo
    {
        public bool TieneCasco { get; set; }
        public Moto(string marca, string modelo, double precio, bool casco) : base(marca, modelo, precio)
        {
            TieneCasco= casco;
        }

        public override double CalcularCoste(int dias)
        {
            double costo= dias * PrecioDia;
            if(TieneCasco) costo += 2 * dias;
            return costo;
        }
    }

    internal class Program
        {
            static void Main(string[] args)
            {

            List<Vehiculo> list = new List<Vehiculo>()
            {
                new Auto("Toyota","Corolla",50,true),
                new Moto("Honda","CD3",30,false)
            };

            foreach (Vehiculo v in list) {
                v.MostrarInfo();
                Console.WriteLine($"Costo por 10 dias {v.CalcularCoste(10) :0.00}");
            }


            Cliente c1 = new Cliente("Cliente1", "23242");
            Factura f1 = new Factura("34d", c1);
            f1.AgregarProducto(new Producto("Ordenador", 1200, 1));
            f1.AgregarProducto(new Producto("Raton", 12, 4));
            f1.AgregarProducto(new Producto("Teclado", 184, 5));



            //lista animales
            //List<Animal> animales = new List<Animal>()
            //{
            //    new Leon("Simba",5),
            //    new Delfin("Floppy",2),
            //    new Aguila("Roa",3)
            //};
            //foreach (var animal in animales)
            //{
            //    animal.MostrarInfo();
            //    animal.Alimentarse();
            //    animal.HacerSonido();
            //}



            //    List<Ppersona> list = new List<Ppersona>()
            //{
            //    new Aalumno("Andres", 22, 7),
            //    new Pprofesor("Javier", 33, "Desarrollo")
            //};

            //    foreach (var p in list)
            //    {
            //        p.MostrarDatos();
            //        ((IEevaluable)p).Evaluar();
            //        Console.WriteLine();
            //    }

            Console.ReadKey();
            }
        }
    }

