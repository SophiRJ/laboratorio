using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RepasoC
{
    //public enum Sexo : int
    //{
    //    Masculino,
    //    Femenino
    //}
    //public class Alumno
    //{
    //    public string Nombre { get; set; }
    //    public int Semestre { get; set; }
    //    public int Edad { get; set; }
    //    public Sexo Sexo { get; set; }

    //    public Alumno(string nombre, int semestre, int edad, Sexo sexo)
    //    {
    //        Nombre = nombre;
    //        Semestre = semestre;
    //        Edad = edad;
    //        Sexo= sexo;
    //    }
    //    public override string ToString()
    //    {
    //        return string.Format($"{Nombre} {Edad} {Semestre} -Sexo:{Sexo}");
    //    }
    //}
    internal class Program
    {



        //enum diasSemana { LUNES,MARTES,MIERCOLES,JUEVES,VIERNES,SABADO,DOMINGO};// se asigna automaticamente de 0
        //si damos valores por defecto el sgte sin valor coge el sgte valor del anterior jueves=7
        static void Main(string[] args)
        {

            DateTime fecha = DateTime.Now;
            //Console.WriteLine("Hoy es {0} del mes {1} de {2}",fecha.Day,fecha.Month,fecha.Year);

            //DateTime mañana = fecha.AddDays(1);
            //Console.WriteLine("Mañana sera {0}", mañana.Day);

            //DayOfWeek dia = fecha.DayOfWeek;
            //Console.WriteLine($"hoy es: {dia}");
            //int numeroDeDia = (int)dia;
            //Console.WriteLine($"El numero de dia {numeroDeDia}");

            //foreach(DayOfWeek d in Enum.GetValues(typeof(DayOfWeek))){
            //    Console.WriteLine($"{d}={(int)d}");
            //}


            //Crear cultura español (España)
            CultureInfo culturaEspañol = new CultureInfo("es-ES");
            Console.WriteLine(fecha.ToString("f", culturaEspañol));

            //establecer cultura global para tod l app 
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es_ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es_ES");

            var culturaOriginal =Thread .CurrentThread.CurrentCulture;
            //Cambiar temporalmente;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es_ES");

            //restaurar la original
            Thread.CurrentThread.CurrentCulture = culturaOriginal;

            Console.WriteLine($"Fecha corta: {fecha.ToShortDateString()}");
            Console.WriteLine($"Fecha   larga: {fecha.ToLongDateString()}");
            Console.WriteLine($"Formato completo: {fecha.ToString("F")}");

            Console.ReadKey();

            //Alumno alumno = new Alumno("Edison", 2, 21, Sexo.Masculino);
            //Console.WriteLine(alumno.ToString());
            //Enumeraciones
            //const int LUNES = 0, MARTES = 1, MIERCOLES = 2, jUEVES = 3, VIERNES = 4, SABADO = 5, DOMINGO = 6;
            //tengo 2 caras la externa donde tengo los strings y la interna donde tengo la enumeracion por detras
            //diasSemana hoy = diasSemana.LUNES;
            //Console.WriteLine(hoy);//-->"lunes"
            //Console.WriteLine((int)hoy);//0;
            //int valor = 4;
            //diasSemana dia = (diasSemana)valor;

            //foreach (diasSemana dia in Enum.GetValues(typeof(diasSemana)))
            //{
            //    Console.WriteLine(dia);
            //}
        }
    }
}
