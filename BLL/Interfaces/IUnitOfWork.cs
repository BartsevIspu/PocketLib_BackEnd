using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Interfaces;

namespace BLL.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Book> BookRepository { get; }
        IGenericRepository<Genre> GenreRepository { get; }
        IGenericRepository<Library> LibraryRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        Task Save();
    }
}
