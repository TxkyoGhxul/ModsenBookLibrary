using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.BookDistributionCommands.Create;
public record CreateBookDistributionCommand(Guid UserId, Guid BookId) : ICreateCommand<Book>;
