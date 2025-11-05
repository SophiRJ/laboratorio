using IASColaborativas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IASColaborativas.Data
{
    public class AIColabContext:DbContext
    {
        public AIColabContext(){}//vacio para la migracion
        public AIColabContext(DbContextOptions<AIColabContext> options):base(options) {}

        //DbSets
        public DbSet<AIEntity> AIs => Set<AIEntity>();
        public DbSet<DataSetIA> Datasets => Set<DataSetIA>();
        public DbSet<ProyectoColaborativo> Proyectos => Set<ProyectoColaborativo>();
        public DbSet<Mensaje> Mensaje => Set<Mensaje>();
        public DbSet<Especializacion> Especilizaciones => Set<Especializacion>();
        public DbSet<AIProyecto> AIProyectos => Set<AIProyecto>();
        public DbSet<ProyectoDataSet> ProyectoDatasets => Set<ProyectoDataSet>();

        //Conexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AIColabDatabase;Trusted_Connection=True;");
            }
        }

        //Configuracion de modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //tablas intermedias-> le decimos que ambos sean las claves principales de esta tabla
            modelBuilder.Entity<AIProyecto>().HasKey(ap => new { ap.AIEntityId, ap.ProyectoColaborativoId });
            modelBuilder.Entity<ProyectoDataSet>().HasKey(pd => new { pd.ProyectoColaborativoId, pd.DatasetId });

            //Relaciones
            modelBuilder.Entity<AIProyecto>()
                .HasOne(ap=>ap.AIEntity)//cada proyecto tiene una AIEntity
                .WithMany(a=>a.Proyectos)//cada AIEntity puede tener muchos AIProyecto
                .HasForeignKey(ap=>ap.AIEntityId)
                .OnDelete(DeleteBehavior.NoAction);//No permitir borrar la entidad principal
                                                   //si existen entidades dependientes-> integridad referencial

            modelBuilder.Entity<AIProyecto>()
                .HasOne(ap => ap.ProyectoColaborativo)
                .WithMany(a => a.AIProyectos)
                .HasForeignKey(ap => ap.ProyectoColaborativoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ProyectoDataSet>()
                .HasOne(pd => pd.DataSet)
                .WithMany(d => d.ProyectoDataSets)
                .HasForeignKey(pd => pd.DatasetId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Mensaje>()
                .HasOne(m => m.Emisor)
                .WithMany(a => a.MensajesEnviados)
                .HasForeignKey(pd => pd.EmisorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Mensaje>()
                .HasOne(m => m.Receptor)
                .WithMany(a => a.MensajesRecibidos)
                .HasForeignKey(pd => pd.ReceptorId)
                .OnDelete(DeleteBehavior.NoAction);

            //Semilla
            // SEMILLA (corrigida)
            modelBuilder.Entity<Especializacion>().HasData(
                new Especializacion { Id = 1, Nombre = "Visión Artificial" },
                new Especializacion { Id = 2, Nombre = "Procesamiento de Lenguaje Natural" },
                new Especializacion { Id = 3, Nombre = "Análisis de Datos" }
            );

            modelBuilder.Entity<AIEntity>().HasData(
                new AIEntity { Id = 1, Nombre = "VisionAI", Description = "Especialista en reconocimiento de imágenes.", EspecializacionId = 1 },
                new AIEntity { Id = 2, Nombre = "LangMind", Description = "Procesamiento de texto y lenguaje natural.", EspecializacionId = 2 },
                new AIEntity { Id = 3, Nombre = "DataCrunch", Description = "Analista de grandes volúmenes de datos.", EspecializacionId = 3 }
            );

            modelBuilder.Entity<DataSetIA>().HasData(
                new DataSetIA { Id = 1, Nombre = "Imagenet Subset", Descripcion = "Conjunto de imágenes etiquetadas.", Fuente = "imagenet.org" },
                new DataSetIA { Id = 2, Nombre = "Wikipedia Corpus", Descripcion = "Artículos de Wikipedia para NLP.", Fuente = "wikipedia.org" },
                new DataSetIA { Id = 3, Nombre = "Kaggle Finance", Descripcion = "Datos financieros históricos.", Fuente = "kaggle.com" }
            );

            modelBuilder.Entity<ProyectoColaborativo>().HasData(
                new ProyectoColaborativo { Id = 1, Titulo = "Proyecto VisualNet", Descripcion = "Red neuronal para clasificación de imágenes.", EspecializacionId = 1 },
                new ProyectoColaborativo { Id = 2, Titulo = "Proyecto ChatNLP", Descripcion = "Modelo de diálogo y comprensión contextual.", EspecializacionId = 2 },
                new ProyectoColaborativo { Id = 3, Titulo = "Proyecto DataInsight", Descripcion = "Análisis predictivo de series temporales.", EspecializacionId = 3 }
            );

            modelBuilder.Entity<Mensaje>().HasData(
                new Mensaje { Id = 1, EmisorId = 1, ReceptorId = 2, Contenido = "¿Podrías ayudarme a generar descripciones de imágenes?", FechaEnvio = new DateTime(2025, 1, 10) },
                new Mensaje { Id = 2, EmisorId = 2, ReceptorId = 1, Contenido = "Claro, puedo procesar las etiquetas y crear textos naturales.", FechaEnvio = new DateTime(2025, 1, 11) },
                new Mensaje { Id = 3, EmisorId = 3, ReceptorId = 1, Contenido = "Tengo nuevos datos de rendimiento para tu red visual.", FechaEnvio = new DateTime(2025, 2, 5) }
            );

            modelBuilder.Entity<AIProyecto>().HasData(
                new AIProyecto { AIEntityId = 1, ProyectoColaborativoId = 1 },
                new AIProyecto { AIEntityId = 2, ProyectoColaborativoId = 2 },
                new AIProyecto { AIEntityId = 3, ProyectoColaborativoId = 3 },
                new AIProyecto { AIEntityId = 2, ProyectoColaborativoId = 3 }
            );

            modelBuilder.Entity<ProyectoDataSet>().HasData(
                new ProyectoDataSet { ProyectoColaborativoId = 1, DatasetId = 1 },
                new ProyectoDataSet { ProyectoColaborativoId = 2, DatasetId = 2 },
                new ProyectoDataSet { ProyectoColaborativoId = 3, DatasetId = 3 },
                new ProyectoDataSet { ProyectoColaborativoId = 3, DatasetId = 2 }
            );


        }
    }
}
