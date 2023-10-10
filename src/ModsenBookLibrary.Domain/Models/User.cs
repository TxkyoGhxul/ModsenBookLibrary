using ModsenBookLibrary.Domain.Models.Base;

namespace ModsenBookLibrary.Domain.Models;
public class User : NamedEntity
{
    public List<Role> Roles { get; set; }
}
