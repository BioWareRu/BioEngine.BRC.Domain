using System.Reflection;
using BioEngine.BRC.Common.Web.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sitko.Core.App;

namespace BioEngine.BRC.Common.Web.Api
{
    public class ApiModule : WebModule<ApiModuleConfig>
    {
        public ApiModule(ApiModuleConfig config, Application application) : base(config, application)
        {
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.RegisterApiEntities(GetType().Assembly);
        }
    }

    public static class ApiServiceExtensions
    {
        public static IServiceCollection RegisterApiEntities(this IServiceCollection services, Assembly assembly)
        {
            return services.Scan(s =>
                s.FromAssemblies(assembly).AddClasses(classes =>
                        classes.AssignableToAny(typeof(IResponseRestModel<>), typeof(IRequestRestModel<>)))
                    .AsSelf());
        }

        public static IServiceCollection RegisterApiEntities<T>(this IServiceCollection services)
        {
            return services.Scan(s =>
                s.FromAssemblies(typeof(T).Assembly).AddClasses(classes =>
                        classes.AssignableToAny(typeof(IResponseRestModel<>), typeof(IRequestRestModel<>)))
                    .AsSelf());
        }
    }

    public class ApiModuleConfig : WebModuleConfig
    {
    }
}
