using ModsenBookLibrary.Domain.Models.Base;

namespace ModsenBookLibrary.Domain.Models;
public class Genre : NamedEntity
{
    public List<Book> Books { get; set; }
}
