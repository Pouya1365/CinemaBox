using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Shared.Currencies;
using CinemaBox.Domain.Shared.Statuses;
using CinemaBox.Domain.UserManager.Users;
namespace CinemaBox.Domain.Managment.Link.UserMovieDisks;
public class UserMovieDisk : PersistentObject<int>
{
    // ===== Foreign Keys =====
    public required int UserId { get; set; }
    public required Guid MovieId { get; set; }
    // ===== Disk Type & Format =====
    public string? Edition { get; set; } // "Collector's Edition", "Steelbook", "Limited"
    // ===== Storage Location =====
    public string? PhysicalLocation { get; set; } // "Shelf A-3", "Box 12"
    public string? StorageBox { get; set; }
    public int? ShelfNumber { get; set; }
    public int? PositionInShelf { get; set; }
    // ===== Metadata =====
    public string? Notes { get; set; }
    public bool IsFavorite { get; set; }
    public bool IsForSale { get; set; }
    public decimal? AskingPrice { get; set; }
    public bool? Subtitles { get; set; }
    public bool? Dubbed { get; set; }
    public bool IsWishlist { get; set; } // برای دیسک‌هایی که میخواد بخره
    // ===== Tracking =====
    public required byte StatusId { get; set; }
    public DateTime? AcquiredAt { get; set; }
    public DateTime? LastVerifiedAt { get; set; } // آخرین بار که وجود فیزیکی تایید شد
    public int ViewCount { get; set; }
    public DateTime? LastViewedAt { get; set; }

    // ===== Navigation Properties =====
    public Movie? Movie { get; set; }
    public Currency? Currency { get; set; }
     public User? User { get; set; }
     public Status? Status { get; set; }
}