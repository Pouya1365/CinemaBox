using CinemaBox.Domain.Entertainment.Collections;
using CinemaBox.Domain.Entertainment.Genres;
using CinemaBox.Model.Statestics;
using CinemaBox.Service.Interface.Entertainment.Collections;
using CinemaBox.UnitOfWork.Interface.UOW;


namespace CinemaBox.Service.Entertainment.Collections;

public class CollectionServices(IUnitOfWork unitOfWork) : ICollectionServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    public async Task<IEnumerable<Collection>> GetAllCollection() => await _unitOfWork.Repository<Collection>().GetAllAsync();
    public async Task<Collection> CreateOrGetCollectoion(string encollectionName,string faCollectionName)
    {
        if (string.IsNullOrWhiteSpace(encollectionName))
            return null;
        Collection? collection = await GetCollectionAsync(collectionName: encollectionName);
        if (collection == null)
        {
            collection = new Collection { EnCollectionName = encollectionName.Trim(),FaCollectionName= faCollectionName.Trim() };
            await _unitOfWork.Repository<Collection>().AddAsync(collection);
            await _unitOfWork.CompleteAsync();
        }
        return collection;
    }
    public async Task<Collection?> GetCollectionAsync(string collectionName)
    {
        if (string.IsNullOrWhiteSpace(collectionName))
            return null;
        return await _unitOfWork.Repository<Collection>()
            .FindAsync(c => c.EnCollectionName == collectionName||c.FaCollectionName==collectionName);
    }

    public async Task<StatesticsModel> GetStatestics(StatesticsModel statesticsModel)
    {
        IEnumerable<Collection> collection =await _unitOfWork.Repository<Collection>().GetAllAsync();
        statesticsModel.CollectionsTotalCount = collection.Count();
        return statesticsModel;
    }
    public async Task<Dictionary<string, int>> GetMovieCountPerCollection()
    {
        IEnumerable<Collection> collections = await _unitOfWork.Repository<Collection>().GetAllWithIncludesAsync(x => x.Movies);
        return collections.Select(c => new
        {
            Name = c.FaCollectionName ?? c.EnCollectionName,
            Value = c.Movies.Count()
        })
          .OrderByDescending(x => x.Value)
          .ToDictionary(x => x.Name, x => x.Value);
    }
}