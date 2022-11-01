using AutoMapper;
using FilmAPI.Application.DTOs;
using FilmAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Persistance
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            CreateMap<Film, FilmDto>().ReverseMap();
            CreateMap<FilmCreateDto, Film>();
            CreateMap<Salon, SalonDto>().ReverseMap();
            CreateMap<SalonCreateDto, Salon>();
            CreateMap<Film_Salon, Film_SalonDto>().ReverseMap();
            CreateMap<Film_SalonCreateDto, Film_Salon>();
        }

    }
}
