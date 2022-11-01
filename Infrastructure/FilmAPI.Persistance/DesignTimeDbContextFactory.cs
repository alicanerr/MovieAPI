using FilmAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MovieAPIDbContext>
    {
        public MovieAPIDbContext CreateDbContext(string[] args)
        {
 
            DbContextOptionsBuilder<MovieAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
