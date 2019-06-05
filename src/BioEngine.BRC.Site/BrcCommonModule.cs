using System;
using BioEngine.BRC.Site.Patreon;
using BioEngine.Core.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.BRC.Site
{
    public class BrcSiteModule : BaseBioEngineModule<BrcSiteModuleConfig>
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.AddSingleton<PatreonApiHelper>();
            services.Configure<PatreonConfig>(o =>
            {
                o.ServiceUrl = new Uri(Config.PatreonServiceUrl);
            });
        }
    }

    public class BrcSiteModuleConfig
    {
        public BrcSiteModuleConfig(string patreonServiceUrl)
        {
            PatreonServiceUrl = patreonServiceUrl;
        }

        public string PatreonServiceUrl { get; }
    }
}
