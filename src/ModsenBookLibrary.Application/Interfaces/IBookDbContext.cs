using Microsoft.EntityFrameworkCore;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Interfaces;
public interface IBookDbContext
{
    DbSet<Book> Books { get; set; }
    DbSet<BookDistribution> BookDistributions { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<User> Users { get; set; }
}
