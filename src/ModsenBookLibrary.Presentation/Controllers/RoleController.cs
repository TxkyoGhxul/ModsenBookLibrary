using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModsenBookLibrary.Application.Commands.RoleCommands.Create;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Application.Queries.RoleQueries.GetRange;
using ModsenBookLibrary.Presentation.Dtos;
using System.Net;

namespace ModsenBookLibrary.Presentation.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public RoleController(ISender sender, IMapper mapper)
    {
        _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Gets all roles from database
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>All roles if true, otherwise, bad request with error message</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedList<RoleDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
    {
        var query = new GetAllRolesQuery();
        var result = await _sender.Send(query, cancellationToken);

        return result.Match<IActionResult>(succ => Ok(succ.Map(_mapper.Map<RoleDto>)), BadRequest);
    }

    /// <summary>
    /// Creates a new role
    /// </summary>
    /// <param name="dto">Dto for creating a new role</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Created role if true, otherwise, bad request with error message</returns>
    [HttpPost]
    [ProducesResponseType(typeof(RoleDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create(CreateRoleDto dto, CancellationToken cancellationToken = default)
    {
        var command = new CreateRoleCommand(dto.Name);
        var result = await _sender.Send(command, cancellationToken);

        return result.Map(_mapper.Map<RoleDto>).Match<IActionResult>(Ok, BadRequest);
    }
}
