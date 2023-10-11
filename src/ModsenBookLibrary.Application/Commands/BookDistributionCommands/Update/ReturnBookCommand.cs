using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.BookDistributionCommands.Update;
public record ReturnBookCommand(Guid BookId) : IUpdateCommand<Book>;
