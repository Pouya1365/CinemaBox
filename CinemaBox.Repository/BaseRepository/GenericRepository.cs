using CinemaBox.Context.AppDbContext;
using CinemaBox.Repository.Interface.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace CinemaBox.Repository.BaseRepository;

public class GenericRepository<T>(CinemaBoxDbContext context) : IGenericRepository<T> where T : class
{
    private readonly CinemaBoxDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity).ConfigureAwait(false);
    public void Attach(T entity) => _dbSet.Attach(entity);
    public void Remove(T entity) => _dbSet.Remove(entity);
    public async Task<T> GetByIdAsync(long id) => await _dbSet.FindAsync(id).ConfigureAwait(false);
    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync().ConfigureAwait(false);
    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        => await _dbSet.Where(predicate).ToListAsync().ConfigureAwait(false);
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        => await _dbSet.AnyAsync(predicate).ConfigureAwait(false);
    public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        => await _dbSet.FirstOrDefaultAsync(predicate).ConfigureAwait(false);
    public async Task AddRangeAsync(List<T> entities) => await _dbSet.AddRangeAsync(entities).ConfigureAwait(false);
    public void Update(T entity) => _dbSet.Update(entity);
    public async Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;
        foreach (var include in includes)        
            query = query.Include(include);   
        return await query.ToListAsync().ConfigureAwait(false);
    }
    public async Task<T> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet.Where(predicate);
        foreach (var include in includes)
            query = query.Include(include);
        return await query.FirstOrDefaultAsync().ConfigureAwait(false);
    }
    public async Task<IEnumerable<T>> GetAllWithPredicateAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet.Where(predicate);
        foreach (var include in includes)        
            query = query.Include(include);       
        return await query.ToListAsync().ConfigureAwait(false);
    }
    // برای Includeهای با چندین سطح
    public async Task<IEnumerable<T>> GetAllWithMultipleIncludesAsync<TProperty, TThenProperty>(
        Expression<Func<T, IEnumerable<TProperty>>> include,
        Expression<Func<TProperty, TThenProperty>> thenInclude)
        where TProperty : class
        where TThenProperty : class
    {
        return await _context.Set<T>()
            .Include(include)
            .ThenInclude(thenInclude)
            .ToListAsync()
            .ConfigureAwait(false);
    }
    public async Task<IEnumerable<T>> GetAllWithMultipleIncludesWithPredicateAsync<TProperty, TThenProperty>(
       Expression<Func<T, bool>> predicate,
       Expression<Func<T, TProperty>> include,
       Expression<Func<TProperty, TThenProperty>> thenInclude)
       where TProperty : class
       where TThenProperty : class
    {
        var query = _dbSet.Where(predicate)
                          .Include(include)
                          .ThenInclude(thenInclude);

        return await query.ToListAsync().ConfigureAwait(false);
    }
    // برای شامل کردن چندین سطح درخواستی
    public async Task<IEnumerable<T>> GetAllWithMultipleIncludesAsync<TProperty1, TProperty2, TProperty3>(
        Expression<Func<T, IEnumerable<TProperty1>>> include1,
        Expression<Func<TProperty1, TProperty2>> thenInclude2,
        Expression<Func<TProperty2, TProperty3>> thenInclude3)
        where TProperty1 : class
        where TProperty2 : class
        where TProperty3 : class
    {
        return await _context.Set<T>()
            .Include(include1)
                .ThenInclude(thenInclude2)
                    .ThenInclude(thenInclude3)
            .ToListAsync()
            .ConfigureAwait(false);
    }
    public async Task<T> GetByIdAsync(string id) => await _dbSet.FindAsync(id).ConfigureAwait(false);
    public async Task<T> GetByIdAsync(byte id) => await _dbSet.FindAsync(id).ConfigureAwait(false);

    public Task<List<T>> GetAllListAsync(Expression<Func<T, bool>> predicate)=> _dbSet.Where(predicate).ToListAsync();

}