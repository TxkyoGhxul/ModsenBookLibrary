using Microsoft.EntityFrameworkCore;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Constants;
using ModsenBookLibrary.Domain.Exceptions;
using ModsenBookLibrary.Domain.Models;
using ModsenBookLibrary.Domain.Primitives;

namespace ModsenBookLibrary.Application.Commands.UserCommands.Create;

internal class RegisterCommandHandler : BaseCommandHandler<User>, ICreateCommandHandler<RegisterCommand, User>
{
    private readonly IRepository<Role> _roleRepository;

    public RegisterCommandHandler(IRepository<User> repository, IUnitOfWork unitOfWork, IRepository<Role> roleRepository) : base(repository, unitOfWork)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Result<User>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var emailCreated = Email.TryFrom(request.Email, out var email);
        if (!emailCreated)
        {
            return new InvalidEmailException(request.Email);
        }

        var uniqueEmail = !await _repository.Get(u => u.Email == request.Email).AnyAsync(cancellationToken);
        if (!uniqueEmail)
        {
            return new DublicateException();
        }

        var userRole = await _roleRepository.Get(r => r.Name == Roles.User).FirstOrDefaultAsync(cancellationToken);
        if (userRole == null)
        {
            return new EntityNotFoundException("User role not found");
        }

        var user = new User(request.Name, email, request.Password);

        _repository.Create(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user;
    }
}
