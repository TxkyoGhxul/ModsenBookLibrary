using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Commands.RoleCommands.Create;
public record CreateRoleCommand(string Name) : ICreateCommand<Role>;
