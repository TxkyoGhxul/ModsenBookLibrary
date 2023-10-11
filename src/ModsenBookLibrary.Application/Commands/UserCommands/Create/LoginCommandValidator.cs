using FluentValidation;

namespace ModsenBookLibrary.Application.Commands.UserCommands.Create;

internal class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(c =>  c.Email).Must(email => !string.IsNullOrWhiteSpace(email));

        RuleFor(c =>  c.Password).Must(password => !string.IsNullOrWhiteSpace(password));
    }
}
