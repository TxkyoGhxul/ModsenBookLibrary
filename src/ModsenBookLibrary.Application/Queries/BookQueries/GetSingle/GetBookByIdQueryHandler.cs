using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Exceptions;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Queries.BookQueries.GetSingle;

internal class GetBookByIdQueryHandler : BaseQueryHandler<Book>, ISingleQueryHandler<GetBookByIdQuery, Book>
{
    public GetBookByIdQueryHandler(IRepository<Book> repository) : base(repository)
    {
    }

    public async Task<Result<Book>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (book == null)
        {
            return new EntityNotFoundException(request.Id, typeof(Book));
        }

        return book;
    }
}
