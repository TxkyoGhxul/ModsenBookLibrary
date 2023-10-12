using ModsenBookLibrary.Application.Extensions;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Application.Sorters.Base;
using ModsenBookLibrary.Application.Sorters.Fields;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Queries.BookQueries.GetRange;

internal class GetAllBooksQueryHandler : BaseQueryHandler<Book>, IQueryHandler<GetAllBooksQuery, Book>
{
    private readonly ISorter<Book, BookSortField> _sorter;

    public GetAllBooksQueryHandler(ISorter<Book, BookSortField> sorter, IRepository<Book> repository) : base(repository)
    {
        _sorter = sorter;
    }

    public async Task<Result<PagedList<Book>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = _repository.GetAll();

        if (!string.IsNullOrWhiteSpace(request.SearchText))
        {
            books = Filter(books, request.SearchText);
        }

        books = _sorter.Sort(books, request.Field, request.Ascending);

        return await books.ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);
    }

    private IQueryable<Book> Filter(IQueryable<Book> books, string searchText)
    {
        return books.Where(b => b.Name.Contains(searchText));
    }
}