using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models.Base;

namespace ModsenBookLibrary.Application.Queries;
internal abstract class BaseQueryHandler<TModel> where TModel : IEntity, new()
{
    protected readonly IRepository<TModel> _repository;

    protected BaseQueryHandler(IRepository<TModel> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
}
