using BioEngine.BRC.Common.Pages.Site.SiteMaps;
using cloudscribe.Web.SiteMap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sitko.Core.App;

namespace BioEngine.BRC.Common.Pages.Site
{
    public class PagesSiteModule : BaseApplicationModule
    {
        public PagesSiteModule(BaseApplicationModuleConfig config, Application application) : base(config, application)
        {
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.AddScoped<ISiteMapNodeService, PagesSiteMapNodeService>();
        }
    }
}
