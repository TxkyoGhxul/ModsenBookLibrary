using ModsenBookLibrary.Domain.Models.Base;

namespace ModsenBookLibrary.Domain.Models;
public class Role : NamedEntity
{
    public List<User> Users { get; set; }
}
