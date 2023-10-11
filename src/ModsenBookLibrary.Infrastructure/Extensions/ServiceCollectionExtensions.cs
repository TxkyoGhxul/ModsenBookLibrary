using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ModsenBookLibrary.Application.Interfaces;
using ModsenBookLibrary.Infrastructure.Auth;
using ModsenBookLibrary.Infrastructure.Data;
using ModsenBookLibrary.Infrastructure.Repositories;
using System.Text;

namespace ModsenBookLibrary.Infrastructure.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection InjectDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
            options.UseLazyLoadingProxies();
        });

        services.AddScoped<RolesInitializer>();

        services.AddScoped<IBookDbContext, BookDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    public static IServiceCollection InjectRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        return services;
    }

    public static IServiceCollection InjectJwtBearer(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = config["Jwt:Issuer"],
                ValidAudience = config["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(config["Jwt:SecretKey"]!)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        });

        services.AddAuthorization();

        services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();

        return services;
    }
}
