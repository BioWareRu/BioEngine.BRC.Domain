using BioEngine.Core.API;
using BioEngine.Core.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.BRC.Domain
{
    public class BrcDomainModule : BioEngineModule
    {
    }

    public class BrcDomainApiModule : BrcDomainModule
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.RegisterApiEntities(GetType().Assembly);
        }
    }
}
