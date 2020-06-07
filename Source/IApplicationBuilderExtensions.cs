using Mohmd.AspNetCore.PortableResolver;

namespace Microsoft.AspNetCore.Builder
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder ConfigurePortableResolver(this IApplicationBuilder app)
        {
            ResolverContext.Create().Configure(app.ApplicationServices);
            return app;
        }
    }
}
