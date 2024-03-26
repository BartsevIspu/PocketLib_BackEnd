using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Configuration
{
    public class LibraryConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.ToTable("library");

            builder.HasKey(x => x.Id);

           // builder.Property(e => e.Id).UseMySqlIdentityColumn();
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            // builder.Property(e => e.Id).ValueGeneratedOnAddOrUpdate();


            builder.HasIndex(e => e.UserId, "user_idx");

            builder.HasIndex(e => e.BookId, "book_idx");

            builder.Property(e => e.UserRating).HasPrecision(8, 2);

            builder.HasOne(d => d.Book)
                .WithMany(p => p.Libraries)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("bookIdx");

            builder.HasOne(d => d.User)
                .WithMany(p => p.Libraries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("userId");

            builder.HasData(
               new Library
               {
                   Id = 1,
                   UserRating = 1,
                   Pages = 0,
                   BookId = 1,
                   UserId = 1,
               });
        }
    }
}
