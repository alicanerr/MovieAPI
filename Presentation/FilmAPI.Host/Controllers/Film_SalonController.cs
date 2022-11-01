using AutoMapper;
using FilmAPI.Application.Abstraction;
using FilmAPI.Application.DTOs;
using FilmAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmAPI.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Film_SalonController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IFilm_SalonService _film_SalonService;

        public Film_SalonController(IMapper mapper, IFilm_SalonService _filmSalonService)
        {
            _mapper = mapper;
            _film_SalonService = _filmSalonService;
        }
        [HttpGet]
        public async Task<IActionResult> GettAllFilms()
        {
            var film_Salons = await _film_SalonService.GetAllAsync();
            var film_salonsDto = _mapper.Map<List<Film_SalonDto>>(film_Salons.ToList());
            return CreateActionResult(CustomResponseDto<List<Film_SalonDto>>.Success(200, film_salonsDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var film_Salon = await _film_SalonService.GetByIdAsync(id);
            var film_salonDto = _mapper.Map<Film_SalonDto>(film_Salon);
            return CreateActionResult(CustomResponseDto<Film_SalonDto>.Success(200, film_salonDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(Film_SalonCreateDto Film_SalonCreateDto)
        {
           var film_Salon= await _film_SalonService.AddAsync(_mapper.Map<Film_Salon>(Film_SalonCreateDto));
            return CreateActionResult(CustomResponseDto<Film_Salon>.Success(201, film_Salon));
        }
        [HttpPut]
        public async Task<IActionResult> Update(Film_SalonDto film_salonDto)
        {
            await _film_SalonService.UpdateAsync(_mapper.Map<Film_Salon>(film_salonDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var film_Salon = await _film_SalonService.GetByIdAsync(id);
            await _film_SalonService.RemoveAsync(film_Salon);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
