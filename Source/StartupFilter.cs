using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Mohmd.AspNetCore.PortableResolver
{
    public class StartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                EngineContext.Create().Configure(app.ApplicationServices);

                next(app);
            };
        }
    }
}
