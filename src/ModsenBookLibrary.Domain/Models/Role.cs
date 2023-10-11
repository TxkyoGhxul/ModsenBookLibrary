using ModsenBookLibrary.Domain.Models.Base;

namespace ModsenBookLibrary.Domain.Models;
public class Role : NamedEntity
{
    public virtual List<User> Users { get; set; }

    public Role()
    {
    }

    public Role(string name) : this(Guid.NewGuid(), name, new List<User>())
    {
    }

    public Role(Guid id, string name, List<User> users)
    {
        Id = id;
        Name = name;
        Users = users;
    }
}
