using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book");

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasIndex(e => e.GenreId, "genre_idx");

            builder.Property(e => e.Name).HasMaxLength(50);
            
            builder.Property(e => e.Price).HasPrecision(8, 2);

            builder.Property(e => e.Rating).HasPrecision(8, 2);

            builder.Property(e => e.Description).HasMaxLength(256);
            
            builder.Property(e => e.Consistance).HasMaxLength(256);
            
            builder.Property(e => e.Photo).HasMaxLength(256);

            builder.HasOne(e => e.Genre)
                .WithMany(p => p.Books)
                .HasForeignKey(p => p.GenreId)
                .HasConstraintName("userFK");

            builder.HasData(
                new Book
                {
                    Id = 1,
                    Name = "Название книги 1",
                    Price = 770,
                    Rating = 5,
                    Description = "Описание книги 1",
                    Consistance = "Содержание 1",                    
                    GenreId = 1,
                    Photo = "https://w7.pngwing.com/pngs/571/549/png-transparent-california-roll-sushi-canape-platter-garnish-hot-roll-thumbnail.png"
                },
                new Book
                {
                    Id = 2,
                    Name = "Название книги 2",
                    Price = 990,
                    Rating = 5,
                    Description = "Описание книги 2",
                    Consistance = "Содержание ",
                    GenreId = 2,
                    Photo = "https://w7.pngwing.com/pngs/964/36/png-transparent-california-roll-makizushi-sushi-tempura-philadelphia-sushi-rolls-food-recipe-sashimi-thumbnail.png"
                },
                new Book
                {
                    Id = 3,
                    Name = "Название книги 3",
                    Price = 612,
                    Rating = 5,
                    Description = "Описание книги 3",
                    Consistance = "Содержание ",
                    GenreId = 1,
                    Photo = "https://w7.pngwing.com/pngs/193/635/png-transparent-makizushi-sushi-smoked-salmon-california-roll-pizza-sushi-thumbnail.png"
                },
                new Book
                {
                    Id = 4,
                    Name = "Название книги 4",
                    Price = 562,
                    Rating = 5,
                    Description = "Описание книги 4",
                    Consistance = "Содержание ",
                    GenreId = 2,
                    Photo = "https://w7.pngwing.com/pngs/571/549/png-transparent-california-roll-sushi-canape-platter-garnish-hot-roll-thumbnail.png"
                }
                );
        }

    }
}
