using Microsoft.EntityFrameworkCore;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Exceptions;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.GenreCommands.Create;

internal class CreateGenreCommandHandler : BaseCommandHandler<Genre>, ICreateCommandHandler<CreateGenreCommand, Genre>
{
    public CreateGenreCommandHandler(IRepository<Genre> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<Result<Genre>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _repository.Get(g => g.Name == request.Name).FirstOrDefaultAsync(cancellationToken);
        if (genre != null)
        {
            return new DublicateException();
        }

        var newGenre = new Genre(request.Name);
        _repository.Create(newGenre);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return newGenre;
    }
}