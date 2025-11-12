using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    internal class SMS : INotificacion
    {
        public void Enviar(string mensaje) => Console.WriteLine($"Enviando por SMS {mensaje}");
        
    }
}
