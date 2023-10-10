using FluentValidation;

namespace ModsenBookLibrary.Application.Queries.BookQueries.GetSingle;

public class GetBookByISBNQueryValidator : AbstractValidator<GetBookByISBNQuery>
{
    public GetBookByISBNQueryValidator()
    {
        RuleFor(c => c.ISBN)
            .Must(c => !string.IsNullOrWhiteSpace(c));
    }
}
