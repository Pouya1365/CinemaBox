using CinemaBox.Repository.Interface.BaseRepository;

namespace CinemaBox.UnitOfWork.Interface.UOW;

public interface IUnitOfWork
{
    IGenericRepository<T> Repository<T>() where T : class;
     Task<int> CompleteAsync();
    void Dispose();
}
