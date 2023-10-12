using ModsenBookLibrary.Application.Interfaces;

namespace ModsenBookLibrary.Application.Commands.UserCommands.Create;
public record LoginCommand(string Email, string Password) : ICreateCommand<string>;
