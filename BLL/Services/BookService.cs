using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Data;
using BLL.Models;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using MimeKit;
using MailKit.Net.Smtp;
using Newtonsoft.Json;

namespace BLL.Services
{
    public class BookService : IBookService
    {
        IUnitOfWork dataBase;

        public BookService(IUnitOfWork repos)
        {
            dataBase = repos;
        }

        public List<BookModel> GetAllBooks()
        {
            return dataBase.BookRepository.GetAll()
                                           .Select(i => new BookModel(i, dataBase))
                                           .OrderBy(i => i.Name)
                                           .ToList();
        }

        public List<BookModel> GetBooksByName(string name)
        {
            return dataBase.BookRepository.GetAll()
                                           .Select(i => new BookModel(i, dataBase))
                                           .Where(i => i.Name == name)
                                           .ToList();
        }
        public BookModel GetBookById(int id)
        {
            //return dataBase.BookRepository.Get(id);
            /*var book = dataBase.BookRepository.Get(id);
            if (book != null)
            {
                return new BookModel(book);
            }
            else return null;*/
            return null;
        }

        public bool Save()
        {
            dataBase.Save();
            return true;
        }
    }
}
