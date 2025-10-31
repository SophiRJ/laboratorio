using FacturacionApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Data
{
    public class AppDBContext:  DbContext
    {
        public DbSet <Client> Clients { get; set; }
        public DbSet <Project> Projects { get; set; }
        public DbSet <Invoice> Invoices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//cadena de coneccion
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EFCodeFirstDemoDB;Trusted_Connection=True;");
        }

    }
}
