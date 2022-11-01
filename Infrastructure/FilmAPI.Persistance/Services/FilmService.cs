using FilmAPI.Application.Abstraction;
using FilmAPI.Application.Repositories;
using FilmAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Persistance.Services
{
    public class FilmService : GenericServices<Film>, IFilmService
    {
        public FilmService(IGenericRepository<Film> repository, IGenericUnitOfWork unitofWork) : base(repository, unitofWork)
        {
        }
    }
}
