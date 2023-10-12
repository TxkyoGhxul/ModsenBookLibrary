using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Enums;
using ModsenBookLibrary.Domain.Exceptions;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.BookDistributionCommands.Update;

internal class ReturnBookCommandHandler : BaseCommandHandler<Book>, IUpdateCommandHandler<ReturnBookCommand, Book>
{
    public ReturnBookCommandHandler(IRepository<Book> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<Result<Book>> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.BookId, cancellationToken);
        if (book == null)
        {
            return new EntityNotFoundException(request.BookId, typeof(Book));
        }

        var returned = book.BookDistributions.LastOrDefault()?.Status == BookDistributionStatus.Returned;
        if (returned)
        {
            return new InvalidOperationException("Can not return the book");
        }

        book.BookDistributions[^1].ReturnBook();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return book;
    }
}
