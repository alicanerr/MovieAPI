using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Domain.Models
{
    public class Salon : BaseEntity
    {
        public string SalonAd { get; set; }
        public ICollection<Film_Salon> Film_Salon { get; set; }
        //public int? Film_SalonId { get; set; }
    }
}
