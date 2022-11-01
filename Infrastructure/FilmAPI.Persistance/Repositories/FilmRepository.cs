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
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        public FilmRepository(MovieAPIDbContext context) : base(context)
        {
        }
    }
}
