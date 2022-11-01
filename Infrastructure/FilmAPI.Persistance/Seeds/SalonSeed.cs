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
    public class SalonSeed : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
            builder.HasData(new Salon { Id = 1, SalonAd = "A"},
                            new Salon { Id = 2, SalonAd = "B" },
                            new Salon { Id = 3, SalonAd = "C" });
        }
    }
}
