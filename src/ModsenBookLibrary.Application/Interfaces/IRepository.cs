using ModsenBookLibrary.Domain.Models.Base;
using System.Linq.Expressions;

namespace ModsenBookLibrary.Application.Interfaces;
public interface IRepository<T> where T : IEntity, new()
{
    IQueryable<T> GetAll();
    IQueryable<T> Get(Expression<Func<T, bool>> expression);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}
