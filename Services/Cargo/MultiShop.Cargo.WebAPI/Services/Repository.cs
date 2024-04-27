using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.WebAPI.Context;

namespace MultiShop.Cargo.WebAPI.Services;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly CargoContext _context;

    public Repository(CargoContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task CreateAsync(T Entity)
    {
        _context.Set<T>().AddAsync(Entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().SingleOrDefaultAsync(filter);
    }
}