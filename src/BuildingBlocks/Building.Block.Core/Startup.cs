using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class Startup
{
    public static IServiceCollection AddBlockCore(this IServiceCollection services)
    {
        return services
         .AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

    }
}