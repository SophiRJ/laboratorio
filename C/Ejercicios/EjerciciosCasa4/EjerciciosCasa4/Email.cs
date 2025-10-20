using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa4
{
    public class Email : INotificacion
    {
        public void Enviar()
        {
            Console.WriteLine("Enviar por Email");
        }
    }
    public class SMS: INotificacion
    {
        public void Enviar()
        {
            Console.WriteLine("Enviar SMS");
        }
        }
}
