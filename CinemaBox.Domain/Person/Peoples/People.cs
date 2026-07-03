using CinemaBox.Domain.Entertainment.Link.MovieCredits;
using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Shared.DeathCauses;
using CinemaBox.Domain.Shared.Genders;

namespace CinemaBox.Domain.Person.Peoples;

public class People : PersistentObject<long>
{
    public required string FullName { get; set; }
    public string? PersianFullName { get; set; }
    public DateOnly? BornDate { get; set; }
    public DateOnly? DeathDate { get; set; }
    public string? BornPlace { get; set; }
    public string? DeathPlace { get; set; }
    public string? BirthName { get; set; }
    public string? NickName { get; set; }
    public string? Height { get; set; }
    public string? MiniBiography { get; set; }
    public string? PersianMiniBiography { get; set; }
    public int? DeathCauseId { get; set; }
    public string? ImdbId { get; set; }
    public int? TmdbId { get; set; }
    // ===== Demographics =====
    public byte? GenderId { get; set; }

    // ===== Physical Characteristics =====
    public short? HeightCm { get; set; }
    public string? EyeColor { get; set; }
    public string? HairColor { get; set; }
    // ===== Statistics (Denormalized) =====
    public int TotalMovies { get; set; }
    public int TotalAwards { get; set; }
    public decimal? AverageRating { get; set; }
    // ===== Metadata =====
    public int ViewCount { get; set; }
    public DateTime? LastViewedAt { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public  long? PictureFileId { get; set; }
    // ===== Navigation Properties =====
    public Gender? Gender { get; set; }
    public DeathCause? DeathCause { get; set; }
    public ICollection<MovieCredit> MovieCredits { get; set; } = [];
}