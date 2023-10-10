using Microsoft.EntityFrameworkCore;
using ModsenBookLibrary.Application.Commands;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Exceptions;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Queries.BookQueries.GetSingle;

internal class GetBookByISBNQueryHanlder : BaseCommandHandler<Book>, ISingleQueryHandler<GetBookByISBNQuery, Book>
{
    public GetBookByISBNQueryHanlder(IRepository<Book> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<Result<Book>> Handle(GetBookByISBNQuery request, CancellationToken cancellationToken)
    {
        var book = await _repository.Get(b => b.ISBN == request.ISBN).FirstOrDefaultAsync(cancellationToken);
        if (book == null)
        {
            return new EntityNotFoundException($"Book with ISBN: {request.ISBN} is not found");
        }

        return book;
    }
}
