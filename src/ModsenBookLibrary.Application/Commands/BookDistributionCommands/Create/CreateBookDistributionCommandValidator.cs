using FluentValidation;

namespace ModsenBookLibrary.Application.Commands.BookDistributionCommands.Create;

internal class CreateBookDistributionCommandValidator : AbstractValidator<CreateBookDistributionCommand>
{
    public CreateBookDistributionCommandValidator()
    {
        RuleFor(c => c.BookId).NotEmpty();

        RuleFor(c => c.UserId).NotEmpty();

        RuleFor(c => c.ShouldReturnAt).GreaterThan(DateTime.UtcNow);
    }
}
