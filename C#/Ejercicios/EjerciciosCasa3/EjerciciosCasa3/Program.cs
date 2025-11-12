using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Persona persona = new Persona();           
            //persona.Nombre = "Maria";           
            //DateTime fechaN= new DateTime(1990, 8, 16);
            //persona.fechaNacimiento = fechaN;
            //persona.saludar();

            //PersonaInglesa personaInglesa = new PersonaInglesa();
            //personaInglesa.Nombre="Carla";
            //personaInglesa.fechaNacimiento = new DateTime(2000, 3, 15);
            //personaInglesa.saludar();
            //personaInglesa.TomarTe();

            //PersonaInglesa personaInglesa1 = new PersonaInglesa();
            //personaInglesa1.Nombre = "Catherine";
            //personaInglesa1.fechaNacimiento = new DateTime(2001, 6, 13);
            //personaInglesa1.saludar();
            //personaInglesa1.TomarTe();

            //PersonaItaliana personaItaliana = new PersonaItaliana();
            //personaItaliana.Nombre = "Sofia";
            //personaItaliana.fechaNacimiento = new DateTime(1990, 8, 23);
            //personaItaliana.saludar();

            Estadistica estadistica = new Estadistica(40,50,30);
            estadistica.sumar();
            estadistica.media();
            
        }
    }
}
