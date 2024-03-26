using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre> 
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre");

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasData(
                new Genre
                {
                    Id = 1,
                    Name = "Детектив"
                },
                new Genre
                {
                    Id = 2,
                    Name = "Фэнтези"
                }
                );
        }
    }
}
