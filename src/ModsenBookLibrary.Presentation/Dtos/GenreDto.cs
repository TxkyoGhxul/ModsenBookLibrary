namespace ModsenBookLibrary.Presentation.Dtos;
public record GenreDto(Guid Id, string Name, List<BookDto> Books);

public record CreateGenreDto(string Name);

public record UpdateGenreDto(string Name);
