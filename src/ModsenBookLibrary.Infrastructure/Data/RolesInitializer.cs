using ModsenBookLibrary.Domain.Constants;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Infrastructure.Data;

public class RolesInitializer
{
    private readonly BookDbContext _context;

    public RolesInitializer(BookDbContext context)
    {
        _context = context;
    }

    public void InitializeRoles()
    {
        var hasRoles = _context.Roles.Any();
        if (hasRoles)
        {
            return;
        }

        var user = new Role(Roles.User);
        var admin = new Role(Roles.Admin);
        var author = new Role(Roles.Author);

        _context.Roles.Add(user);
        _context.Roles.Add(admin);
        _context.Roles.Add(author);

        _context.SaveChanges();
    }
}
