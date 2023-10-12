using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Exceptions;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.BookDistributionCommands.Create;

internal class CreateBookDistributionCommandHandler
    : BaseCommandHandler<Book>, ICreateCommandHandler<CreateBookDistributionCommand, Book>
{
    private readonly IRepository<User> _userRepository;

    public CreateBookDistributionCommandHandler(
        IRepository<Book> repository,
        IUnitOfWork unitOfWork,
        IRepository<User> userRepository)
        : base(repository, unitOfWork)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<Book>> Handle(CreateBookDistributionCommand request, CancellationToken cancellationToken)
    {
        var book = await _repository.GetByIdAsync(request.BookId, cancellationToken);
        if (book == null)
        {
            return new EntityNotFoundException(request.BookId, typeof(Book));
        }

        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user == null)
        {
            return new EntityNotFoundException(request.UserId, typeof(User));
        }

        var distribution = new BookDistribution(request.UserId, request.BookId, request.ShouldReturnAt);

        book.BookDistributions?.Add(distribution);

        _repository.Update(book);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return book;
    }
}