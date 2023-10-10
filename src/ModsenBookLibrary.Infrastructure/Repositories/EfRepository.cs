using Microsoft.EntityFrameworkCore;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models.Base;
using ModsenBookLibrary.Infrastructure.Data;
using System.Linq.Expressions;

namespace ModsenBookLibrary.Infrastructure.Repositories;
internal class EfRepository<T> : IRepository<T> where T : Entity, new()
{
    private readonly BookDbContext _context;

    public EfRepository(BookDbContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> Get(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().Where(entity => entity.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}
