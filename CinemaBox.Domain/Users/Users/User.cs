using CinemaBox.Domain.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBox.Domain.Users.Users
{
    public class User:PersistentObject<string>
    {
        public required string Password { get; set; }
    }
}
