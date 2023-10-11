using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModsenBookLibrary.Application.Commands.UserCommands.Create;
using ModsenBookLibrary.Presentation.Dtos;
using System.Net;

namespace ModsenBookLibrary.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public UserController(ISender sender, IMapper mapper)
    {
        _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Logins user to the app
    /// </summary>
    /// <param name="dto">Dto for login to the app</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>User token if success, otherwise, unauthorized</returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> Login(LoginDto dto, CancellationToken cancellationToken = default)
    {
        var command = new LoginCommand(dto.Email, dto.Password);
        var result = await _sender.Send(command, cancellationToken);

        return result.Match<IActionResult>(Ok, Unauthorized);
    }

    /// <summary>
    /// Registeres user for the app
    /// </summary>
    /// <param name="dto">Dto for register a user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Registered user if success, otherwise, bad reqwuest with error message</returns>
    [HttpPost]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Register(RegisterDto dto, CancellationToken cancellationToken = default)
    {
        var command = new RegisterCommand(dto.Name, dto.Email, dto.Password);
        var result = await _sender.Send(command, cancellationToken);

        return result.Map(_mapper.Map<UserDto>).Match<IActionResult>(Ok, BadRequest);
    }
}
