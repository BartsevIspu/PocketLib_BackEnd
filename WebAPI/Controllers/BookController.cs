using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BLL.Models;
using BLL.Interfaces;
using BLL;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _iBookService;
        public BookController(IBookService iBookService)
        {
            _iBookService = iBookService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                List<BookModel> allBooks = _iBookService.GetAllBooks();
                if (allBooks.Count != 0)
                    return new ObjectResult(allBooks);
                else return BadRequest(new ErrorResponseModel { Status = 500, Description = "Список книг получить не удалось!" });
            }
            catch (Exception e) 
            {
                return BadRequest(new ErrorResponseModel { Status = 500, Description = e.Message });
            }
        }

        [HttpGet("byname/{name}")]
        public IActionResult GetBooksWithName(string name)
        {
            try
            {
                List<BookModel> Book = _iBookService.GetBooksByName(name);
                if (Book.Count != 0)
                    return new ObjectResult(Book);
                else return BadRequest(new ErrorResponseModel { Status = 500, Description = "При получении книг с таким именем произошла ошибка" });
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResponseModel { Status = 500, Description=e.Message });
            }
        }
    }
}
