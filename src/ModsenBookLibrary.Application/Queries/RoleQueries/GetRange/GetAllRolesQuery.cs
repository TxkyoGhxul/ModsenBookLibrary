using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models;

namespace ModsenBookLibrary.Application.Queries.RoleQueries.GetRange;
public record GetAllRolesQuery : IQuery<Role>;
