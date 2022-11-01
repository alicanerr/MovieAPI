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
builder.Services.AddControllersWithViews();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
