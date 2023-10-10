using Microsoft.EntityFrameworkCore;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Exceptions;
using ModsenBookLibrary.Domain.Models;
using ModsenBookLibrary.Domain.Primitives;

namespace ModsenBookLibrary.Application.Commands.BookCommands.Update;

internal class UpdateBookCommandHandler : BaseCommandHandler<Book>, IUpdateCommandHandler<UpdateBookCommand, Book>
{
    private readonly IRepository<Genre> _genreRepository;
    private readonly IRepository<User> _userRepository;

    public UpdateBookCommandHandler(IRepository<Book> repository, IUnitOfWork unitOfWork, IRepository<Genre> genreRepository, IRepository<User> userRepository) : base(repository, unitOfWork)
    {
        _genreRepository = genreRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<Book>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var validISBN = ISBN.TryFrom(request.ISBN, out var isbn);
        if (!validISBN)
        {
            return new InvalidISBNException(request.ISBN);
        }

        var book = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (book == null)
        {
            return new EntityNotFoundException(request.Id, typeof(Book));
        }

        var genres = await _genreRepository.Get(g => request.GenresIds.Contains(g.Id)).ToListAsync(cancellationToken);
        var authors = await _userRepository.Get(a => request.AuthorsIds.Contains(a.Id)).ToListAsync(cancellationToken);

        book.Name = request.Name;
        book.Description = request.Description;
        book.ISBN = isbn;
        book.Genres = genres;
        book.Authors = authors;

        _repository.Update(book);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return book;
    }
}