using Microsoft.EntityFrameworkCore;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Exceptions;
using ModsenBookLibrary.Domain.Models;
using ModsenBookLibrary.Domain.Primitives;

namespace ModsenBookLibrary.Application.Commands.BookCommands.Update;

internal class UpdateBookCommandHandler : BaseCommandHandler<Book>, IUpdateCommandHandler<UpdateBookCommand, Book>
{
    public UpdateBookCommandHandler(IRepository<Book> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<Result<Book>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (book == null)
        {
            return new EntityNotFoundException(request.Id, typeof(Book));
        }

        book.Name = request.Name;
        book.Description = request.Description;

        _repository.Update(book);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return book;
    }
}