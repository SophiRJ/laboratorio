# GimnasioApp – Gestión de Inscripciones y Clases

## Descripción
Aplicación de consola en **C#** que permite gestionar **socios, clases, entrenadores e inscripciones** de un gimnasio.  
Implementa persistencia de datos mediante **Entity Framework Core** **SQL Server** y **LINQ**.

## Funcionalidades
1. Listar inscripciones.  
2. Mostrar socios con mayor gasto mensual.  
3. Listar clases más populares.  
4. Registrar nuevas inscripciones desde la consola.

## Estructura del proyecto
El proyecto se ha organizado de la siguiente manera para facilitar el manejo y acceso a los datos

GimnasioApp
*Data*-> Contexto y configuración de base de datos
*Model*-> Clases para modelar las entidades
*Repository*-> Métodos para gestionar la base de datos (CRUD)
*Program.cs*-> Lógica de menú y ejecución principal


## Implementación paso a paso

### Creación del proyecto
- Crear una nueva aplicación de consola en Visual Studio (.NET 8.0).
- Instalar los paquetes NuGet necesarios:
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.SqlServer`
  - `Microsoft.EntityFrameworkCore.Tools`

### Creacion de Modelos
Crear las clases  o modelos necesarios en este caso: Clase, Entrenador, Inscripcion y Socio.
Las relaciones entre ellas seran Clase 1 - N inscripciones; Socio 1-N Inscripciones; Entrenador 1- N Clases
Se añadieron propiedades de navegacion para reflejar las relaciones entre ellas, estas relaciones 
se implementaron mediante claves foraneas y colecciones en las entidades, esto permite que EFCore 
genere automaticamente las tablas y relaciones en la base de datos.

### Definición del contexto de datos
Este contexto de datos hace de intermediario entre las clases modelo y la base de datos.
- Heredar de *DBContext* 
- Crear *DbSet* corresponientes o tablas de la base de datos
- Sobreescribir el metodo *OnConfiguring* para crear la cadena de conexion a la base de datos
- Sobreescribir el metodo *OnModelCreate* para configurar relaciones, restrciones y cargar datos iniciales
mediante el metodo *HasData*

```csharp
public class GimnasioContext : DbContext
{
    //dbSets
    public DbSet<Socio> Socios { get; set; }
    public DbSet<Clase> Clases { get; set; }
    public DbSet<Entrenador> Entrenadores { get; set; }
    public DbSet<Inscripcion> Inscripciones { get; set; }

    //conexion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GimnasioDatabase;Trusted_Connection=True;");
        }
    }

    // configuración de relaciones, restricciones y carga de datos iniciales
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
```

### Creacion de Repositorio
- Crear la Interfaz que permitira manejar y gestionar la base de datos con sus respectivos metodos
- Crear el Clase que hereda de dicha interfaz e implemente los metodos necesarios
```csharp
   public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();//Devuelve todos los registros
        Task<T?> GetByIdAsync(int id); //encuentra la entidad del Id que se le pasa
        Task AddAsync(T entity); // añade una entidad a la base de datos
        Task UpdateAsync(T entity); // modifica una entidad
        Task DeleteAsync(int id); // elimina un registro
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        //si la expresion es encontrada devuelve un true y ejecuta el findAsync 
        //devolviendo una lista
    }
```

### Migracion
Una vez configurado el contexto y los modelos, abrimos la **Consola del Administrador de Paquetes** y ejecutamos:

```powershell
Add-Migration M1       # Crea la definición de cambios
Update-Database        # Aplica los cambios y crea la base de datos
```

Esto genera una carpeta llamada **Migrations** con los archivos de la migración y la instantánea del modelo.

### Ejecución y pruebas
- Compilar y ejecutar el proyecto.  
- Verificar que las tablas y los datos iniciales se crean correctamente en SQL Server.  
- Probar las opciones del menú: listar, registrar, consultar, y agragar una nueva inscripcion.

