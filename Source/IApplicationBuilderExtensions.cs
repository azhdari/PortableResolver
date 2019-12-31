using Microsoft.AspNetCore.Builder;

namespace Mohmd.AspNetCore.PortableResolver
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UsePortableResolver(this IApplicationBuilder app)
        {
            EngineContext.Create().Configure(app.ApplicationServices);
            return app;
        }
    }
}
