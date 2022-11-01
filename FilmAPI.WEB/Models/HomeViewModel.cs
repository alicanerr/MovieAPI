using FilmAPI.Application.DTOs;

namespace FilmAPI.WEB.Models
{
    public class HomeViewModel
    {
        public List<FilmDto> Films { get; set; }
        public List<SalonDto> Salons { get; set; }
        public List<Film_SalonDto> Film_Salons { get; set; }
        public FilmDto Film { get; set; }
        public SalonDto Salon { get; set; }
        public Film_SalonDto Film_Salon { get; set; }
    }
}
