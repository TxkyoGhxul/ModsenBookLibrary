using ModsenBookLibrary.Domain.Models.Base;
using ModsenBookLibrary.Domain.Primitives;

namespace ModsenBookLibrary.Domain.Models;
public class Book : NamedEntity
{
    public string Description { get; set; }
    public ISBN ISBN { get; set; }
    public List<Genre> Genres { get; set; }
    public List<User> Authors { get; set; }
    public List<BookDistribution> BookDistributions { get; set; }

    public Book() //EF needed
    {
    }

    public Book(string name, string description, ISBN iSBN, List<Genre> genres, List<User> authors)
        : this(Guid.NewGuid(), name, description, iSBN, genres, authors, new List<BookDistribution>())
    {
    }

    public Book(Guid id, string name, string description, ISBN iSBN, List<Genre> genres, List<User> authors, List<BookDistribution> bookDistributions)
    {
        Id = id;
        Name = name;
        Description = description;
        ISBN = iSBN;
        Genres = genres;
        Authors = authors;
        BookDistributions = bookDistributions;
    }
}
