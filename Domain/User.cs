using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Case> Cases { get; set; }
        public ICollection<Log> Logs { get; set; }
    }
}
