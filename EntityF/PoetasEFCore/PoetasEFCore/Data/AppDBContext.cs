using Microsoft.EntityFrameworkCore;
using PoetasEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoetasEFCore.Data
{
    public class AppDBContext:DbContext
    {
        public DbSet<Meter> Meters { get; set; }
        public DbSet<Poem> Poems { get; set; }
        public DbSet<Poet> Poets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PoetasDB;Trusted_Connection=True;");
        }
    }
}
