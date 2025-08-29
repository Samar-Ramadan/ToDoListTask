

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Dependencies
{
    public static class MeditRDependency
    {
        public static IServiceCollection AddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
             

            return services;
        }
    }
}
