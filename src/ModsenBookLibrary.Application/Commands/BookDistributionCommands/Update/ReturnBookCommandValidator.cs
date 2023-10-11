using FluentValidation;

namespace ModsenBookLibrary.Application.Commands.BookDistributionCommands.Update;

internal class ReturnBookCommandValidator : AbstractValidator<ReturnBookCommand>
{
    public ReturnBookCommandValidator()
    {
        RuleFor(c => c.BookId).NotEmpty();
    }
}
