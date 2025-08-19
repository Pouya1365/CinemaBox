using CinemaBox.TvMaz.Interfaces.TvMaz;
using TvMaze.Api.Client;
using TvMaze.Api.Client.Models;

namespace CinemaBox.TvMaz.TvMaz;

public class TvMazServices: ITvMazServices
{
    public async Task<IEnumerable<Episode>> IsTvSchedule()
    {
        TvMazeClient client = new();
        IEnumerable<Episode> episodesSchedule =await client.Schedule.GetFullSchedule();
        return episodesSchedule;
    }
}
