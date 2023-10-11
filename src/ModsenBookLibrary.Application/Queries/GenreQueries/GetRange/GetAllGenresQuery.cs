using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Queries.GenreQueries.GetRange;
public record GetAllGenresQuery : IQuery<Genre>;
