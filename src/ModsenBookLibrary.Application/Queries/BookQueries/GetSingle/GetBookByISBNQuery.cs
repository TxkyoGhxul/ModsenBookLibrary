using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Queries.BookQueries.GetSingle;
public record GetBookByISBNQuery(string ISBN) : ISingleQuery<Book>;
