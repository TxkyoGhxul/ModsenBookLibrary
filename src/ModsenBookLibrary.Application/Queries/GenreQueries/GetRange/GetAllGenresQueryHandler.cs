using Microsoft.EntityFrameworkCore;
using ModsenBookLibrary.Application.Extensions;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Queries.GenreQueries.GetRange;

internal class GetAllGenresQueryHandler : BaseQueryHandler<Genre>, IQueryHandler<GetAllGenresQuery, Genre>
{
    public GetAllGenresQueryHandler(IRepository<Genre> repository) : base(repository)
    {
    }

    public async Task<Result<PagedList<Genre>>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        var genres = _repository.GetAll();
        var countGenres = await genres.CountAsync(cancellationToken);

        return await genres.ToPagedListAsync(1, countGenres, cancellationToken);
    }
}