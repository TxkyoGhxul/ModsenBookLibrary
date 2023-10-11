namespace ModsenBookLibrary.Presentation.Dtos;

public record RoleDto(Guid Id, string Name, List<UserDto> Users);

public record CreateRoleDto(string Name);

public record UpdateRoleDto(string Name);
