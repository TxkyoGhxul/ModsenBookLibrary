using Microsoft.EntityFrameworkCore;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Queries.BookQueries.GetSingle;
using ModsenBookLibrary.Domain.Models;
using System.Reflection;

namespace ModsenBookLibrary.Infrastructure.Data;
public class BookDbContext : DbContext, IBookDbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<BookDistribution> BookDistributions { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
