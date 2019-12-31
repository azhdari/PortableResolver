using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Mohmd.AspNetCore.PortableResolver;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddPortableServices(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var startupFilter = new StartupFilter();
            services.TryAddSingleton<IStartupFilter>(startupFilter);

            return services;
        }
    }
}
