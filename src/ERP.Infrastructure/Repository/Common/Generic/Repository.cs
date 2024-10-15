using ERP.Infrastructure.DataContext;
using ERP.Infrastructure.IRepository.Common.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Linq.Expressions;

namespace ERP.Infrastructure.Repository.Common.Generic;

public class Repository<T> (ApplicationDbContext _context): IRepository<T> where T : class
{
    public async Task<T> AddAsync(T entity)
    {
        try
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch(Exception ex) {
            throw new Exception(ex.Message);
        }
    }

    public async Task<T> UpdateAsync(T entity)
    {
        try
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task DeleteAsync(T entity)
    {
        try
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
        }
        catch (DbException ex) {
            throw ex;
        }
    }

    public async Task RemoveAsync(T entity)
    {
        try
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        catch (DbException ex)
        {
            throw ex;
        }
        catch (Exception ex) {
            throw ex;
        }
        
    }
    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
    {
        try
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        catch (DbException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    public async Task<T> GetByIdAsync(int id)
    {
        try
        {
            return await _context.Set<T>().FindAsync(id);
        }
        catch (DbException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
 
   
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        try
        {
            return await _context.Set<T>().ToListAsync();
        }
        catch (DbException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> predicate)
    {
        try
        {
            var entity = await _context.Set<T>().Where(predicate).ToListAsync();
            if (entity == null || entity.Count < 1) return false;
            return true;
        }
        catch (DbException ex)
        {
            throw ex;
        }
        
    }

    
    
}
