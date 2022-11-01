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
    public class Film_SalonService : GenericServices<Film_Salon>, IFilm_SalonService
    {
        public Film_SalonService(IGenericRepository<Film_Salon> repository, IGenericUnitOfWork unitofWork) : base(repository, unitofWork)
        {
        }
    }
}
