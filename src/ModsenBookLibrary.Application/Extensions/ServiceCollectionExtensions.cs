using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ModsenBookLibrary.Application.Behaviors;
using ModsenBookLibrary.Application.Sorters;
using ModsenBookLibrary.Application.Sorters.Base;
using ModsenBookLibrary.Application.Sorters.Fields;
using ModsenBookLibrary.Domain.Models;
using System.Reflection;

namespace ModsenBookLibrary.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection InjectMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PerfomanceBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));

        return services;
    }

    public static IServiceCollection InjectValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }

    public static IServiceCollection InjectSorters(this IServiceCollection services)
    {
        services.AddScoped<ISorter<Book, BookSortField>, BookSorter>();

        return services;
    }
}
