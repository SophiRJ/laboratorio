using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    internal class CuentaBancaria
    {
        public string numeroCuenta { get; set; }
        public string titular { get; set; }
        public double saldo { get; set; }

        public CuentaBancaria(string _numCuenta, string _titular)
        {
            numeroCuenta = _numCuenta;
            titular = _titular;
            saldo = 0;
        }
        public void mostrarSaldo()
        {
            Console.WriteLine($"El saldo actual es: {saldo:F2} €");
        }
        public void depositar(double cantidad)
        {
            if (cantidad < 0) { Console.WriteLine($"Cantidad invalida"); }
            else
            {
                saldo += cantidad;
            }
        }
        public void retirar(double cantidad)
        {
            if (cantidad < 0 || cantidad > saldo)
            {
                Console.WriteLine($"Cantidad invalida");
            }
            else
            {
                saldo -= cantidad;
            }
        }
    }
}
