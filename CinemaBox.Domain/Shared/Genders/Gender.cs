using CinemaBox.Domain.Persistent;
namespace CinemaBox.Domain.Shared.Genders;
public class Gender:PersistentObject<byte>
{
    public required string Name { get; set; }
    public  string PersianName { get; set; }
}
