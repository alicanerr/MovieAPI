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
    public class SalonController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ISalonService _salonService;

        public SalonController(IMapper mapper, ISalonService salonService)
        {
            _mapper = mapper;
            _salonService = salonService;
        }

        [HttpGet]
        public async Task<IActionResult> GettAllSalons()
        {
            var salons = await _salonService.GetAllAsync();
            var SalonDto = _mapper.Map<List<SalonDto>>(salons.ToList());
            return CreateActionResult(CustomResponseDto<List<SalonDto>>.Success(200, SalonDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var salon = await _salonService.GetByIdAsync(id);
            var SalonDto = _mapper.Map<SalonDto>(salon);
            return CreateActionResult(CustomResponseDto<SalonDto>.Success(200, SalonDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(SalonCreateDto SalonCreateDto)
        {
            var salon = await _salonService.AddAsync(_mapper.Map<Salon>(SalonCreateDto));
            return CreateActionResult(CustomResponseDto<Salon>.Success(201, salon));
        }
        [HttpPut]
        public async Task<IActionResult> Update(SalonDto SalonDto)
        {
            await _salonService.UpdateAsync(_mapper.Map<Salon>(SalonDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var salon = await _salonService.GetByIdAsync(id);
            await _salonService.RemoveAsync(salon);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
