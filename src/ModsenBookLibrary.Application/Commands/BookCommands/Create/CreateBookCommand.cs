using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.BookCommands.Create;
public record CreateBookCommand(
    string Name,
    string Description,
    string ISBN,
    IEnumerable<Guid> GenresIds,
    IEnumerable<Guid> AuthorsIds) 
    : ICreateCommand<Book>;
