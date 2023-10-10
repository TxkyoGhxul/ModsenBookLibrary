using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.BookCommands.Delete;
public record DeleteBookCommand(Guid Id) : IDeleteCommand<Book>;
