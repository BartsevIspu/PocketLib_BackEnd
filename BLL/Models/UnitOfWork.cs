using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Data;
using DAL.Interfaces;
using DAL.Repository;

namespace BLL.Models
{
    public class UnitOfWork : BLL.Interfaces.IUnitOfWork
    {
        private readonly BookContext _context;
        private IGenericRepository<Book> _bookRep;
        private IGenericRepository<Genre> _genreRep;
        private IGenericRepository<Library> _libraryRep;
        private IGenericRepository<User> _userRep;

        public UnitOfWork()
        {
            _context = new BookContext();
        }
        public IGenericRepository<Book> BookRepository => _bookRep ??= new GenericRepository<Book>(_context);
        public IGenericRepository<Genre> GenreRepository => _genreRep ??= new GenericRepository<Genre>(_context);
        public IGenericRepository<Library> LibraryRepository => _libraryRep ??= new GenericRepository<Library>(_context);
        public IGenericRepository<User> UserRepository => _userRep ??= new GenericRepository<User>(_context);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
