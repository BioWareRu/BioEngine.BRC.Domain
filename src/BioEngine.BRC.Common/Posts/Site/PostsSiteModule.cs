using BioEngine.BRC.Common.Posts.Site.Rss;
using BioEngine.BRC.Common.Posts.Site.SiteMaps;
using BioEngine.BRC.Common.Web.Site.Rss;
using cloudscribe.Web.SiteMap;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sitko.Core.App;

namespace BioEngine.BRC.Common.Posts.Site
{
    public class PostsSiteModule : BaseApplicationModule
    {
        public PostsSiteModule(BaseApplicationModuleConfig config, Application application) : base(config, application)
        {
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.AddScoped<ISiteMapNodeService, PostsSiteMapNodeService>();
            services.AddScoped<IRssItemsProvider, PostsRssItemsProvider>();
        }
    }
}
