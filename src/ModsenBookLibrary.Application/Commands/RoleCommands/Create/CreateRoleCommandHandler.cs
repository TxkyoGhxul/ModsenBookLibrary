using Microsoft.EntityFrameworkCore;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Exceptions;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.RoleCommands.Create;

internal class CreateRoleCommandHandler : BaseCommandHandler<Role>, ICreateCommandHandler<CreateRoleCommand, Role>
{
    public CreateRoleCommandHandler(IRepository<Role> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
    }

    public async Task<Result<Role>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _repository.Get(role => role.Name ==  request.Name).FirstOrDefaultAsync(cancellationToken);
        if (role != null)
        {
            return new DublicateException();
        }

        var newRole = new Role(request.Name);
        _repository.Create(newRole);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return newRole;
    }
}