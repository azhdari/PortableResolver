using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Mohmd.AspNetCore.PortableResolver
{
    public interface IEngine
    {
        IServiceProvider ConfigureServices(IServiceCollection services);

        T Resolve<T>() where T : class;

        object Resolve(Type type);

        IEnumerable<T> ResolveAll<T>();

        object ResolveUnregistered(Type type);

        T ResolveUnregistered<T>();
    }
}
