using Microsoft.EntityFrameworkCore;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Exceptions;
using ModsenBookLibrary.Domain.Models;
using ModsenBookLibrary.Domain.Primitives;

namespace ModsenBookLibrary.Application.Commands.BookCommands.Create;

internal class CreateBookCommandHandler : BaseCommandHandler<Book>, ICreateCommandHandler<CreateBookCommand, Book>
{
    private readonly IRepository<Genre> _genreRepository;
    private readonly IRepository<User> _userRepository;

    public CreateBookCommandHandler(IRepository<Genre> genreRepository, IRepository<Book> repository, IUnitOfWork unitOfWork, IRepository<User> userRepository) : base(repository, unitOfWork)
    {
        _genreRepository = genreRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<Book>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var validISBN = ISBN.TryFrom(request.ISBN, out var isbn);
        if (!validISBN)
        {
            return new InvalidISBNException(request.ISBN);
        }

        var genres = await _genreRepository.Get(g => request.GenresIds.Contains(g.Id)).ToListAsync(cancellationToken);
        var authors = await _userRepository.Get(a => request.AuthorsIds.Contains(a.Id)).ToListAsync(cancellationToken);

        var book = new Book(request.Name, request.Description, isbn, genres, authors);

        _repository.Create(book);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return book;
    }
}