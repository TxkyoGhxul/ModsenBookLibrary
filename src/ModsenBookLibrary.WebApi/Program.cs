using ModsenBookLibrary.Application.Queries.BookQueries.GetRange.Controllers;
using ModsenBookLibrary.Infrastructure.Extensions;
using ModsenBookLibrary.Application.Extensions;
using ModsenBookLibrary.WebApi.Extensions;
using System.Text.Json.Serialization;
using ModsenBookLibrary.Presentation.Extensions;
using Serilog;
using ModsenBookLibrary.WebApi.OptionsSetup;
using ModsenBookLibrary.Infrastructure.Auth;
using ModsenBookLibrary.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(BookController).Assembly)
    .AddControllersAsServices()
    .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.Services
    .InjectDbContext(builder.Configuration)
    .InjectRepositories()
    .InjectJwtBearer(builder.Configuration)
    .InjectMediatR()
    .InjectValidators()
    .InjectSorters()
    .InjectAutoMapper()
    .AddSwagger()
    .AddCorsPolicy();

builder.Services.AddSingleton<JwtOptions>();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
