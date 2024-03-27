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
using Microsoft.Extensions.Logging;

namespace BLL.Services
{
    public class LibraryService : ILibraryService
    {
        IUnitOfWork dataBase;

        public LibraryService(IUnitOfWork repos)
        {
            dataBase = repos;
        }

        public List<LibraryModel> GetAllLibrariesByUserId(int userId)
        {
            return dataBase.LibraryRepository.GetAll()
                                            .Select(i => new LibraryModel(i,dataBase))
                                            .Where(i => i.UserId == userId)
                                            .OrderBy(i => i.BookName)
                                            .ToList();
        }

        /*public void DeleteLibrary(int libraryId)
        {
            var library = dataBase.LibraryRepository.Get(libraryId);
            if (library != null)
            {
                dataBase.LibraryRepository.Delete(library.Id);
                Save();
            }
        }

        public void UpdateLibrary(LibraryModel library)
        {
            var libraryToChange = dataBase.LibraryRepository.Get(library.Id);
            var pizza = dataBase.BookRepository.Get(library.BookId);
            if (pizza != null && libraryToChange != null)
            {
                //library.ViewPrice = $"{library.Library_Price:0.#} руб.";
                dataBase.LibraryRepository.Update(libraryToChange);
                Save();
            }
        }*/

        //public void CreateLibrary(CreateLibraryModel createLibraryModel)
        //{
            /*var user = dataBase.UserRepository.Get(createLibraryModel.UserId);
            var library = dataBase.LibraryRepository.GetAll().Where(i => i.UserId == createLibraryModel.UserId).Where(i => i.BookId == createLibraryModel.BookId).FirstOrDefault();
            if (user != null && pizza != null)
            {
                if (library != null)
                {
                    library.Amount++;
                    library.Price += pizza.Price;
                    dataBase.LibraryRepository.Update(library);
                }
                else { dataBase.LibraryRepository.Create(new Library { BookId = pizza.Id, UserId = user.Id, Book = pizza, User = user}); }
                Save();
            }*/
        //}

        public bool Save()
        {
            dataBase.Save();
            return true;
        }
    }
}
