using FluentValidation;

namespace ModsenBookLibrary.Application.Commands.GenreCommands.Create;

internal class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(x => x.Name).Must(c => !string.IsNullOrWhiteSpace(c));
    }
}