using Mohmd.AspNetCore.PortableResolver;

namespace Microsoft.AspNetCore.Builder
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UsePortableResolver(this IApplicationBuilder app)
        {
            ResolverContext.Create().Configure(app.ApplicationServices);
            return app;
        }
    }
}
