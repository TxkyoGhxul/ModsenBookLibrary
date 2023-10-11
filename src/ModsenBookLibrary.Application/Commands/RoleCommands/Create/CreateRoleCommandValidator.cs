using FluentValidation;

namespace ModsenBookLibrary.Application.Commands.RoleCommands.Create;

internal class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().Length(3, 25);
    }
}
