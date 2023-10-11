using Microsoft.EntityFrameworkCore;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Application.Extensions;
using ModsenBookLibrary.Application.Models;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Queries.RoleQueries.GetRange;

internal class GetAllRolesQueryHandler : BaseQueryHandler<Role>, IQueryHandler<GetAllRolesQuery, Role>
{
    public GetAllRolesQueryHandler(IRepository<Role> repository) : base(repository)
    {
    }

    public async Task<Result<PagedList<Role>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = _repository.GetAll();
        var countRoles = await roles.CountAsync(cancellationToken);

        return await roles.ToPagedListAsync(1, countRoles, cancellationToken);
    }
}
