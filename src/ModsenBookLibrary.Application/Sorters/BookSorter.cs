using ModsenBookLibrary.Application.Sorters.Base;
using ModsenBookLibrary.Application.Sorters.Fields;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Sorters;
internal class BookSorter : ISorter<Book, BookSortField>
{
    public IQueryable<Book> Sort(IQueryable<Book> models, BookSortField field, bool ascending)
    {
        return field switch
        {
            BookSortField.None => models,
            BookSortField.Name => ascending ? models.OrderBy(x => x.Name) : models.OrderByDescending(x => x.Name),
            _ => models
        };
    }
}
