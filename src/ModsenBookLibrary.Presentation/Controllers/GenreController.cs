using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModsenBookLibrary.Application.Commands.GenreCommands.Create;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Application.Queries.GenreQueries.GetRange;
using ModsenBookLibrary.Presentation.Dtos;
using System.Net;

namespace ModsenBookLibrary.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public GenreController(ISender sender, IMapper mapper)
    {
        _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Gets all genres from database
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>All genres if success, otherwise, bad request with error message</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedList<GenreDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
    {
        var query = new GetAllGenresQuery();
        var result = await _sender.Send(query, cancellationToken);

        return result.Match<IActionResult>(succ => Ok(succ.Map(_mapper.Map<GenreDto>)), BadRequest);
    }

    /// <summary>
    /// Creates a genre
    /// </summary>
    /// <param name="dto">Dto for creating a genre</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Created genre if success, otherwise, bad request with error message</returns>
    [HttpPost]
    [ProducesResponseType(typeof(GenreDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create(CreateGenreDto dto, CancellationToken cancellationToken = default)
    {
        var command = new CreateGenreCommand(dto.Name);
        var result = await _sender.Send(command, cancellationToken);

        return result.Map(_mapper.Map<GenreDto>).Match<IActionResult>(Ok, BadRequest);
    }
}
