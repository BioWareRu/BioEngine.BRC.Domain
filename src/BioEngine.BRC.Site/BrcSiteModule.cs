using System;
using BioEngine.BRC.Common.Users;
using BioEngine.BRC.Site.Patreon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sitko.Core.App;

namespace BioEngine.BRC.Site
{
    public class BrcSiteModule : BaseApplicationModule<BrcSiteModuleConfig>
    {
        public BrcSiteModule(BrcSiteModuleConfig config, Application application) : base(config, application)
        {
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            if (environment.IsDevelopment())
            {
                services.AddScoped<IUserDataProvider, TestUserDataProvider>();
            }

            services.AddSingleton<PatreonApiHelper>();
            services.Configure<PatreonConfig>(o =>
            {
                o.ServiceUrl = new Uri(Config.PatreonServiceUrl);
            });
        }
    }

    public class BrcSiteModuleConfig
    {
        public string PatreonServiceUrl { get; set; } = "http://localhost";
    }
}
