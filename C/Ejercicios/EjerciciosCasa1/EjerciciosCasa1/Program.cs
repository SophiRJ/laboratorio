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

            int[] datos = { 10, 15, 12, 0, 0 };

            int capacidadArray = datos.Length;
            Console.WriteLine(capacidadArray);
            Console.ReadKey();
        }
    }
}
