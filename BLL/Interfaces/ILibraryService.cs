using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface ILibraryService
    {
        List<LibraryModel> GetAllLibrariesByUserId(int userId);
        /*void DeleteLibrary(int libraryId);
        void UpdateLibrary(LibraryModel library);
        void CreateLibrary(CreateLibraryModel createLibraryModel);*/
    }
}
