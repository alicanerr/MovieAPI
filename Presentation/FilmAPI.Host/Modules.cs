using Autofac;
using FilmAPI.Application.Abstraction;
using FilmAPI.Application.Repositories;
using FilmAPI.Persistance.Repositories;
using FilmAPI.Persistance.Services;

namespace FilmAPI.Host
{
    public class Modules : Autofac.Module 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericServices<>)).As(typeof(IGenericServices<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IGenericUnitOfWork>();


            builder.RegisterType<FilmRepository>().As<IFilmRepository>();
            builder.RegisterType<FilmService>().As<IFilmService>();
            builder.RegisterType<SalonRepository>().As<ISalonRepository>();
            builder.RegisterType<SalonService>().As<ISalonService>();
            builder.RegisterType<Film_SalonRepository>().As<IFilm_SalonRepository>();
            builder.RegisterType<Film_SalonService>().As<IFilm_SalonService>();

        }
    }

}
