using System;
using BioEngine.BRC.Common;
using BioEngine.Core.Pages.Site;
using BioEngine.Core.Posts.Site;
using BioEngine.Core.Seo;
using BioEngine.Core.Site;
using BioEngine.Core.Users;
using BioEngine.Extra.Ads.Site;
using BioEngine.Extra.IPB;
using BioEngine.Extra.IPB.Auth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog.Events;

namespace BioEngine.BRC.Site
{
    public static class BioEngineExtensions
    {
        public static Core.BioEngine AddBrcSite(this Core.BioEngine bioEngine)
        {
            bioEngine
                .AddPostgresDb()
                .AddBrcDomain()
                .AddModule<PagesSiteModule>()
                .AddModule<PostsSiteModule<string>>()
                .AddModule<BrcSiteModule, BrcSiteModuleConfig>(
                    (configuration, env) =>
                        new BrcSiteModuleConfig(configuration["BE_PATREON_SERVICE_URL"]))
                .AddLogging(configure: (configuration, env) =>
                {
                    if (!env.IsDevelopment())
                    {
                        configuration.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
                    }
                })
                .AddElasticSearch()
                .AddS3Storage()
                .AddModule<SeoModule>()
                .AddModule<IPBSiteModule, IPBSiteModuleConfig>((configuration, env) =>
                {
                    if (!Uri.TryCreate(configuration["BE_IPB_URL"], UriKind.Absolute, out var ipbUrl))
                    {
                        throw new ArgumentException($"Can't parse IPB url; {configuration["BE_IPB_URL"]}");
                    }

                    return new IPBSiteModuleConfig(ipbUrl) {ApiReadonlyKey = configuration["BE_IPB_API_READONLY_KEY"]};
                })
                .AddIpbUsers<IPBSiteUsersModule, IPBSiteUsersModuleConfig, IPBSiteCurrentUserProvider>()
                .AddModule<SiteModule, SiteModuleConfig>((configuration, env) =>
                    new SiteModuleConfig(
                        Guid.Parse(configuration["BE_SITE_ID"])) {EnableRuntimeCompilation = env.IsDevelopment()})
                .AddModule<AdsSiteModule>();

            bioEngine.ConfigureServices((context, collection) =>
            {
                if (context.HostingEnvironment.IsDevelopment())
                {
                    collection.AddScoped<IUserDataProvider<string>, TestUserDataProvider>();
                }
            });

            return bioEngine;
        }
    }
}
