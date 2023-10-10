using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Queries.BookQueries.GetSingle;
public record GetBookByIdQuery(Guid Id) : ISingleQuery<Book>;
