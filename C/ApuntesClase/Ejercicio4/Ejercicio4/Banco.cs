using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    internal class Banco
    {

        private List<Cliente> clientes;
        public Banco()
        {
            clientes = new List<Cliente>();
        }
        public void AgregarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }
        public double calcularTotal()
        {
            double total = 0;
            foreach(var c in clientes)
            {
                total += c.Saldo;
            }
            return total;
        }
        
    }
}
