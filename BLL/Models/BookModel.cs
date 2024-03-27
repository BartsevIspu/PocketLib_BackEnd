using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Data;

namespace BLL.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public bool Prescence { get; set; }
        public string Consistance { get; set; } = null!;
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string? Photo { get; set; }
        public BookModel() { } 

        public BookModel(Book p, IUnitOfWork dataBase)
        {
            Id = p.Id;
            Name = p.Name;
            Price = p.Price;
            Description = p.Description;
            Consistance = p.Consistance;
            GenreId = p.GenreId;
            Photo = p.Photo;
            var genre = dataBase.GenreRepository.Get(GenreId);
            GenreName = genre.Name;
        }
    }
}
