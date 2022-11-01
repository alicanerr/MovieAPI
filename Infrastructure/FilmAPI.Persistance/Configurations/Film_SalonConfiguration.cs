using FilmAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAPI.Persistance.Configurations
{
    public class Film_SalonConfiguration : IEntityTypeConfiguration<Film_Salon>
    {
        public void Configure(EntityTypeBuilder<Film_Salon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Film).WithMany(x => x.Film_Salon).HasForeignKey(x => x.FilmId);
            builder.HasOne(x => x.Salon).WithMany(x => x.Film_Salon).HasForeignKey(x => x.SalonId);
        }
    }
}
