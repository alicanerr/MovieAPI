using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Domain.Models
{
    public class Film_Salon : BaseEntity
    {
        public int GosterimYili { get; set; }
        public Film Film { get; set; }
        public int FilmId { get; set; }
        public Salon Salon { get; set; }
        public int SalonId { get; set; }
    }
}
