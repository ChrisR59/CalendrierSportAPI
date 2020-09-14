using AgendaSportif.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaSportif.Tools
{
    public class DataDbContext : DbContext
    {

        public DataDbContext() :base()
        {   }

        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\agendasportif; Integrated Security = True");
        }
    }
}
