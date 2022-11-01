using FilmAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Application.Abstraction
{
    public interface IFilmService : IGenericServices<Film>
    {
    }
}
