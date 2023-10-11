using ModsenBookLibrary.Domain.Models.Base;
using ModsenBookLibrary.Domain.Primitives;

namespace ModsenBookLibrary.Domain.Models;
public class User : NamedEntity
{
    public Email Email { get; set; }

    public string Password { get; set; }

    public virtual List<Role> Roles { get; set; }

    public virtual List<Book> Books { get; set; }

    public User()
    {
    }

    public User(string name, Email email, string password)
         : this(Guid.NewGuid(), name, email, password, new List<Role>(), new List<Book>())
    {
    }

    public User(Guid id, string name, Email email, string password, List<Role> roles, List<Book> books)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        Roles = roles;
        Books = books;
    }
}
