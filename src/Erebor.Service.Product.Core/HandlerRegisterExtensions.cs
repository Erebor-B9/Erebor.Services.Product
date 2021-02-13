using System.Reflection;
using Erebor.Service.Product.Core.Domain;
using Erebor.Service.Product.Domain.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Erebor.Service.Product.Core
{
    public static class HandlerRegisterExtensions
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateCategoryCommand).GetTypeInfo().Assembly);
        }
    }
}