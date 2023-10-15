using System.Linq.Expressions;
using Core.entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly NotiContext _context;
    public GenericRepository(NotiContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public virtual async Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(
        int pageIndex,
        int pageSize,
        string _search
    )
    {
        var totalRegistros = await _context.Set<T>().CountAsync();
        var registros = await _context.Set<T>().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

        return (totalRegistros, registros);
    }
}