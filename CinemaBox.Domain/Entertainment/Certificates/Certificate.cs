using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Entertainment.Certificates;

public class Certificate : PersistentObject<byte>
{
    public required string CertificateName { get; set; }
    public ICollection<Movie> Movies { get; set; } = [];
}
