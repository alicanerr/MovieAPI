using FilmAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Application.Repositories
{
    public interface IFilmRepository : IGenericRepository<Film>
    {
    }
}
