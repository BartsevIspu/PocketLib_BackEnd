using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CreateLibraryModel
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public CreateLibraryModel() { }

        public CreateLibraryModel(int userId, int bookId)
        {
            UserId = userId;
            BookId = bookId;
        }
    }
}
