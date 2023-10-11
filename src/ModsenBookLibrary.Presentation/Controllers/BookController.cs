using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModsenBookLibrary.Application.Commands.BookCommands.Create;
using ModsenBookLibrary.Application.Commands.BookCommands.Delete;
using ModsenBookLibrary.Application.Commands.BookCommands.Update;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Application.Queries.BookQueries.GetSingle;
using ModsenBookLibrary.Application.Sorters.Fields;
using ModsenBookLibrary.Presentation.Dtos;
using System.Net;

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

    /// <summary>
    /// Gets a book by id
    /// </summary>
    /// <param name="id">Id of the book</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Book if found, otherwise, bad request with error message</returns>
    [HttpGet("id:guid")]
    [ProducesResponseType(typeof(BookDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new GetBookByIdQuery(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.Map(_mapper.Map<BookDto>).Match<IActionResult>(Ok, BadRequest);
    }

    /// <summary>
    /// Gets a book by its isbn
    /// </summary>
    /// <param name="isbn">Book isbn</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Book if found, otherwise, bad request with error message</returns>
    [HttpGet("isbn:length(5, 25)")]
    [ProducesResponseType(typeof(BookDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetByISBN(string isbn, CancellationToken cancellationToken = default)
    {
        var command = new GetBookByISBNQuery(isbn);
        var result = await _sender.Send(command, cancellationToken);

        return result.Map(_mapper.Map<BookDto>).Match<IActionResult>(Ok, BadRequest);
    }

    /// <summary>
    /// Gets all books
    /// </summary>
    /// <param name="pageNumber">Page number</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="searchText">Search text</param>
    /// <param name="field">Field to order by</param>
    /// <param name="ascending">Is order by ascending</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of all books</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedList<BookDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetAll(int pageNumber,
        int pageSize,
        string searchText = "",
        BookSortField field = BookSortField.None,
        bool ascending = true,
        CancellationToken cancellationToken = default)
    {
        var command = new GetAllBooksQuery(searchText, field, ascending, pageNumber, pageSize);
        var result = await _sender.Send(command, cancellationToken);

        return result.Match<IActionResult>(succ => Ok(succ.Map(_mapper.Map<BookDto>)), BadRequest);
    }

    /// <summary>
    /// Creates a book 
    /// </summary>
    /// <param name="dto">Dto for creating a book</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Created book</returns>
    [HttpPost]
    [ProducesResponseType(typeof(BookDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create(CreateBookDto dto, CancellationToken cancellationToken = default)
    {
        var command = new CreateBookCommand(dto.Name, dto.Description, dto.ISBN, dto.GenresIds, dto.AuthorsIds);
        var result = await _sender.Send(command, cancellationToken);

        return result.Map(_mapper.Map<BookDto>).Match<IActionResult>(Ok, BadRequest);
    }

    /// <summary>
    /// Deletes a book by id
    /// </summary>
    /// <param name="id">Id of book to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Deleted book</returns>
    [HttpDelete("id:guid")]
    [ProducesResponseType(typeof(BookDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new DeleteBookCommand(id);
        var result = await _sender.Send(command, cancellationToken);

        return result.Map(_mapper.Map<BookDto>).Match<IActionResult>(Ok, BadRequest);
    }

    /// <summary>
    /// Updates book
    /// </summary>
    /// <param name="dto">Dto for updating a book</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Updated book</returns>
    [HttpPut]
    [ProducesResponseType(typeof(BookDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(UpdateBookDto dto, CancellationToken cancellationToken = default)
    {
        var command = new UpdateBookCommand(dto.Id, dto.Name, dto.Description, dto.ISBN, dto.GenresIds, dto.AuthorsIds);
        var result = await _sender.Send(command, cancellationToken);

        return result.Map(_mapper.Map<BookDto>).Match<IActionResult>(Ok, BadRequest);
    }
}
