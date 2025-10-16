using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    internal class Program /*internal modificador de acceso a esta clase solo 
                            * la podre usar desde este namespace*/
    {
        struct fechaNacimiento
        {
            public int dia;
            public int mes;
            public int año;
        }
        struct tipoPersona
        {
            public string nombre;
            public char inicial;
            public int edad;
            public fechaNacimiento diaNacimiento;
            public float nota;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hola, estudiantes master");
            //Console.Write("Usuario: ");
            //Console.ReadLine();//leer datos del usuario
            /*Console.ReadKey(); /*Hace que el programa se detenga hasta 
                                * q el usuario interactue*/
            //Console.WriteLine(3 + 4);
            //int primerNumero;
            //primerNumero = 234;
            //int segundoNumero = 254, tercerNumero = 234;
            //Console.WriteLine(primerNumero);
            //int suma = 3 + 5;
            //int primerNum = 3, segundoNum = 4;
            //int sum = primerNum + segundoNum;
            //Console.WriteLine("la suma es {0}", suma);
            //Console.WriteLine("La suma es " + suma);
            //Console.WriteLine($"la suma es {suma}");
            //Console.WriteLine("La suma de {0} y {1} es {2}", primerNum, segundoNum, sum);
            //Console.Write("Introduce un numero: ");
            //int primerN = Convert.ToInt32(Console.ReadLine());//conversion string a entero
            //Console.Write("Numero 1: ");
            //int primerNumero= Convert.ToInt32(Console.ReadLine());
            //Console.Write("Numero 2: ");
            //int segundoNumero = Convert.ToInt32(Console.ReadLine());
            //int suma = primerNumero + segundoNumero;
            //Console.WriteLine($"La suma de {primerNumero} y {segundoNumero} es {suma}");
            //Usuario mete dos numeros (a,b)
            //el programa mostrara el resultado de la operacion (a+b) * (a-b)
            //debe ser igual a a2-b2
            //Console.Write("Introduce numero 1: ");
            //int var1 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Introduce numero 2: ");
            //int var2 = Convert.ToInt32(Console.ReadLine());
            //int resultado = ((var1 + var2) * (var1 - var2));
            //Console.WriteLine($"El resultado es {resultado}");
            //int restaCuadrados = ((var1 * var1) - (var2 * var2));
            //Console.WriteLine($"La diferencia de cuadrados es {restaCuadrados}");
            //Console.Write("Introduce un numero: ");
            //int numero = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("{0} x {1} es: {2}", numero, 1, numero * 1);
            //Console.WriteLine("{0} x {1} es: {2}", numero, 2, numero * 2);
            //Console.WriteLine("{0} x {1} es: {2}", numero, 3, numero * 3);
            //Console.WriteLine("{0} x {1} es: {2}", numero, 4, numero * 4);
            //Console.WriteLine("{0} x {1} es: {2}", numero, 5, numero * 1);
            //Console.WriteLine("{0} x {1} es: {2}", numero, 6, numero * 1);
            //Console.WriteLine("{0} x {1} es: {2}", numero, 7, numero * 1);
            //Console.WriteLine("{0} x {1} es: {2}", numero, 8, numero * 1);
            //if-else
            //int n;
            //Console.WriteLine("Numero: ");
            //n = Convert.ToInt32(Console.ReadLine());
            //if (n > 0) Console.WriteLine("Positivo");
            //else Console.WriteLine("Negativo");
            //Operadores logicos && y ; || o ; != no
            //int opcion=3;
            //int usuario=1;
            //if((opcion==1) && (usuario == 2))
            //{
            //}
            //OPERADOR CONDICIONAL
            //nombrevariable = condicion ? valor1 : valor2
            //int a, b, operacion, resultado;
            //Console.Write("Numero: ");
            //a = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Otro numero:");
            //b= Convert.ToInt32(Console.ReadLine());
            //Console.Write("Escribe una operacion (1=Resta;otro=Suma):");
            //operacion= Convert.ToInt32(Console.ReadLine());
            //resultado = (operacion == 1) ? a - b : a + b;
            //Console.WriteLine($"El resultado es {resultado}");
            //STRING
            //comillas dobles
            //string frase = "Hola que tal";
            //Console.Write("Introduce un frase");
            //string usuarioFrase = Console.ReadLine();
            //switch
            //Console.Write("Tu nombre: ");
            //string nombre= Console.ReadLine();
            //switch (nombre)
            //{
            //    case "Juan": Console.WriteLine("Hola Juan");
            //        break;
            //    case "Ruben": Console.WriteLine("Hola Pedro");
            //        break;
            //    default:
            //        Console.WriteLine("Hola usuario");
            //        break;
            //};
            //                //bucles
            ////while
            //Console.Write("Numero: (0 para salir)");
            //int number = Convert.ToInt32(Console.ReadLine());
            //while (number!=0)
            //{
            //    if (number > 0) Console.WriteLine("Positivo");
            //    else Console.WriteLine("Negativo");
            //    Console.WriteLine("Teclea otro numero (0 para salir)");
            //    number = Convert.ToInt32(Console.ReadLine());
            //}
            //// do -while
            //int valida = 741;
            //int clave;
            //do {
            //    Console.Write("Clave numerica: ");
            //    clave = Convert.ToInt32(Console.ReadLine());
            //    if (clave != valida) Console.WriteLine("No valida");
            //} while (clave!=valida);
            //Console.WriteLine("Acertaste");
            ////for
            //int contador = 0;
            //for (contador = 1; contador <= 10;contador++)
            //{
            //    if (contador == 4) ;
            //    break;
            //}
            ////excepciones try catch
            //int numero1, numero2, numero3;
            //try
            //{               
            //{               
            //    Console.Write("Primer numero1:");
            //    numero1 = Convert.ToInt32(Console.ReadLine());
            //    Console.Write("Primer numero2:");
            //    numero2 = Convert.ToInt32(Console.ReadLine());
            //    numero3 = numero1 / numero2;
            //    Console.WriteLine("La diivison es {0}", numero3);
            //}
            //catch(FormatException ex1)
            //{
            //    Console.WriteLine("Personalizar el mensaje {0}", ex1);
            //}
            //catch(DivideByZeroException ex1) {
            //    Console.WriteLine("Ha habido un error : {0}", "otro mensaje distinto");
            //}
            //catch (Exception ex1)
            //{
            //    //excepcion generalizada
            //}
            ////decimales -> max de 7 digitos
            //float calificacion= 12.5f; //añadir sufijo f la mas pequeña
            ////Convert.ToSingle()-> para convertir a float
            ////maximo de 15 cifra
            //double calificacion1 = 21.5;// decimal puro -> no le hace falta sufijo pero puedo
            //double calificacion2 = 21.5d;
            ////ConvertToDouble();
            ////maximo tb 15 cifras
            //decimal totalPage = 2345.87m; //lleva sufijo m
            //                              //Convert.ToDecmal();
            //float primerN;
            //double segundoN;
            //decimal sum;
            //Console.Write("Numero 1: ");
            //primerN = Convert.ToSingle(Console.ReadLine());
            //Console.Write("Numero 2: ");
            //segundoN = Convert.ToDouble(Console.ReadLine());
            //sum = Convert.ToDecimal(primerN + segundoN);
            //Console.WriteLine($"La suma es {0}mas {1} es {3}",primerN,segundoN,sum);
            ////converson decimal a string respetando la nomenclatura de decimales
            //double numeroP = 12.34;
            //Console.WriteLine(numeroP.ToString("N1"));//--> 12,3
            //Console.WriteLine(numeroP.ToString("N3"));//--> 12,340
            //Console.WriteLine(numeroP.ToString("0.0"));//--> 12,3 - igual q N1
            //Console.WriteLine(numeroP.ToString("0.000"));//--> 12,340
            //Console.WriteLine(numeroP.ToString("#.#"));//--> 12,3
            //Console.WriteLine(numeroP.ToString("#.##3"));//--> 12,340
            ////datos tipo caracter
            //char letra = 'A'; //-> comillas ''
            ////Convert.ToChar()
            //char letraTeclado = Convert.ToChar(Console.ReadLine());
            ////boolean
            //bool ultimoNivel = true;
            //int nivel = 10;
            //if (nivel == 10) ultimoNivel = !ultimoNivel;
            //int enemigos = 0;
            //bool partidaTerminada = (enemigos == 0) && ultimoNivel == false;
            ////arrays
            //int[] numeros = new int[5];
            //numeros[0] = 200;
            //numeros[1] = 150;
            //int[] numeros2 = { 200, 150, 232, 23 };
            //int suma1 = 0;
            //for(int i =0; i < numeros2.Length; i++)
            //{
            //    suma1 += numeros2[i];
            //int[] datos = { 10,15,12,0,0};
            //int cantidad = 3;
            //int capacidadArray = datos.Length;
            ////mostrarArray
            //for (int i=0;i<capacidadArray;i++) {
            //    Console.WriteLine($"{datos[i]}");
            //        }
            ////buscar un valor
            //for (int i = 0; i < capacidadArray; i++)
            //{
            //    if (datos[i]==15)
            //    Console.WriteLine($"El 15 esta en la posicion {datos[i]}");
            //}
            ////añadir un dato en ala primera posicion libre:6
            //Console.WriteLine("Añadir el 6 al final");
            //if (cantidad == capacidadArray)
            //{
            //    datos[cantidad] = 6;
            //    cantidad++;
            //}
            ////borrar un dato el segundo valor
            //int posicionBorrar = 1;
            //for(int i = posicionBorrar; i < cantidad; i++)
            //{
            //    datos[i] = datos[i + 1];               
            //}
            //cantidad--;
            //for (int i = 0; i < capacidadArray; i++)
            //{
            //    Console.WriteLine($"{datos[i]}");
            //}
            ////INSERTAR EN UNA POSICION DETERMINADA 30 EN LA TERCERA POSICION
            //if (cantidad < capacidadArray)
            //{
            //    Console.WriteLine("Hay hueco insert30 en la posicion 3");
            //    int posicionInsert = 2;
            //    for(int i=cantidad;i> posicionInsert; i--){
            //        datos[i] = datos[i - 1];
            //    }
            //    datos[posicionInsert] = 30;
            //    cantidad++;
            //}
            //for (int i = 0; i < capacidadArray; i++)
            //{
            //    Console.WriteLine($"{datos[i]}");
            //}
            //arrays de diferentes tipos puedo usar object 
            //object -> debo castear
            //dinamyc-> se castea solo
            //var mezcla = { 1, hola, true };
            //object[] datos1= { 1,"hola",true,3.14,'A'};
            //foreach(var item in datos1)
            //{
            //    Console.WriteLine($"{item} tipo: {item.GetType()}");//devuelve el tipo
            //}
            //int numer = (int)datos1[0];//-> castear por que es un object
            //string cadena = (string)datos1[1];
            ////dinamico
            //dynamic[] datos2= { 1, "hola", true, 3.14, 'A' };
            //foreach (var item in datos2)
            //{
            //    Console.WriteLine($"{item} tipo: {item.GetType()}");//devuelve el tipo
            //}
            //int numero2 = datos[0]; //no hace falta castear
            //arrays bidimensionales matrices
            //int datosAlumnos[2, 20];
            //dos grupos de tres
            int[,] notas = new int[2, 3]
            {
                {8,7,9},{6,3,18}
            };
            for (int i = 0; i < notas.GetLength(0); i++)
            {
                int suma = 0;
                for (int j = 0; j < notas.GetLength(1); j++)
                {
                    suma += notas[i, j];
                }
                double promedio = (double)suma / notas.GetLength(1);
                Console.WriteLine($"Alumno {i + 1} -Promedio :{promedio:F2}");
            }
            //arrays irregulares
            //jagged arrays
            int[][] jagged = new int[3][];
            jagged[0] = new int[] { 1, 2 };
            jagged[1] = new int[] { 3, 4, 5 };
            jagged[2] = new int[] { 6 };
            int[][] notas1;
            notas1 = new int[3][];//tres bloques de datos
            notas1[0] = new int[3];//tres notas en un grupo
            notas1[1] = new int[4];//4 notas en el segundo grupo
            notas1[2] = new int[2];//2 notas en el ultimo
            for (int i = 0; i < notas1.Length; i++)
            {
                for (int j = 0; j < notas1[i].Length; j++)
                {
                    notas1[i][j] = i + j;
                }
            }
            for (int i = 0; i < notas1.Length; i++)
            {
                for (int j = 0; j < notas1[i].Length; j++)
                {
                    Console.WriteLine("{0}", notas1[i][j]);
                }
            }
            //Registros trabajr con datos: "struc"
            //declararla fuera del main
            //struc tipoPersona
            //{public string nombre;
            //public char inicial;
            //public int edad;
            //public float nota;
            //}
            //en el main
            tipoPersona persona;
            persona.nombre = "Javier";
            persona.edad = 26;
            persona.inicial = 'J';
            tipoPersona[] personas = new tipoPersona[10];
            personas[0].nombre = "Maria";
            tipoPersona persona1;
            persona1.nombre = "Javier";
            persona1.edad = 26;
            persona1.inicial = 'J';
            persona1.diaNacimiento.dia = 5;
            persona1.diaNacimiento.mes = 8;
            persona1.diaNacimiento.año = 1852;
            //metodos para extraer una subcadena
            string frase = "Hola Master desarrollo";
            string saludo = frase.Substring(0, 4);
            //recuperar substring
            string cadenaExtraer = "Master";
            int posicion = frase.IndexOf(cadenaExtraer);
            string porcion = frase.Substring(posicion, cadenaExtraer.Length);//preguntar
            double valor = 1.2323;
            string valorString = valor.ToString();
            Console.WriteLine(valor.ToString("F2"));//1.23
            Console.WriteLine(valor.ToString("C"));//devuelv moneda 1.2323€
            Console.WriteLine(valor.ToString("P"));//porcentaje 1.23 %
            //split 
            string ejemplo = "uno,dos,tre,cuatro";
            char[] delimitadores = { ',', '.', ';' };
            string[] ejemploPartido = ejemplo.Split(delimitadores);
            for (int i = 0; i < ejemploPartido.Length; i++)
            {
                Console.WriteLine("Fragmento de {0}={1}", i, ejemploPartido[i]);
            }
            Console.ReadKey();
        }
    }
}
