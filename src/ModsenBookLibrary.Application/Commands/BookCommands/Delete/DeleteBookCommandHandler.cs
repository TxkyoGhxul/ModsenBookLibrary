using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Exceptions;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.BookCommands.Delete;

internal class DeleteBookCommandHandler : BaseCommandHandler<Book>, IDeleteCommandHandler<DeleteBookCommand, Book>
{
    public DeleteBookCommandHandler(IRepository<Book> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<Result<Book>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (book == null)
        {
            return new EntityNotFoundException(request.Id, typeof(Book));
        }

        _repository.Delete(book);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return book;
    }
}
