using System;
using BioEngine.BRC.Domain.Patreon;
using BioEngine.Core.API;
using BioEngine.Core.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.BRC.Domain
{
    public class BrcDomainModule : BioEngineModule<BrcDomainModuleConfig>
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.RegisterApiEntities(GetType().Assembly);
            services.AddSingleton<PatreonApiHelper>();
            services.Configure<PatreonConfig>(o =>
            {
                o.ServiceUrl = new Uri(Config.PatreonServiceUrl);
            });
        }
    }

    public class BrcDomainModuleConfig
    {
        public BrcDomainModuleConfig(string patreonServiceUrl)
        {
            PatreonServiceUrl = patreonServiceUrl;
        }

        public string PatreonServiceUrl { get; }
    }
}
