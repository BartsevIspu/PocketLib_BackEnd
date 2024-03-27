using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Data;

namespace BLL.Models
{
    public class LibraryModel
    {
        public int Id { get; set; }
        public decimal UserRating { get; set; }
        public int Pages { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string GenreName { get; set; }
        public LibraryModel() { }

        public LibraryModel(Library b, IUnitOfWork dataBase)
        {
            Id = b.Id;
            UserRating = b.UserRating;
            Pages = b.Pages;
            UserId = b.UserId;
            BookId = b.BookId;
            var book = dataBase.BookRepository.Get(b.BookId);
            if (book != null)
            {
                BookName = book.Name;
                var genre = dataBase.GenreRepository.Get(book.GenreId);
                if (genre != null)
                {
                    GenreName = genre.Name;
                }
            }

        }
    }
}
