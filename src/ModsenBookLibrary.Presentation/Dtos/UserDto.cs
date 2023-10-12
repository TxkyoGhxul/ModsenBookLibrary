namespace ModsenBookLibrary.Presentation.Dtos;
public record UserDto(Guid Id, string Name, string Email, List<RoleDto> Roles);

public record LoginDto(string Email, string Password);

public record RegisterDto(string Name, string Email, string Password);
