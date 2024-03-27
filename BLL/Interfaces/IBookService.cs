using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IBookService
    {
        List<BookModel> GetAllBooks();
        List<BookModel> GetBooksByName(string name);
        BookModel GetBookById(int id);

    }
}
