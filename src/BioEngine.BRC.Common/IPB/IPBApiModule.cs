using BioEngine.BRC.Common.IPB.Properties;
using BioEngine.BRC.Common.IPB.Publishing;
using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Social;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sitko.Core.App;

namespace BioEngine.BRC.Common.IPB
{
    public class IPBApiModule : IPBModule<IPBApiModuleConfig>
    {
        public IPBApiModule(IPBApiModuleConfig config, Application application) : base(config, application)
        {
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);

            services.AddScoped<IContentPublisher<IPBPublishConfig>, IPBContentPublisher>();
            services.AddScoped<IPBContentPublisher>();
            services.AddScoped<IPropertiesOptionsResolver, IPBSectionPropertiesOptionsResolver>();
        }
    }

    public class IPBApiModuleConfig : IPBModuleConfig
    {
    }
}
