using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohmd.AspNetCore.PortableResolver
{
    public interface IEngine
    {
        IServiceProvider ConfigureServices(IServiceCollection services, IConfiguration configuration);

        void ConfigureRequestPipeline(IApplicationBuilder application);

        T Resolve<T>() where T : class;

        object Resolve(Type type);

        IEnumerable<T> ResolveAll<T>();

        object ResolveUnregistered(Type type);
    }
}
