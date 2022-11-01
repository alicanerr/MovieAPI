using FilmAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Persistance.Seeds
{
    public class Film_SalonSeed : IEntityTypeConfiguration<Film_Salon>
    {
        public void Configure(EntityTypeBuilder<Film_Salon> builder)
        {
            builder.HasData(new Film_Salon { Id = 1, FilmId=1,SalonId=1,GosterimYili=2014},
                            new Film_Salon { Id = 2, FilmId=1,SalonId=2,GosterimYili=2014},
                            new Film_Salon { Id = 3, FilmId=1,SalonId=3,GosterimYili=2015},
                            new Film_Salon { Id = 4, FilmId=2,SalonId=1,GosterimYili=2016},
                            new Film_Salon { Id = 5, FilmId=3,SalonId=3,GosterimYili=2020},
                            new Film_Salon { Id = 6, FilmId=3,SalonId=2,GosterimYili=2020},
                            new Film_Salon { Id = 7, FilmId=3,SalonId=3,GosterimYili=2020});
        }
    }
}
