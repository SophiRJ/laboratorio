using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReservaHotel
{
    interface IReservable
    {
        void Reservar(string cliente);
        void ImprimirReserva();
    }
    abstract class Habitacion
    {
        public int Numero {  get; set; }
        public double PrecioNoche {  get; set; }
        protected Habitacion(int numero, double precioNoche) 
        {
            Numero = numero;
            PrecioNoche = precioNoche;
        }
        public virtual void MostrarInfo()
        {
            Console.WriteLine($"Habitacion {Numero}-${PrecioNoche}/noche");
        }

    }
    class HabitacionSimple : Habitacion
    {
        public HabitacionSimple(int numero, double precio) : base(numero, precio) { }
        public override void MostrarInfo()
        {
            Console.WriteLine($"Habitacion {Numero}-${PrecioNoche}/noche");
        }
    }
    class HabitacionDoble : Habitacion
    {
        public bool TieneVistaAlMar {  get; set; }
        public HabitacionDoble(int numero, double precio,bool tieneVista) : base(numero, precio) 
        {
            TieneVistaAlMar= tieneVista;
        }
        public override void MostrarInfo() {
            string vista = TieneVistaAlMar ? "Con vistas al mar" : "sin vistas";
            Console.WriteLine($"");
        }
    }
    class Reserva : IReservable
    {
        public string Cliente {  get; set; }
        public Habitacion Habitacion { get; set; }
        public int Noches {  get; set; }

        public Reserva(Habitacion habitacion, int noches)
        {
            Habitacion = habitacion;
            Noches = noches;
        }
        public void Reservar(string cliente)
        {
            Cliente= cliente;
            Console.WriteLine($"Reserva creada para {Cliente}");
        }
        public void ImprimirReserva()
        {
            Console.WriteLine($"---rserva---");
            Console.WriteLine($"Cliente: {Cliente}");
            Habitacion.MostrarInfo();
            Console.WriteLine($"Noches: {Noches}");
            Console.WriteLine($"Precio: ${Habitacion.PrecioNoche * Noches:0.00}");
        }
    }
    /*9.	Sistema de transporte (clases abstractas + interfaces + polimorfismo)
•	Crea una clase abstracta Transporte con métodos Mover() y Detener().
Crea una interfaz ITransportable con SubirPasajeros(int cantidad).
Implementa clases Bus, Avion y Barco.
*/
    interface ITransportable
    {
        void SubirPasajeros(int cantidad);
    }
    abstract class Transporte
    {
        public string Nombre { get; set; }
        public int VelocidadMax { get; set; }
        protected Transporte(string nombre, int velocidad)
        {
            Nombre = nombre;
            VelocidadMax = velocidad;
        }
        public abstract void Mover();
        public virtual void Detener()
        {
            Console.WriteLine($"{Nombre} se ha detenido");
        }
    }
    class Avion:Transporte,ITransportable 
    {
        public Avion(string nombre, int velocidad) : base(nombre, velocidad) { }
        public override void Mover() 
        {
            Console.WriteLine($"{Nombre} vuela a {VelocidadMax}km/h");
        }
        public void SubirPasajeros(int cantidad)
        {
            Console.WriteLine($"{cantidad} pasajeros abordaron el avion {Nombre}");
        }
    }
    class Bus:Transporte,ITransportable {
        private int pasajeros = 0;
        public Bus(string nombre, int velocidad) : base(nombre, velocidad) { }

        public override void Mover()
        {
            Console.WriteLine($"{Nombre} circula por carretera a {VelocidadMax}km/h");
        }
        public void SubirPasajeros(int cantidad)
        {
            pasajeros += cantidad;
            Console.WriteLine($"{cantidad} pasajeros subieron al bus. Total {pasajeros}");
        }
    }
    class Barco : Transporte, ITransportable 
    {
        public Barco(string nombre, int velocidad):base(nombre, velocidad) { }
        public override void Mover()
        {
            Console.WriteLine($"{Nombre} navega a {VelocidadMax}km/h");
        }
        public void SubirPasajeros(int cantidad)
        {
            Console.WriteLine($"{cantidad} pasajeros abordaron el barco {Nombre}");
        }

    }
    /*10.	Sistema de gestión de cuentas de usuario (herencia + interfaces + sobreescritura)
•	Crea una interfaz IAutenticable con métodos Login() y Logout().
Define una clase base CuentaUsuario con propiedades Usuario y Email.
Crea clases derivadas CuentaGratuita y CuentaPremium con distintos comportamientos de inicio de sesión y beneficios.
*/  interface IAuntenticable
    {
        void Login(string usuario, string contraseña);
        void Logout();
    }

    abstract class CuentaUsuario
    {
        public string Usuario { get; set; }
        public string Email { get; set; }
        protected CuentaUsuario(string usuario, string email)
        {
            Usuario = usuario;
            Email = email;
        }
        public abstract void Login(string usuario, string contraseña);
        public virtual void Logout() {
            Console.WriteLine($"{Usuario} ha cerrado la sesion");
        }
        public abstract void MostrarBeneficios();
    }
    class CuentaGratuita : CuentaUsuario 
    {
        public CuentaGratuita(string usuario, string email):base(usuario,email)
        {

        }
        public override void Login(string usuario, string contraseña)
        {
            Console.WriteLine($"Cuenta Gratuita Bienvenido {Usuario}. Acceso limitado");
        }
        public override void MostrarBeneficios()
        {
            Console.WriteLine($"Acceso basico a contnido publico uy anuncios visibles");
        }
    }
    class CuentaPremium : CuentaUsuario 
    { 
        public CuentaPremium(string usuario, string email) : base(usuario, email) { }

        public override void Login(string usuario, string contraseña)
        {
            Console.WriteLine($"Cuenta Premium Bienvenidp {Usuario} Acceso Completo");
        }
        public override void MostrarBeneficios()
        {
            Console.WriteLine($"Soporte Prioritario. Sin anuncios");
        }
    }
    /*11.	Sistema de control de dispositivos inteligentes (interfaces + composición + polimorfismo + enum)
Crea una interfaz IEncendible con métodos Encender() y Apagar().
Crea clases Lampara, Televisor y Refrigerador que implementen la interfaz.
Crea una clase CasaInteligente que contenga varios dispositivos y los controle en conjunto.
Cada dispositivo tenga un estado interno (Encendido o Apagado), definido por un enum. Además, cuando se encienda o apague un dispositivo, el estado se actualizará y podrá mostrarse.
*/

    enum EstadoDispositivo
    {
        Apagado,
        Encendido
    }
    interface IEncendible
    {
        void Encender();
        void Apagar();
        void MostrarEstado();
    }
    class Lampara : IEncendible
    {
        public string Nombre {  get; set; }
        public EstadoDispositivo Estado { get; set; }
        public Lampara(string nombre) {
            Nombre=nombre;
            Estado = EstadoDispositivo.Apagado;
        }
        public void Encender()
        {
            Estado = EstadoDispositivo.Encendido;
            Console.WriteLine($"{Nombre} encendida");
        }
        public void Apagar()
        {
            Estado = EstadoDispositivo.Apagado;
            Console.WriteLine($"{Nombre} apagado");
        }
        public void MostrarEstado()
        {
            Console.WriteLine($"{Nombre} esta en este momento {Estado}");
        }
    }
    class Televisor : IEncendible
    {
        public string Marca { get; set; }
        public EstadoDispositivo Estado { get; set; }

        public Televisor(string marca)
        {
            Marca = marca;
            Estado = EstadoDispositivo.Apagado;
        }
        public void Encender()
        {
            Estado = EstadoDispositivo.Encendido;
            Console.WriteLine($"Tele {Marca} encendida");
        }
        public void Apagar()
        {
            Estado = EstadoDispositivo.Apagado;
            Console.WriteLine($"Tele {Marca} apagado");
        }
        public void MostrarEstado()
        {
            Console.WriteLine($" Tele {Marca} esta en este momento {Estado}");
        }
    }
    class Refrigerador : IEncendible
    {
        public string Modelo { get; set; }
        public EstadoDispositivo Estado { get; set; }
        public Refrigerador(string modelo)
        {
            Modelo= modelo;
            Estado = EstadoDispositivo.Apagado;
        }
        public void Encender()
        {
            Estado = EstadoDispositivo.Encendido;
            Console.WriteLine($"Refrigerador {Modelo} encendida");
        }
        public void Apagar()
        {
            Estado = EstadoDispositivo.Apagado;
            Console.WriteLine($"Refrigerador {Modelo} apagado");
        }
        public void MostrarEstado()
        {
            Console.WriteLine($" Refrigerador {Modelo} esta en este momento {Estado}");
        }

    }
    class CasaInteligente
    {
        private List<IEncendible> dispositivos= new List<IEncendible>();
        public void AgregarDispositivo(IEncendible d)=> dispositivos.Add(d);
        public void EncenderTodo()
        {
            Console.WriteLine("Encendiendo todos los dispositivos");
            foreach (var d in dispositivos) d.Encender();       
        }
        public void ApagarTodo()
        {
            Console.WriteLine("apagando todos los dispositivos");
            foreach (var d in dispositivos) d.Apagar();
        }
        public void MostrarEstados()
        {
            Console.WriteLine("=============Estado actual de los dispositivos=========");
            foreach (var d in dispositivos) d.MostrarEstado();
        }
    }
    /*12.	Sistema de evaluación de proyectos (herencia + interfaces + sobrecarga + composición)
•	Crea una interfaz IEvaluable con método Evaluar().
•	Crea clases Proyecto y Evaluador.
•	El evaluador puede calificar el proyecto con puntuaciones o comentarios (usando sobrecarga).
*/
    interface IEvaluar
    {
        void Evaluar(int puntuacion);
        void Evaluar(string comentario);
    }
    class Proyecto
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Calificacion { get; set; }
        public string Comentario { get; set; }
        public Proyecto(string titulo, string descripcion)
        {
            Titulo = titulo;
            Descripcion = descripcion;
        }public void AsignarCalificaion(int nota)
        {
            Calificacion = nota;
        }
        public void AsignarComentario(string texto)
        {
            Comentario = texto;
        }
        public void MostrarResultado()
        {
            Console.WriteLine($"Proyecto {Titulo}");
            Console.WriteLine($"Descripcion {Descripcion}");
            Console.WriteLine($"Calificaion{Calificacion}");
            Console.WriteLine($"Comentario {Comentario}");

        }
    }
    class Evaluador:IEvaluar
    {
        public string Nombre { get; set; }
        private Proyecto Proyecto;
        public Evaluador(string nombre, Proyecto p)
        {
            Proyecto = p;
            Nombre = nombre;
        }
        public void Evaluar(int puntuacion)
        {
            Proyecto.AsignarCalificaion(puntuacion);
            Console.WriteLine($"{Nombre} asigno una calificacion" +
                $"de {puntuacion} al proyecto {Proyecto.Titulo}");
        }
        public void Evaluar(string comentario)
        {
            Proyecto.AsignarComentario(comentario);
            Console.WriteLine($"{Nombre} asigno un comentario" +
                $"de {comentario} al proyecto {Proyecto.Titulo}");
        }

    }
    /*13.	Sistema de vehículos eléctricos (herencia + sobrecarga + polimorfismo)
•	Crea una clase base Vehiculo con propiedades Marca y Modelo.
Crea clases derivadas VehiculoElectrico y VehiculoCombustion.
Implementa sobrecarga de métodos para “Cargar()” y “Repostar()” según tipo de vehículo.
*/
    class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public Vehiculo(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }
        public virtual void MostrarInfo()=> Console.WriteLine($"{Marca} {Modelo}");
        
    }
    class VehiculoElectrico : Vehiculo
    {
        public int CapacidadBateria { get; set; }
        public VehiculoElectrico(string marca, string modelo, int capacidadBateria) : base(marca, modelo)
        {
            CapacidadBateria= capacidadBateria;
        }
        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"Tipo Electrico - Bateria {CapacidadBateria} km/h");

        }


        public void Cargar() => Console.WriteLine($"{Marca} {Modelo} esta cargando");
        public void Cargar(int minutos) => Console.WriteLine($"{Marca} {Modelo} esta cargando em {minutos} minutos");
    }
    class VehiculoCombustion : Vehiculo
    {
        public double CapacidadDeposito { get; set; }
        public VehiculoCombustion(string marca, string modelo, double cpacidad) : base(marca, modelo)
        {
            CapacidadDeposito= cpacidad;
        }
        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"Tipo Combustin - Tanque {CapacidadDeposito} litros");

        }
        public void Repostar()=> Console.WriteLine($"{Marca} {Modelo} esta repostando");
        public void Cargar(double litros) => Console.WriteLine($"{Marca} {Modelo} repostando {litros} en el deposito");
    }
    /*14.	Sistema de gestión de empleados:
Tendremos una jerarquía de clases:
•	Persona (clase base)
•	Empleado (hereda de Persona)
•	Gerente y Desarrollador (heredan de Empleado)
•	También usaremos un enum llamado Departamento
*/
    enum Departamento
    {
        RecursosHumanos,
        Desarrollo,
        Ventas,
        Finanzas
    }
    class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Persona(string nombre, string apellido,DateTime fechaNacimiento)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
        }
        public int CalcularEdad()
        {
            int edad = DateTime.Now.Year - FechaNacimiento.Year;
            if (DateTime.Now.DayOfYear < FechaNacimiento.DayOfYear) edad--;
            return edad;
        }
        public virtual void MostrarInfo() {
            Console.WriteLine($"{Nombre} {Apellido}");
            Console.WriteLine($"{CalcularEdad()} años");
        }
    }

    class Empleado:Persona
    {
        public  int IdEmpleado{ get; set; }
        public Departamento Departamento { get; set; }
        public DateTime FechaContratacion { get; set; }
        public Empleado(string nombre, string apellido,DateTime fechaNacimiento)
            : base(nombre, apellido, fechaNacimiento) {
            FechaContratacion = DateTime.Now;
        }
        public Empleado(string nombre, string apellido, DateTime fechaNacimiento, int idEmpleado, Departamento departamento
            , DateTime fechaContratacion) : base(nombre, apellido, fechaNacimiento) { 
            IdEmpleado = idEmpleado;
            Departamento = departamento;
            FechaContratacion= fechaContratacion;
        }
        public int CalcularAntiguedad()
        {
            int años=DateTime.Now.Year - FechaContratacion.Year;
            if (DateTime.Now.DayOfYear < FechaContratacion.DayOfYear) años--;
            return años;
        }
        ///========================Falta
        public void MostarInfo() {
            base.MostrarInfo();

            Console.WriteLine($"ID Empleado: {IdEmpleado}");

            Console.WriteLine($"Departamento: {Departamento}");

            Console.WriteLine($"Antigüedad: {CalcularAntiguedad()} años");
        }
    
    }
    class Gerente : Empleado
    {
        public int NumeroempleadosACargo { get; set; }
        public Gerente(string nombre, string apellido, DateTime fechaNacimiento, int idEmpleado, Departamento departamento
            , DateTime fechaContratacion,int empleadosACargo) : base(nombre, apellido, fechaNacimiento)
        {
            NumeroempleadosACargo = empleadosACargo;
        }
        public void MostraInfo()
        {
            Console.WriteLine("=== Gerente ===");

            base.MostrarInfo();

            Console.WriteLine($"Empleados a cargo: {NumeroempleadosACargo}");

            Console.WriteLine("-----------------------------");
        }
    }
    // --- CLASE DERIVADA: Desarrollador --- 

    class Desarrollador : Empleado

    {

        public string LenguajePrincipal { get; set; }



        public Desarrollador(string nombre, string apellido, DateTime fechaNacimiento,

                             int idEmpleado, Departamento departamento, DateTime fechaContratacion,

                             string lenguaje)

            : base(nombre, apellido, fechaNacimiento, idEmpleado, departamento, fechaContratacion)

        {

            LenguajePrincipal = lenguaje;

        }



        // Sobrecarga de método 

        public void MostrarInfo(bool mostrarLenguaje)

        {

            MostrarInfo();

            if (mostrarLenguaje)

                Console.WriteLine($"Lenguaje principal: {LenguajePrincipal}");

            Console.WriteLine("-----------------------------");

        }



        // Sobrescribimos el método base 

        public override void MostrarInfo()

        {

            Console.WriteLine("=== Desarrollador ===");

            base.MostrarInfo();

            Console.WriteLine($"Lenguaje principal: {LenguajePrincipal}");

            Console.WriteLine("-----------------------------");

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Empleado> empleados = new List<Empleado>

        {

            new Gerente("Laura", "Gómez", new DateTime(1980, 5, 10), 101, Departamento.RecursosHumanos, new DateTime(2015, 3, 1), 5),

            new Desarrollador("Carlos", "Ruiz", new DateTime(1992, 7, 22), 102, Departamento.Desarrollo, new DateTime(2019, 8, 15), "C#"),

            new Desarrollador("Ana", "Martínez", new DateTime(1995, 11, 5), 103, Departamento.Desarrollo, new DateTime(2020, 2, 20), "Python")

        };



            // Polimorfismo: llamamos al mismo método pero se ejecuta según el tipo real del objeto 

            foreach (Empleado emp in empleados)

            {

                emp.MostrarInfo();

            }

            //Vehiculo v1 = new VehiculoElectrico("Tesla", "Modelo3", 75);
            //Vehiculo v2 = new VehiculoCombustion("Toyota", "Corolla", 45);

            //v1.MostrarInfo();
            //Console.WriteLine();
            //v2.MostrarInfo();
            //Console.WriteLine();

            //((VehiculoElectrico)v1).Cargar(30);
            //((VehiculoCombustion)v2).Cargar(20);

            //Proyecto pr1 = new Proyecto("Ingenieria", "Aplicacion para construir puentes");
            //Evaluador e1 = new Evaluador("IngPepe", pr1);

            //e1.Evaluar(9);
            //e1.Evaluar("Buen diseño y funcionalidad");

            //pr1.MostrarResultado();


            //CasaInteligente casa= new CasaInteligente();
            //casa.AgregarDispositivo(new Lampara("Lampara del salon"));
            //casa.AgregarDispositivo(new Televisor("Samsung"));
            //casa.AgregarDispositivo(new Refrigerador("LG"));

            //casa.MostrarEstados();

            //casa.EncenderTodo();
            //casa.MostrarEstados();

            //casa.ApagarTodo();
            //casa.MostrarEstados();

            //CuentaUsuario usu1 = new CuentaGratuita("maria123", "maria@gmail.com");
            //CuentaUsuario usu2 = new CuentaPremium("admin", "admin@gmail.com");

            //usu1.Login(usu1.Usuario, "1234");
            //usu1.MostrarBeneficios();
            //usu1.Logout();
            //usu2.Login(usu2.Usuario, "2224");
            //usu2.MostrarBeneficios();
            //usu2.Logout();


            //Transporte[] transportes =
            //{
            //    new Bus("Linea 24", 80),
            //    new Avion("Boing 432",850),
            //    new Barco("titanic III",40)
            //};

            //foreach (var t in transportes) 
            //{
            //    t.Mover();
            //    ((ITransportable)t).SubirPasajeros(52);
            //    t.Detener();
            //    Console.WriteLine();
            //}




            //Habitacion h1= new HabitacionSimple(101,80);
            //Habitacion h2 = new HabitacionDoble(202, 150, true);

            //Reserva r1 = new Reserva(h1, 3);
            //Reserva r2 =new Reserva(h2, 5);

            //r1.Reservar("Sonia Gonzalez");
            //r2.Reservar("Jesus Diaz");

            //Console.WriteLine();
            //r1.ImprimirReserva();
            //Console.WriteLine();
            //r2.ImprimirReserva();

            Console.ReadKey();
        }
    }
}
