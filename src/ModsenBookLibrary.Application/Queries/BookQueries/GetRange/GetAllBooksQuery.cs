using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Sorters.Fields;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Queries.BookQueries.GetRange;
public record GetAllBooksQuery(
    string SearchText,
    BookSortField Field,
    bool Ascending,
    int PageNumber,
    int PageSize) : IQuery<Book>;
