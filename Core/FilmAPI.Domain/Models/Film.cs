using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Domain.Models
{
    public class Film : BaseEntity
    {
        public string FilmAd { get; set; }
        public int FilmYapimYil { get; set; }
        public ICollection<Film_Salon> Film_Salon { get; set; }
        //public int? Film_SalonId { get; set; }

    }
}
