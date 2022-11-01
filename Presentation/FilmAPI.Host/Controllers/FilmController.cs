using AutoMapper;
using FilmAPI.Application.Abstraction;
using FilmAPI.Application.DTOs;
using FilmAPI.Application.Repositories;
using FilmAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmAPI.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IFilmService _filmService;

        public FilmController(IMapper mapper, IFilmService filmService)
        {
            _mapper = mapper;
            _filmService = filmService;
        }
        [HttpGet]
        public async Task<IActionResult> GettAllFilms()
        {
            var films = await _filmService.GetAllAsync();
            var FilmDto = _mapper.Map<List<FilmDto>>(films.ToList());
            return CreateActionResult(CustomResponseDto<List<FilmDto>>.Success(200, FilmDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var film = await _filmService.GetByIdAsync(id);
            var filmDto = _mapper.Map<FilmDto>(film);
            return CreateActionResult(CustomResponseDto<FilmDto>.Success(200, filmDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(FilmCreateDto FilmCreateDto)
        {
           var film =  await _filmService.AddAsync(_mapper.Map<Film>(FilmCreateDto));
            return CreateActionResult(CustomResponseDto<Film>.Success(201, film));
        }
        [HttpPut]
        public async Task<IActionResult> Update(FilmDto filmDto)
        {
            await _filmService.UpdateAsync(_mapper.Map<Film>(filmDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var film = await _filmService.GetByIdAsync(id);
            await _filmService.RemoveAsync(film);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
