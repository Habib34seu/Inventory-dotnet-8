using FluentResults;
using System.Linq.Expressions;


namespace ERP.Application.IService.Common.Generic;

public interface IService<T> where T : class
{
    Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate);
    Task<Result<T>> AddAsync(T entity);
    Task<Result<T>> UpdateAsync(T entity);
    Task<Result> DeleteAsync(T entity);
    Task<Result> DeleteByIdAsync(int id);
    Task RemoveAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> GetAllAsync();
}
