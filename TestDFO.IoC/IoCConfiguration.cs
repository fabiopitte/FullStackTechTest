using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace TestDFO.IoC
{
    public static class IoCConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            Configure(services, Application.IoC.Module.GetTypes());
            Configure(services, Domain.IoC.Module.GetTypes());
        }

        public static void Configure(IServiceCollection services, Dictionary<Type, Type> types)
        {
            foreach (var type in types)
            {
                services.AddScoped(type.Key, type.Value);
            }
        }
    }
}
