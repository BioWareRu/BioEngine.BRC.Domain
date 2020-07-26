using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Facebook.Service;
using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Social;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sitko.Core.App;

namespace BioEngine.BRC.Common.Facebook
{
    public class FacebookModule : BaseApplicationModule
    {
        public FacebookModule(BaseApplicationModuleConfig config, Application application) : base(config, application)
        {
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            services.AddSingleton<FacebookService>();
            services.AddScoped<IContentPublisher<FacebookConfig>, FacebookContentPublisher>();
            services.AddScoped<FacebookContentPublisher>();

            PropertiesProvider.RegisterBioEngineProperties<FacebookSitePropertiesSet, Site>("facebooksite");
        }
    }
}
