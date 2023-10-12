using ModsenBookLibrary.Application.Interfaces;

namespace ModsenBookLibrary.Infrastructure.Data;
public class UnitOfWork : IUnitOfWork
{
    private readonly BookDbContext _context;

    public UnitOfWork(BookDbContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
