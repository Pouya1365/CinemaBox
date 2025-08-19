using TvMaze.Api.Client.Models;

namespace CinemaBox.TvMaz.Interfaces.TvMaz;

public interface ITvMazServices
{
    Task<IEnumerable<Episode>> IsTvSchedule();
}
