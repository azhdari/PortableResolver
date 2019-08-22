using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mohmd.AspNetCore.PortableResolver
{
    public class AppEngine : IEngine
    {
        #region Fields

        private IServiceProvider _serviceProvider;

        #endregion

        #region Properties

        public virtual IServiceProvider ServiceProvider => _serviceProvider;

        #endregion

        #region Methods

        public IServiceProvider ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //register dependencies
            RegisterDependencies(services);

            return _serviceProvider;
        }

        public void ConfigureRequestPipeline(IApplicationBuilder application)
        {
        }

        public T Resolve<T>() where T : class
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            return GetServiceProvider().GetService(type);
        }

        public virtual IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
        }

        public virtual object ResolveUnregistered(Type type)
        {
            Exception innerException = null;

            foreach (var constructor in type.GetConstructors())
            {
                try
                {
                    //try to resolve constructor parameters
                    var parameters = constructor.GetParameters().Select(parameter =>
                    {
                        var service = Resolve(parameter.ParameterType);
                        if (service == null)
                        {
                            throw new Exception("Unknown dependency");
                        }

                        return service;
                    });

                    //all is ok, so create instance
                    return Activator.CreateInstance(type, parameters.ToArray());
                }
                catch (Exception ex)
                {
                    innerException = ex;
                }
            }

            throw new Exception("No constructor was found that had all the dependencies satisfied.", innerException);
        }

        #endregion

        #region Utilities

        private IServiceProvider GetServiceProvider()
        {
            var accessor = ServiceProvider.GetService<IHttpContextAccessor>();
            var context = accessor.HttpContext;
            return context?.RequestServices ?? ServiceProvider;
        }

        private IServiceProvider RegisterDependencies(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //create service provider
            _serviceProvider = services.BuildServiceProvider();
            return _serviceProvider;
        }

        #endregion
    }
}
