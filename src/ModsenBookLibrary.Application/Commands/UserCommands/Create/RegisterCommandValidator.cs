using FluentValidation;

namespace ModsenBookLibrary.Application.Commands.UserCommands.Create;

internal class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(c => c.Name).Must(name => !string.IsNullOrWhiteSpace(name));

        RuleFor(c => c.Email).Must(email => !string.IsNullOrWhiteSpace(email));

        RuleFor(c => c.Password).Must(password => !string.IsNullOrWhiteSpace(password));
    }
}
