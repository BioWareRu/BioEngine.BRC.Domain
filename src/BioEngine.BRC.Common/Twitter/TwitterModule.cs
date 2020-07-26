using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Social;
using BioEngine.BRC.Common.Twitter.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sitko.Core.App;

namespace BioEngine.BRC.Common.Twitter
{
    public class TwitterModule : BaseApplicationModule
    {
        public TwitterModule(BaseApplicationModuleConfig config, Application application) : base(config, application)
        {
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            services.AddSingleton<TwitterService>();
            services.AddScoped<IContentPublisher<TwitterPublishConfig>, TwitterContentPublisher>();
            services.AddScoped<TwitterContentPublisher>();

            PropertiesProvider.RegisterBioEngineProperties<TwitterSitePropertiesSet, Site>("twittersite");
        }
    }
}
