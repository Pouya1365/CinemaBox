using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Person.PeopleFiles;
using CinemaBox.Domain.Shared.DeathCauses;

namespace CinemaBox.Domain.Person.Peoples;

public class People : PersistentObject<string>
{
    public required string EnFullName { get; set; }
    public string? FaFullName { get; set; }
    public DateOnly? BornDate { get; set; }
    public DateOnly? DeathDate { get; set; }
    public string? BornPlace { get; set; }
    public string? DeathPlace { get; set; }
    public string? BirthName { get; set; }
    public string? NickName { get; set; }
    public string? Height { get; set; }
    public string? EnMiniBiography { get; set; }
    public string? FaMiniBiography { get; set; }
    public int? DeathCauseId { get; set; }
    public required DateOnly AddedDate { get; set; }
    public required DateOnly UpdatedDate { get; set; }
    public DeathCause? DeathCause { get; set; }
    public ICollection<PeopleFile> PeopleFiles { get; set; } = [];
    public ICollection<MovieCredit> MovieCredits { get; set; } = [];
}