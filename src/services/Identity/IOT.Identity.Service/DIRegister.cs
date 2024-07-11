using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MediatR;
using Buildin.Blocks.Application.Security.Utility;

namespace IOT.Identity.Service
{
    public static class DIRegister
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRequest>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
        }

        //public static void AddUnitOfWork(this IServiceCollection services)
        //{
        //    services.AddScoped<IUnitOfWork, UnitOfWork>();
        //}

        public static void AddInfraUtility(this IServiceCollection services)
        {
            services.AddSingleton<EncryptionUtility>();
        }
    }
}
