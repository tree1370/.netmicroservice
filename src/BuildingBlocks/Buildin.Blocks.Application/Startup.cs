using Building.Blocks.Application.Common.Validation;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
         .AddMediatR(typeof(Startup).GetTypeInfo().Assembly)
            .AddTransient<IHttpContextAccessor, HttpContextAccessor>();

    }
}