using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.UserCommands.Create;
public record RegisterCommand(string Name, string Email, string Password) : ICreateCommand<User>;
