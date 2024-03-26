
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public partial class Library
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal UserRating { get; set; }
        public int Pages { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; } = null!;
        public virtual User User { get; set; } = null!;

    }
}
