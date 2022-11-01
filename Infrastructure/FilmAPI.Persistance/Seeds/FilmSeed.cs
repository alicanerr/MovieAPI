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
    public class FilmSeed : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasData(new Film { Id = 1, FilmAd = "Interstellar", FilmYapimYil = 2014 },
                            new Film { Id = 2, FilmAd = "Passangers", FilmYapimYil = 2016 },
                            new Film { Id = 3, FilmAd = "Tenet", FilmYapimYil = 2020 });
        }
    }
}
