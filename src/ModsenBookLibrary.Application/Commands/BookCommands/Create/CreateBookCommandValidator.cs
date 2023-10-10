using FluentValidation;

namespace ModsenBookLibrary.Application.Commands.BookCommands.Create;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(c => c.Name).Length(3, 35);

        RuleFor(c => c.Description).Length(3, 350);

        RuleFor(c => c.ISBN).Length(10, 25);
    }
}
