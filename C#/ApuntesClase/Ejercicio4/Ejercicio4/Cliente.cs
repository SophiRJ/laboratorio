using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
/*Un banco tiene 3 clientes que pueden hacer depósitos y extracciones. También el banco 
 * requiere que al final del día se calcule la cantidad de dinero que hay depositada.*/
{
    internal class Cliente
    {
        public string Nombre { get; set; }
        public double Saldo { get; set; }
        public Cliente(string _nombre) 
        {
            Nombre = _nombre;
            Saldo = 0;
        }

        public void ingresarDinero(int cantidad)
        {
            if(cantidad <= 0)
            {
                Console.WriteLine("Cantidad incorrecta"); 
            }
            Saldo += cantidad;
        }
        public void retirarDinero(int cantidad)
        {
            if (Saldo < cantidad || (Saldo - cantidad) < 0)
            {
                Console.WriteLine("No hay suficiente saldo");
            }
            else
            {
                Saldo -= cantidad;
            }
        }
        public void mostrarSaldo()
        {
            Console.WriteLine($"El saldo total es :{Saldo} ");
        }

    }
}
