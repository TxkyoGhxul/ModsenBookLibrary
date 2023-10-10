using FluentValidation;

namespace ModsenBookLibrary.Application.Commands.BookCommands.Update;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(b => b.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);

        RuleFor(c => c.Name).Length(3, 35);

        RuleFor(c => c.Description).Length(3, 350);

        RuleFor(c => c.ISBN).Length(10, 25);
    }
}
