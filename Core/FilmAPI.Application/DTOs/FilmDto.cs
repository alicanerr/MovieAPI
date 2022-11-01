using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Application.DTOs
{
    public class FilmDto :BaseDto
    {
        public string FilmAd { get; set; }
        public int FilmYapimYil { get; set; }
    }
}
