using Mohmd.AspNetCore.PortableResolver;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class JsonLocalizationServiceCollectionExtensions
    {
        public static IServiceProvider AddPortableResolver(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return EngineContext.Create().ConfigureServices(services);
        }
    }
}
