using CinemaBox.Domain.Persistent;
namespace CinemaBox.Domain.Shared.Codecs;
public class Codec : PersistentObject<byte>
{
    public required string Name { get; set; }
}
