using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Domain.Models.Base;

namespace ModsenBookLibrary.Application.Commands;
internal abstract class BaseCommandHandler<TModel> where TModel : IEntity, new()
{
    protected readonly IRepository<TModel> _repository;
    protected readonly IUnitOfWork _unitOfWork;

    protected BaseCommandHandler(IRepository<TModel> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
}
