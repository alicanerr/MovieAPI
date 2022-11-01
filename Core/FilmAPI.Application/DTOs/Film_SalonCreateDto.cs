using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Application.DTOs
{
    public class Film_SalonCreateDto
    {
        public int GosterimYili { get; set; }

        public int FilmId { get; set; }

        public int SalonId { get; set; }
    }
}
