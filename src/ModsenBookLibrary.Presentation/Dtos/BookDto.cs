using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Presentation.Dtos;
public record BookDto(
    Guid Id,
    string Name,
    string Description,
    string ISBN,
    List<GenreDto> Genres,
    List<UserDto> Authors,
    List<BookDistribution> BookDistributions);

public record CreateBookDto(
    string Name,
    string Description,
    string ISBN,
    IEnumerable<Guid> GenresIds,
    IEnumerable<Guid> AuthorsIds);

public record UpdateBookDto(
    Guid Id,
    string Name,
    string Description,
    string ISBN,
    IEnumerable<Guid> GenresIds,
    IEnumerable<Guid> AuthorsIds);