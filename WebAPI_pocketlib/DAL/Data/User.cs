using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public partial class User
    {
        public User() 
        {
            Libraries = new HashSet<Library>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string? Passport { get; set; }
        public int? Bonuses { get; set; }
        public string Role { get; set; }
        public sbyte IsApproved { get; set; }
        public string? RefreshToken { get; set; }

        public virtual ICollection<Library>? Libraries { get; set; }
    }
}
