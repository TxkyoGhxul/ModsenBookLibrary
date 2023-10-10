using MediatR;
using ModsenBookLibrary.Application.Models;

namespace ModsenBookLibrary.Application.Interfaces;
internal interface ICreateCommand<T> : IRequest<Result<T>>
{
}

internal interface ICreateCommandHandler<TCommand, TModel> : IRequestHandler<TCommand, Result<TModel>>
    where TCommand : class, ICreateCommand<TModel>
{
}

internal interface IDeleteCommand<T> : IRequest<Result<T>>
{
}

internal interface IDeleteCommandHandler<TCommand, TModel> : IRequestHandler<TCommand, Result<TModel>>
    where TCommand : class, IDeleteCommand<TModel>
{
}

internal interface IQuery<T> : IRequest<Result<PagedList<T>>>
{
}

internal interface IQueryHandler<TCommand, TModel> : IRequestHandler<TCommand, Result<PagedList<TModel>>>
    where TCommand : class, IQuery<TModel>
{
}

public interface ISingleQuery<T> : IRequest<Result<T>>
{
}

internal interface ISingleQueryHandler<TCommand, TModel> : IRequestHandler<TCommand, Result<TModel>>
    where TCommand : class, ISingleQuery<TModel>
{
}

internal interface IUpdateCommand<T> : IRequest<Result<T>>
{
}

internal interface IUpdateCommandHandler<TCommand, TModel> : IRequestHandler<TCommand, Result<TModel>>
    where TCommand : class, IUpdateCommand<TModel>
{
}
