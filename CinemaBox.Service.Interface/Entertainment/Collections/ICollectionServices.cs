using CinemaBox.Domain.Entertainment.Collections;

namespace CinemaBox.Service.Interface.Entertainment.Collections;

public interface ICollectionServices
{
    Task<IEnumerable<Collection>> GetAllCollection();
    Task<Collection?> GetCollectionAsync(string collectionName);
    Task<Collection> CreateOrGetCollectoion(string encollectionName, string faCollectionName);
}
