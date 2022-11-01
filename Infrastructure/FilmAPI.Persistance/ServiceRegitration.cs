using FilmAPI.Application.Abstraction;
using FilmAPI.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FilmAPI.Application.Repositories;
using FilmAPI.Persistance.Repositories;
using FilmAPI.Persistance.Services;


namespace FilmAPI.Persistance
{
    public static class ServiceRegitration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            //services.AddSingleton<IFilmService, IFilmService>();
            services.AddDbContext<MovieAPIDbContext>(x =>
            x.UseSqlServer(Configuration.ConnectionString),ServiceLifetime.Singleton);


            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<ISalonRepository, SalonRepository>();
            services.AddScoped<IFilm_SalonRepository, Film_SalonRepository>();
        }
    }
}
