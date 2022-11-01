using FilmAPI.Application.Repositories;
using FilmAPI.Domain.Models;
using FilmAPI.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Persistance.Repositories
{
    public class Film_SalonRepository : GenericRepository<Film_Salon>, IFilm_SalonRepository
    {
        public Film_SalonRepository(MovieAPIDbContext context) : base(context)
        {
        }
    }
}
