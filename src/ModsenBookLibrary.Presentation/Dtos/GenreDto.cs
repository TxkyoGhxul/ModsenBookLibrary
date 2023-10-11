namespace ModsenBookLibrary.Presentation.Dtos;
public record GenreDto(Guid Id, string Name);

public record CreateGenreDto(string Name);

public record UpdateGenreDto(string Name);
