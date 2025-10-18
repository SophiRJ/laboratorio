using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosCasa1
{
    internal class Program
    {
        struct Cancion
        {
            public string artista;
            public string titulo;
            public int duracion;
            public double tamañoFichero;

        }
        struct fichero{
            public string nombre;
            public int tamaño;
        }
        static void Main(string[] args)
        {
            //Primer ejercicio
            //Console.WriteLine("Primer Ejercicio");
            //int primerN = 121;
            //int segundoN = 132;
            //int resultado = 121 * 132;
            //Console.WriteLine($"El resultado de multiplicar {primerN} x {segundoN} es {resultado}");


            ////Crea un programa que calcule la suma de 285 y 1396, usando variables. 
            //Console.WriteLine("Segundo Ejercicio");
            //int sumando1 = 285;
            //int sumando2 = 1396;
            //Console.WriteLine("La suma entre {0} y {1} es {2}",sumando1,sumando2,(sumando1+sumando2));

            //Console.WriteLine("Tercer Ejercicio");
            ////Crea un programa que calcule el resultado de dividir 3784 entre 16, usando variables.
            //int n = 3784;
            //int n1 = 16;
            //Console.WriteLine($"La division de {n} entre {n1} es {n / n1}");

            //Console.WriteLine("Cuarto Ejercicio");
            ////Crea un programa que calcule el producto de dos números introducidos por el usuario. 
            //Console.Write("Primer numero: ");
            //int number = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Segundo numero: ");
            //int number1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("El producto de {0} x {1} es {2}",number,number1,(number*number1));

            //Console.WriteLine("Quinto Ejercicio");
            ////Crea un programa que calcule la división de dos números introducidos por el usuario
            //Console.Write("Introduce primer numero para dividir: ");
            //int dividendo = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Introduce segundo numero para dividir: ");
            //int divisor = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"El resultado de dividir {dividendo} entre {divisor} es {dividendo/divisor}");

            //Console.WriteLine("1.6 Ejercicio");
            ////Multiplicar dos números tecleados por usuario.
            ////El programa deberá contener un comentario al principio, que recuerde cúal es su objetivo.
            //Console.WriteLine("Vamos a multiplicar dos numeros. Introducelos");
            //Console.Write("Primer digito: ");
            //int digito = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Segundo digito: ");
            //int digito1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"El resultado de multiplicar {digito} por {digito1} es {digito*digito1}");


            //Console.WriteLine("1.10 Ejercicio");
            ////Crea un programa que convierta de grados Celsius (centígrados) a Kelvin y a Fahrenheit
            //Console.Write("Introduce los grados Celsius: ");
            //int gradosC = Convert.ToInt32(Console.ReadLine());
            //int gradosF = gradosC * 18 / 10 + 32;
            //int gradosK = gradosC + 273;
            //Console.WriteLine($"{gradosC}º Celsius equivale a {gradosF}º Fahrenheit y a {gradosK}º Kelvin");

            //Console.WriteLine("1.11 Ejercicio");
            //Console.Write("Escribe una cantidad de millas: ");
            //int millas = Convert.ToInt32(Console.ReadLine());
            //double metros= millas*1609.344;
            //Console.WriteLine($"{millas} millas equivale a {metros:F2} metros");


            Console.WriteLine("1.12 Ejercicio");
            /*Crear un programa que pida al usuario dos números enteros y diga "Uno de los números es positivo",
             * "Los dos números son positivos" o bien "Ninguno de los números es positivo", según corresponda*/
            //Console.WriteLine("primer numero: ");
            //int numero1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("segundo numero: ");
            //int numero2 = Convert.ToInt32(Console.ReadLine());

            //if (numero1 > 0 && numero2 > 0) Console.WriteLine("Los dos numeros son positivos");
            //else if (numero1 > 0 || numero2 > 0) Console.WriteLine("Uno de los numeros es positivo");
            //else Console.WriteLine("Ninguno de los numeros es positivo");

            Console.WriteLine("1.13 Ejercicio");
            //Crear un programa que pida al usuario tres números y muestre cuál es el mayor de los tres
            //Console.WriteLine("primer numero: ");
            //int numero1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("segundo numero: ");
            //int numero2 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("tercer numero: ");
            //int numero3 = Convert.ToInt32(Console.ReadLine());

            //if (numero1 > numero2 && numero1 > numero3) Console.WriteLine($"El numero mayor es {numero1}");
            //else if (numero2 > numero1 && numero2 > numero3) Console.WriteLine($"El numero mayor es {numero2}");
            //else { Console.WriteLine($"El numero mayor es {numero3}"); }

            Console.WriteLine("1.14 Ejercicio");
            //Crear un programa que pida al usuario dos números enteros y diga si son iguales o,
            //en caso contrario, cuál es el mayor de ellos. 
            //Console.WriteLine("primer numero: ");
            //int numero1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("segundo numero: ");
            //int numero2 = Convert.ToInt32(Console.ReadLine());

            //if (numero1 == numero2) Console.WriteLine($"Ambos son iguales. {numero1} es igual a {numero2}");
            //else if (numero2 > numero1) Console.WriteLine($"El mayor es {numero2}");
            //else Console.WriteLine($"El mayor es {numero1}");


            //Crear un programa que use el operador condicional para mostrar un el valor absoluto
            //de un número de la siguiente forma:
            //si el número es positivo, se mostrará tal cual; si es negativo, se mostrará cambiado de signo. 
            Console.WriteLine("1.15 Ejercicio");
            //Console.WriteLine("numero: ");
            //int numero1 = Convert.ToInt32(Console.ReadLine());
            //int valorAbs = numero1 >= 0 ? numero1 : numero1 * (-1);
            //Console.WriteLine($"El valor absoluto es: {valorAbs}");

            Console.WriteLine("1.16 Ejercicio");
            //Crear un programa que pida al usuario su contraseña (numérica).
            //Deberá terminar cuando introduzca como contraseña el número 1111,
            //pero volvérsela a pedir tantas veces como sea necesario. 


            //Console.WriteLine("Introduce la contraseña: ");
            //int contraseñaUsuario = Convert.ToInt32(Console.ReadLine());

            //while (contraseñaUsuario != 1111)
            //{
            //    Console.Write("Error no es la contraseña. Introducela otra vez: ");
            //    contraseñaUsuario= Convert.ToInt32(Console.ReadLine());
            //}
            //Console.WriteLine("Enhorabuena, tienes acceso");

            Console.WriteLine("1.17 Ejercicio");
            // Un programa que dé al usuario tres oportunidades para adivinar un número del 1 al 10. 
            //int oportunidades = 0;
            //Console.WriteLine("Adivina el numero entre 1 y 10, tienes 3 oportunindades");
            //int numeroAdivinar = 5;
            //Console.Write("Numero: ");
            //int numeroUsuario= Convert.ToInt32(Console.ReadLine());
            //while (oportunidades < 3 )
            //{
            //    if (numeroAdivinar == numeroUsuario)
            //    {
            //        Console.Write("Felicidades adivinaste ");
            //        break;
            //    }
            //    else
            //    {
            //        if (numeroUsuario > numeroAdivinar)
            //        {
            //            Console.Write("El numero es menor: ");
            //            numeroUsuario = Convert.ToInt32(Console.ReadLine());
            //            oportunidades++;
            //        }
            //        else
            //        {
            //            Console.Write("El numero es mayor: ");
            //            numeroUsuario = Convert.ToInt32(Console.ReadLine());
            //            oportunidades++;
            //        }
            //    }                          
            //}
            //Console.WriteLine($"Lo siento perdiste");

            Console.WriteLine("1.18 Ejercicio");
            //Crear un programa que pregunte al usuario su edad y su año de nacimiento.
            //Si la edad que introduce no es un número válido,
            //mostrará un mensaje de aviso, pero aun así le preguntará su año de nacimiento. 
            //try
            //{
            //    Console.Write("Edad:");
            //    int edad = Convert.ToInt32(Console.ReadLine());
            //}
            //catch (Exception error)
            //{
            //    Console.WriteLine("Ha habido un error de formato {0}", error.Message);
            //}
            //Console.Write("Anio:");
            //int anio = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("1.20 Ejercicio");
            //	(1.20) Un programa que prepare espacio para un máximo de 5 nombres.Deberá mostrar al
            //usuario un menú que le permita realizar las siguientes operaciones:

            //string[] datos = { "Maria","Sofia",null, null, null };

            //int capacidadArray = datos.Length;
            //int cantidad = 2;
            //int opcion = 0;
            //Console.WriteLine(capacidadArray);

            //do
            //{
            //    Console.WriteLine("Elije una opcion: \n1.Añadir un dato" +
            //        "\n2.Insertar un dato en alguna posicion indicada." +
            //        "\n3.Boorar un dato" +
            //        "\n4.Mostrar datos del Array." +
            //        "\n5.Salir del programa");
            //    opcion = Convert.ToInt32(Console.ReadLine());
            //    switch (opcion) 
            //    {
            //        case 1:
            //            Console.Write("Nombre a añadir");
            //            string nombre = Console.ReadLine();
            //            datos[cantidad] = nombre;
            //            cantidad++;
            //            break;
            //        case 2:
            //            if (cantidad == capacidadArray)
            //            {
            //                Console.WriteLine("El array esta lleno");
            //            }
            //            Console.Write($"El array tiene {cantidad} posiciones.Indique la posicion a la que quiere agregar");
            //            int pos= Convert.ToInt32(Console.ReadLine());
            //            Console.WriteLine("Indique el nombre que desea insertar: ");
            //            string nombre1=Console.ReadLine();
            //            for(int i=cantidad; i >= pos; i--)
            //            {
            //                datos[i] = datos[i - 1];
            //            }
            //            datos[pos] = nombre1;
            //            cantidad++;
            //            break;
            //        case 3:
            //            if (cantidad == 0)
            //            {
            //                Console.WriteLine("Nohay datos en el array");
            //            }
            //            Console.Write("Indique la posicion que desea borrar: ");
            //            int posicionBorrar = Convert.ToInt32(Console.ReadLine());
            //            for(int i = posicionBorrar; i <= cantidad; i++)
            //            {
            //                datos[i] = datos[i + 1];
            //            }
            //            cantidad--;
            //            break;
            //        case 4:
            //            for(int i = 0; i < cantidad; i++)
            //            {
            //                Console.WriteLine("Item{0}: {1}",(i+1),datos[i]);
            //            }
            //            break;
            //        default:
            //            Console.WriteLine("Saliendo...");
            //            break;
            //    }

            //} while (opcion!=5);

            Console.WriteLine("1.21 Ejercicio");
            //Cancion cancion;
            //Console.Write("Artista: ");
            //cancion.artista=Console.ReadLine();
            //Console.Write("Titulo: ");
            //cancion.titulo=Console.ReadLine();
            //Console.Write("Duracion (segundos): ");
            //cancion.duracion =Convert.ToInt32( Console.ReadLine());
            //Console.Write("Tamaño (kb): ");
            //cancion.tamañoFichero =Convert.ToInt32( Console.ReadLine());

            //Console.WriteLine($"Artista: {cancion.artista}, Titulo: {cancion.titulo}, Duracion: {cancion.duracion} sg, Tamaño {cancion.tamañoFichero} Kb");

            Console.WriteLine("1.22 Ejercicio");
            /*
             •	(1.22) Un programa que pida al usuario varios números separados por espacios y muestre su suma. */

            //Console.Write("Introduce varios numeros separados por un espacio");
            //string cadenaNumeros= Console.ReadLine();
            //int[] numeros= Array.ConvertAll(cadenaNumeros.Split(' '),int.Parse);


            //int suma = 0;
            //foreach(int item in numeros)
            //{
            //    suma += item;
            //}
            //Console.WriteLine($"La suma es {suma}");
            //int suma = 0;

            //Console.Write("introduzca varios números separados por espacios");
            //string Cadena = Console.ReadLine();

            //string[] valores = Cadena.Split(' ');
            //for (int i = 0; i < valores.Length; i++)
            //{
            //    int valor = Convert.ToInt32(valores[i]);
            //    suma += valor;
            //}
            //Console.WriteLine("la suma vale {0}", suma);
            Console.WriteLine("1.23 Ejercicio");
            //Console.Write("Escribe una palabra");
            //string cadena= Console.ReadLine();
            //StringBuilder nuevaCadena = new StringBuilder(cadena);
            //for(int i = 0; i < cadena.Length; i++)
            //{               
            //    if (i % 2 != 0)
            //    {
            //        nuevaCadena[i] = char.ToUpper(cadena[i]);
            //    }                
            //}
            //cadena = nuevaCadena.ToString();
            //Console.WriteLine(cadena);

            Console.WriteLine("1.24 Ejercicio");
            /*Un programa que pida tu nombre, tu día de nacimiento y tu mes de nacimiento y lo junte todo en una cadena,
             * separando el nombre de la fecha 
             * por una coma y el día del mes por una barra inclinada, así: "Juan, nacido el 31/12". */
            //Console.Write("Escribe tu nombre ");
            //string nombre= Console.ReadLine();
            //Console.Write("Dia nacimiento ");
            //string dia= Console.ReadLine();
            //Console.Write("Mes: ");
            //string mes= Console.ReadLine();

            //StringBuilder datosCompletos= new StringBuilder();
            //datosCompletos.Append($"{nombre}, nacido el ");
            //datosCompletos.Append($"{dia}/");
            //datosCompletos.Append(mes);
            //Console.WriteLine(datosCompletos.ToString());

            Console.WriteLine("1.25 Ejercicio");
            fichero[] fichas=new fichero[1000];
            int cantidad = 0;
            int opcion=0;
            string nombre;
            int tamaño;
            int numeroFichero;
            do 
            {
                Console.Write("Elija una opcion:\n1.Añadir datos de un nuevo fichero." +
                    "\n2.Mostrar los nombres de todos lo ficheros " +
                    "\n3.Mostrar Ficheros que sean de mas e cierto tamaño" +
                    "\n4.Ver datos de cierto fichero" +
                    "\n5.Salir de la aplicacion.");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion) 
                {
                    case 1:
                        if (cantidad == 999)
                        {
                            Console.WriteLine("No hay espacio");
                        }
                        Console.Write("Nombre: ");
                        nombre=Console.ReadLine();
                        Console.Write("Tamaño(kb): ");
                        tamaño=Convert.ToInt32(Console.ReadLine());
                        fichas[cantidad].nombre = nombre;
                        fichas[cantidad].tamaño = tamaño;
                        cantidad++;
                        break;
                    case 2:
                        for(int i=0; i < cantidad; i++)
                        {
                            Console.WriteLine($"Ficha {i+1}: {fichas[i].nombre}");
                        }
                        break;
                    case 3:
                        Console.Write("A partir de que tamaño quieres buscar: ");
                        tamaño = Convert.ToInt32(Console.ReadLine());
                        for(int i = 0; i < cantidad; i++)
                        {
                            if (fichas[i].tamaño >= tamaño)
                            {
                                Console.WriteLine($"Ficha {i + 1}: {fichas[i].nombre}: Tamaño: {fichas[i].tamaño}");
                            }
                        }
                        break;
                    case 4:
                        Console.Write("Indica que numero de fichero quieres ver: ");
                        numeroFichero = Convert.ToInt32(Console.ReadLine());
                        if (numeroFichero > cantidad)
                        {
                            Console.WriteLine("No existe ese fichero");
                        }
                        for(int i = 0; i < cantidad; i++)
                        {
                            if (numeroFichero - 1 == i)
                            {
                                Console.WriteLine($"Fichero {i + 1}, Nombre: {fichas[i].nombre},Tamaño: {fichas[i].tamaño}");
                            }
                        }
                        break;
                    case 5:
                        Console.WriteLine("Saliendo..");
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }
            } while (opcion!=5);
            Console.ReadKey();
        }
    }
}
