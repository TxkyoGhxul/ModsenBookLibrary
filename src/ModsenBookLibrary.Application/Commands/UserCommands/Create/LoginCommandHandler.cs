using Microsoft.EntityFrameworkCore;
using ModsenBookLibrary.Application.Helpers;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Exceptions;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.UserCommands.Create;

internal class LoginCommandHandler : BaseCommandHandler<User>, ICreateCommandHandler<LoginCommand, string>
{
    private readonly IJwtTokenProvider _tokenProvider;

    public LoginCommandHandler(IJwtTokenProvider tokenProvider, IRepository<User> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
        _tokenProvider = tokenProvider;
    }

    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.Get(u => u.Email == request.Email).FirstOrDefaultAsync(cancellationToken);
        if (user == null)
        {
            return new EntityNotFoundException($"User with email ({request.Email}) not found");
        }

        var validPassword = HashHelper.GetPasswordHash(request.Password) == user.Password;
        if (!validPassword)
        {
            return new InvalidDataException("Passwords are not the same");
        }

        var token = _tokenProvider.GetJwtToken(user);

        return Result<string>.From(token);
    }
}