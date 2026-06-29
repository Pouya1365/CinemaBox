using CinemaBox.Domain.Entertainment.Collections;
using CinemaBox.Model.Statestics;

namespace CinemaBox.Service.Interface.Entertainment.Collections;

public interface ICollectionServices
{
    Task<IEnumerable<Collection>> GetAllCollection();
    Task<Collection?> GetCollectionAsync(string collectionName);
    Task<Collection> CreateOrGetCollectoion(string encollectionName, string faCollectionName, int? countCollection, int? totalCount);
    Task<StatesticsModel> GetStatestics(StatesticsModel statesticsModel);
    Task<Dictionary<string, int>> GetMovieCountPerCollection();
    Task UpdateCountCollection(int? collectionId);
}
