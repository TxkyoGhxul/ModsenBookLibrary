using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.GenreCommands.Create;
public record CreateGenreCommand(string Name) : ICreateCommand<Genre>;
