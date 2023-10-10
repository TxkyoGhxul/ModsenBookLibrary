using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModsenBookLibrary.Application.Queries.BookQueries.GetSingle;

namespace ModsenBookLibrary.Application.Queries.BookQueries.GetRange.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public BookController(ISender sender, IMapper mapper)
    {
        _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet("id:guid")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new GetBookByIdQuery(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.Match<IActionResult>(Ok, BadRequest);
    }
}
