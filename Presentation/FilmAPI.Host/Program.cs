using Autofac;
using Autofac.Extensions.DependencyInjection;
using FilmAPI.Application.Abstraction;
using FilmAPI.Application.Repositories;
using FilmAPI.Host;
using FilmAPI.Persistance;
using FilmAPI.Persistance.Contexts;
using FilmAPI.Persistance.Repositories;
using FilmAPI.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IGenericUnitOfWork, UnitOfWork>();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerbuilder => containerbuilder.RegisterModule(new Modules()));

builder.Services.AddAutoMapper(typeof(MapProfiles));

builder.Services.AddDbContext<MovieAPIDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option => {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(MovieAPIDbContext)).GetName().Name);
    });
});


//builder.Services.AddScoped<IFilmRepository, FilmRepository>();
//builder.Services.AddScoped<IFilmService, FilmService>();

//builder.Services.AddScoped<ISalonRepository, SalonRepository>();
//builder.Services.AddScoped<ISalonService, SalonService>();

//builder.Services.AddScoped<IFilm_SalonRepository, Film_SalonRepository>();
//builder.Services.AddScoped<IFilm_SalonService, Film_SalonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
