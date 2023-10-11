using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.BookCommands.Update;
public record UpdateBookCommand(
    Guid Id,
    string Name,
    string Description)
    : IUpdateCommand<Book>;
