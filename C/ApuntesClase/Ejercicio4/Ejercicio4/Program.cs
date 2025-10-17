using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    /*Crea una interfaz 'INotificacion' con un método 'Enviar()'. 
     * Implementa clases 'Email' y 'SMS' que la usen de forma diferente. 
     * Simula el envío de distintos mensajes.*/
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<INotificacion> notificaciones = new List<INotificacion>
        {
            new Email(),
            new SMS(),
        };
            foreach (var n in notificaciones)
            {
                n.Enviar("Hola Master desarrollo");

            }
            Console.ReadKey();
        }
    }
}
