using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    internal class Email : INotificacion
    {
        public void Enviar(string mensaje) => Console.WriteLine($"Enviado por email {mensaje}");
        
    }
}
