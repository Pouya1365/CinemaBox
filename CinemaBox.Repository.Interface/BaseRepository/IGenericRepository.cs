using System.Collections.Generic;
using System.Linq.Expressions;

namespace CinemaBox.Repository.Interface.BaseRepository;

public interface IGenericRepository<T> where T : class
{
    Task AddAsync(T entity);
    void Attach(T entity);
    void Remove(T entity);
    Task<T> GetByIdAsync(long id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    Task<T> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddRangeAsync(List<T> entities);
    void Update(T entity);
    Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetAllWithPredicateAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetAllWithMultipleIncludesAsync<TProperty, TThenProperty>(
         Expression<Func<T, IEnumerable<TProperty>>> include,
         Expression<Func<TProperty, TThenProperty>> thenInclude)
         where TProperty : class
         where TThenProperty : class;
    // برای شامل کردن چندین سطح درخواستی
    Task<IEnumerable<T>> GetAllWithMultipleIncludesAsync<TProperty1, TProperty2, TProperty3>(
         Expression<Func<T, IEnumerable<TProperty1>>> include1,
         Expression<Func<TProperty1, TProperty2>> thenInclude2,
         Expression<Func<TProperty2, TProperty3>> thenInclude3)
         where TProperty1 : class
         where TProperty2 : class
         where TProperty3 : class;
    Task<T> GetByIdAsync(string id);
    Task<T> GetByIdAsync(byte id);
    Task<IEnumerable<T>> GetAllWithMultipleIncludesWithPredicateAsync<TProperty, TThenProperty>(
          Expression<Func<T, bool>> predicate,
          Expression<Func<T, TProperty>> include,
          Expression<Func<TProperty, TThenProperty>> thenInclude)
          where TProperty : class
          where TThenProperty : class;
    Task<T> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
}
