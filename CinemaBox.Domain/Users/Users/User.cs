using CinemaBox.Domain.Managment.Link.UserMovieAudios;
using CinemaBox.Domain.Managment.Link.UserMovieDisks;
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
        public ICollection<UserMovieDisk> UserMovieDisks { get; set; } = [];
        public ICollection<UserMovieAudio> UserMovieAudios { get; set; } = [];
    }
}
