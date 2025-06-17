using CinemaBox.Context.AppDbContext;
using CinemaBox.Repository.BaseRepository;
using CinemaBox.Repository.Interface.BaseRepository;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.UnitOfWork.UOW;

public class UnitOfWork(CinemaBoxDbContext context) : IUnitOfWork
{
    private readonly Dictionary<Type, object> _repositories = [];
    /// <summary>
    /// بازگرداندن ریپازیتوری جنریک برای موجودیت مشخص‌شده
    /// </summary>
    public IGenericRepository<T> Repository<T>() where T : class
    {
        if (_repositories.TryGetValue(typeof(T), out object? repo))        
            return (IGenericRepository<T>)repo;
        GenericRepository<T> newRepo = new(context);
        _repositories[typeof(T)] = newRepo;
        return newRepo;
    }

    /// <summary>
    /// ذخیره تغییرات به صورت async
    /// </summary>
    public async Task<int> CompleteAsync()
    {
        try
        {
            return await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // TODO: اضافه‌کردن لاگ مناسب
            throw new Exception("خطا در هنگام ذخیره تغییرات", ex);
        }
    }

    /// <summary>
    /// آزادسازی منابع
    /// </summary>
    public void Dispose()=>
        context.Dispose();
}
