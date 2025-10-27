using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorVehiculos
{
    internal class Empresa
    {
        public List<Vehiculo> lista { get;}
        public Empresa()
        {
            lista = new List<Vehiculo>();
        }
        public void agregarVehiculo()
        {
            Vehiculo vehiculo;
            string marca, modelo, color;
            int año, peso, velMaxima;
            double precioBase;
            Console.WriteLine("Que tipo de vehiculo quieres registrar:\n1-> Auto \n2-> Moto \n3-> Camion");
            int opcion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Marca: ");
            marca = Console.ReadLine();
            Console.WriteLine("Modelo: ");
            modelo= Console.ReadLine();
            Console.WriteLine("Color: ");
            color = Console.ReadLine();
            Console.WriteLine("Año: ");
            año = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Peso (kg): ");
            peso = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Velocidad Maxima (km/h): ");
            velMaxima = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Precio Base: ");
            precioBase = Convert.ToDouble(Console.ReadLine());
            

            
            switch (opcion)
            {
                case 1:
                    int puertas, capcidadMaletero;
                    double decIva;
                    Console.WriteLine("Numero de puertas: ");
                    puertas = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Capacidad maletero (kg): ");
                    capcidadMaletero = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Descuento IVA: ");
                    decIva = Convert.ToDouble(Console.ReadLine());
                    vehiculo = new Auto(marca, modelo, año, color, peso, precioBase, velMaxima, puertas, capcidadMaletero, decIva);
                    vehiculo.CalcularImpuesto();
                    lista.Add(vehiculo);
                    Console.WriteLine("Vehiculo Auto añadido correctamente");
                    vehiculo.RealizarMantenimiento();
                    break;
                case 2:
                    string tipo;
                    int cilindrada;
                    bool tieneBaul;
                    string baul;
                    Console.WriteLine("Tipo de moto: ");
                    tipo = Console.ReadLine();
                    Console.WriteLine("Cilindrada (cc): ");
                    cilindrada = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Tiene Baul: (s/n)");
                    baul = Console.ReadLine();
                    tieneBaul = (baul == "s") ? true : false;
                    vehiculo = new Moto(marca, modelo, año, color, peso, precioBase, velMaxima, tipo, cilindrada, tieneBaul);
                    vehiculo.CalcularImpuesto();
                    lista.Add(vehiculo);
                    Console.WriteLine("Vehiculo Moto añadido correctamente");
                    vehiculo.RealizarMantenimiento();
                    break;
                case 3:
                    double capCarga;
                    int ejes;
                    bool usoComercial;
                    string respuesta;
                    Console.WriteLine("Capacidad Carga (t): ");
                    capCarga = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Numero de ejes: ");
                    ejes = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Uso Comercial?: (s/n)");
                    respuesta = Console.ReadLine();
                    usoComercial = (respuesta == "s") ? true : false;
                    vehiculo = new Camion(marca, modelo, año, color, peso, precioBase, velMaxima, capCarga, ejes, usoComercial);
                    vehiculo.CalcularImpuesto();
                    lista.Add(vehiculo);
                    Console.WriteLine("Vehiculo Camion añadido correctamente");
                    vehiculo.RealizarMantenimiento();
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }
    
        }
        public void mostrarLista(List<Vehiculo> lista)
        {
            if (lista.Count == 0)
            {
                Console.WriteLine("La lista esta vacia.");
                return;
            }
            Console.WriteLine("Deseas ver la lista detallada? s/n");
            string opcion = Console.ReadLine();
            if(opcion == "s")
            {
                foreach (Vehiculo vehiculo in lista)
                {
                    vehiculo.MostrarInfo(true);
                }
            }
            else if (opcion == "n")
            {
                foreach (Vehiculo vehiculo in lista)
                {
                    vehiculo.MostrarInfo();
                }
            }
            else
            {
                Console.WriteLine("Opcion Invalida");
            }

        }

    }
}
