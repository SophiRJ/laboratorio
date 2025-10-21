using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ficheros
{
    class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Deoartamento { get; set; }
        public decimal Salario { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //manejar ficheros en C# Abrir fichero, leer datoso escribir datos, cerrar el fichero
            //Ejemplo de escritura
            //StreamWriter fichero;
            //fichero = File.CreateText("Prueba.txt");
            //fichero.WriteLine("Esta es la primera linea");
            //fichero.Write("Esta es otra que no termina");
            //fichero.WriteLine("y continua con esta otra linea");
            //fichero.Close();

            //string nombreArchivo = "out.txt";
            //string linea;
            //using (StreamWriter archivo = File.CreateText(nombreArchivo)) 
            //{
            //    do
            //    {
            //        Console.Write("Escribe ");
            //        linea = Console.ReadLine();

            //        if (linea.Length != 0)
            //        {
            //            archivo.WriteLine(linea);
            //        }
            //    } while (linea.Length != 0);

            //}


            //lectura
            //string rutaArchivo = "out.txt";
            //using (StreamReader fichero = new StreamReader(rutaArchivo))
            //{
            //    string linea;
            //    while ((linea = fichero.ReadLine()) != null)
            //    {
            //        Console.WriteLine(linea);
            //    }
            //}
            //Console.WriteLine("Lectura completa del fichero");

            //otra forma mas simple lectura
            //foreach(string linea in File.ReadLines(rutaArchivo))
            //{
            //    Console.WriteLine(linea);
            //}
            //Console.WriteLine("Lectura completa del fichero");

            //Buscar una palabra en concreto frase
            //string nombreArchivo = "out.txt";
            //string[]lineas= File.ReadAllLines(nombreArchivo);
            //bool salir = false;
            //do {
            //    Console.Write("Dime que quieres buscar en el fichero");
            //    string linea= Console.ReadLine();
            //    if(linea != "")
            //    {
            //        for(int i =0; i < linea.Length; i++)
            //        {
            //            if (lineas[i].Contains(linea))
            //            {
            //                Console.WriteLine(linea[i]);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        salir = true;
            //    }
            //} while (!salir);


            //string nombreFicero = "d:\\ejemplos\ejemplo1.txt";

            //string nombreFichero = @"d:\ejemplos\ejemplo1.txt";//ruta absoluta
            //string nombreFichero2 = @"..\datos\configuracion.txt";//ruta relativa



            //string rutaArchivo = "out.txt";
            //try
            //{
            //    if (File.Exists(nombreFichero)) { //siempre hacer comprobacion si existe
            //        string contenido=File.ReadAllText(nombreFichero);
            //    }
            //    using (StreamWriter sw = File.AppendText(rutaArchivo))
            //    {

            //        sw.WriteLine("Esta linea se agrega al final de fichero");
            //        sw.WriteLine("Otra linea mas");

            //        Console.WriteLine("Contenido agregado correctamente..");
            //        string contenido = File.ReadAllText(rutaArchivo);
            //        Console.WriteLine(contenido);

            //    }
            //}
            //catch (FileNotFoundException ex) {
            //    Console.WriteLine("El archiv no existe");
            //}catch(UnauthorizedAccessException)
            //{
            //    Console.WriteLine("No tienes permisos para ver este fichero");
            //}catch(Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}


            //=====================Directorioa============================================
            //Analizar e contenido de un directorio : Directory y SirectoryInfo
            //Directory : metodos para crear Dorectorio (CreateDirectory) borrarlo (Delete) mover(Move)
            //Existe? (Exists)

            //string miDirectorio = @"c:\ejejmplo1\ejemplo2";
            //if (!Directory.Exists(miDirectorio)) Directory.CreateDirectory(miDirectorio);
            ////Recuperar ficheros en un directorio: GetFiles()
            //string[] listaFicheros= Directory.GetFiles(miDirectorio);
            //foreach(string fich in listaFicheros)//recorrerlos
            //{
            //    Console.WriteLine(fich);
            //}

            //Ficheros CSV

            string rutaArchivo = "empleado.csv";
            //Lista empleados
            List<Empleado> empleados = new List<Empleado>();
            try
            {
                using(StreamReader sr= new StreamReader(rutaArchivo))
                {
                    string linea;
                    bool primera_linea = true;
                    while((linea = sr.ReadLine()) != null)  {
                        //Saltar la cabecera
                        if (primera_linea)
                        {
                            primera_linea=false;
                            continue;
                        }
                        //dividir por comas
                        string[] columnas = linea.Split(',');
                        Empleado empleado = new Empleado()
                        {
                            Id = int.Parse(columnas[0]),
                            Nombre = columnas[1],
                            Deoartamento = columnas[2],
                            Salario = decimal.Parse(columnas[3])
                        };
                        empleados.Add(empleado);
                    }
                }
                Console.WriteLine("======Lista empleados============");
                foreach (var empleado in empleados)
                {
                    Console.WriteLine($"{empleado.Nombre}- {empleado.Deoartamento}");
                    Console.WriteLine($"=========Estadisticas===========");
                    var salarioPromedio = empleados.Average(e => e.Salario);
                    var salarioMAx = empleados.Max(e => e.Salario);

                    Console.WriteLine($"Salario promedio {salarioPromedio}");
                    Console.WriteLine($"Salario maximo {salarioMAx}");
                }
            }
            
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());   
            }

            Console.ReadKey();
        }
    }
}
