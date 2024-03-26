using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public partial class Book
    {
        public Book()
        {
            Libraries = new HashSet<Library>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; } = null!;
        public string Consistance { get; set; } = null!;
        public int GenreId { get; set; } 
        public string? Photo { get; set; }

       
        public virtual Genre Genre { get; set; } = null!;
        public virtual ICollection<Library>? Libraries { get; set; }


    }
}
