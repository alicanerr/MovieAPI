using AutoMapper;
using FilmAPI.Application.Abstraction;
using FilmAPI.Application.DTOs;
using FilmAPI.Application.Repositories;
using FilmAPI.Domain.Models;
using FilmAPI.Persistance.Contexts;
using FilmAPI.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace FilmAPI.Host.Controllers
{
    
    public class FilmController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFilmService _filmService;
        private readonly MovieAPIDbContext _movieAPIDbContext;

        public FilmController(IMapper mapper, IFilmService filmService, MovieAPIDbContext movieAPIDbContext)
        {
            _mapper = mapper;
            _filmService = filmService;
            _movieAPIDbContext = movieAPIDbContext;
        }

        public async Task<IActionResult> Index()
        {
           
            var films = await _filmService.GetAllAsync();
            var dto = _mapper.Map<List<FilmDto>>(films.ToList());
            return View(dto);
        }
        public async Task<IActionResult> Ekle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ekle(FilmCreateDto model)
        {
            var dto = _mapper.Map<Film>(model);
            var film = await _filmService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }
               
        public async Task<IActionResult> Update(int Id)
        {
            var films = await _filmService.GetByIdAsync(Id);
            return View(_mapper.Map<FilmDto>(films));
        }
        [HttpPost]
        public async Task<IActionResult> Update(FilmDto filmDto)
        {
            await _filmService.UpdateAsync(_mapper.Map<Film>(filmDto));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var film = await _filmService.GetByIdAsync(id);
            await _filmService.RemoveAsync(film);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult DateFilter(int? start, int? end)
        {
           
            var ExpenseDetails = _movieAPIDbContext.Films.Where(t => t.FilmYapimYil >= start && t.FilmYapimYil <= end).ToList();

            return View(ExpenseDetails);
        }

    }
}
