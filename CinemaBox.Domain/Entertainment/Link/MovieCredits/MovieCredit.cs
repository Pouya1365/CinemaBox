using CinemaBox.Domain.Entertainment.CreditTypes;
using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Person.Peoples;

namespace CinemaBox.Domain.Entertainment.Link.MovieCredits;

public class MovieCredit
{
    public required int MovieId { get; set; }
    public required long PeopleId { get; set; }
    public required byte CreditTypeId { get; set; }
    public bool? IsLead { get; set; }
    public string? CharacterName { get; set; }
    public string? PersianCharacterName { get; set; }
    public int? TmdbCreditId { get; set; }
    public string? ImdbCreditId { get; set; }
    public Movie? Movie { get; set; }
    public People? People { get; set; }
    public CreditType? CreditType { get; set; }
}