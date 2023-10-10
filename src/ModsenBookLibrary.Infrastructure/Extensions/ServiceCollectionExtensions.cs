using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Infrastructure.Data;
using ModsenBookLibrary.Infrastructure.Repositories;

namespace ModsenBookLibrary.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection InjectDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IBookDbContext, BookDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static IServiceCollection InjectRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        return services;
    }
}
