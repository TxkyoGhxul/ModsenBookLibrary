using FluentValidation;

namespace ModsenBookLibrary.Application.Queries.BookQueries.GetSingle;

public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
{
    public GetBookByIdQueryValidator()
    {
        RuleFor(b => b.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
    }
}
