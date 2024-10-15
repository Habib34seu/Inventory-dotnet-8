using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.IRepository.Common.Generic;

public interface IRepository<T> where T : class
{
    Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task RemoveAsync(T entity);
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IReadOnlyList<T>> GetAllAsync();
}
