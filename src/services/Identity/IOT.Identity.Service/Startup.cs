using Buildin.Blocks.Application.Security.Utility;
using FluentValidation;
using IOT.Identity.Infrastructure.Database.Repositories;
using IOT.Identity.Service.CQRS.Token.Commands.GetNewToken;
using IOT.Identity.Service.CQRS.Token.Validator;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IOT.Identity.Service;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var assembly = typeof(GenerateTokenValidator).Assembly;

        return services
            .AddMediatR(typeof(Startup).GetTypeInfo().Assembly)
            .AddSingleton<EncryptionUtility>()
            .AddValidatorsFromAssemblyContaining<GenerateTokenValidator>()
            .AddScoped(typeof(Building.Blocks.Application.Persistence.IReadRepository<>), typeof(ApplicationDbRepository<>))
            .AddScoped(typeof(Building.Blocks.Application.Persistence.IRepository<>), typeof(ApplicationDbRepository<>))
            .AddScoped<GetNewTokenRequestModel>();
        ;
    }


    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config) =>
        builder
            .UseStaticFiles();
}