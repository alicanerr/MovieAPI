using FilmAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Persistance.Contexts
{
    public class MovieAPIDbContext : DbContext
    {
        public MovieAPIDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Film> Films { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Film_Salon> Film_Salon { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }
    }
}
