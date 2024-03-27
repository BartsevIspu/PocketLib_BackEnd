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
using BLL.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/library")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _iLibraryService;
        public LibraryController(ILibraryService iLibraryService)
        {
            _iLibraryService = iLibraryService;
        }

        [HttpGet("userLibraries/{userId}")]
        public IActionResult GetUserLibraries(int userId)
        {
            try 
            { 
                List<LibraryModel> allUserLibraries = _iLibraryService.GetAllLibrariesByUserId(userId);
                
                    return new ObjectResult(allUserLibraries);
               // else return BadRequest(new ErrorResponseModel { Status = 500, Description = "У данного пользователя пустая библиотека!" });                
            }
            catch (Exception e) 
            {
                return BadRequest(new ErrorResponseModel { Status = 500, Description = e.Message });
            }
        }

        [HttpDelete("deleteLibrary/{libraryId}")]
        public IActionResult DeleteLibrary(int libraryId)
        {
            if (ModelState.IsValid)
            {
                _iLibraryService.DeleteLibrary(libraryId);

                var msg = new
                {
                    message = "Позиция библиотеки была удалена"
                };
                return Ok(msg);
            }
            else
            {
                return BadRequest(new ErrorResponseModel { Status = 500, Description = "Неверные входные данные" });
            }
        }
    }
}
