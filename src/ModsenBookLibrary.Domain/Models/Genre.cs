using ModsenBookLibrary.Domain.Models.Base;

namespace ModsenBookLibrary.Domain.Models;
public class Genre : NamedEntity
{
    public virtual List<Book> Books { get; set; }

    public Genre()
    {
    }

    public Genre(string name) : this(Guid.NewGuid(), name, new List<Book>())
    {
    }

    public Genre(Guid id, string name, List<Book> books)
    {
        Id = id;
        Name = name;
        Books = books;
    }
}
