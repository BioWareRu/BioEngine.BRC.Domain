using System;
using BioEngine.BRC.Common;
using BioEngine.Core.Abstractions;
using BioEngine.Core.Logging.Loki;
using BioEngine.Core.Seo;
using BioEngine.Core.Site;
using BioEngine.Core.Users;
using BioEngine.Extra.Ads;
using BioEngine.Extra.IPB;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.BRC.Site
{
    public static class BioEngineExtensions
    {
        public static Core.BioEngine AddBrcSite(this Core.BioEngine bioEngine)
        {
            bioEngine
                .AddPostgresDb()
                .AddBrcDomain()
                .AddModule<BrcSiteModule, BrcSiteModuleConfig>(
                    (configuration, env) =>
                        new BrcSiteModuleConfig(configuration["BE_PATREON_SERVICE_URL"]))
                .AddModule<LokiLoggingModule, LokiLoggingConfig>((configuration, environment) =>
                    new LokiLoggingConfig(configuration["BRC_LOKI_URL"]))
                .AddElasticSearch()
                .AddS3Storage()
                .AddModule<SeoModule>()
                .AddModule<IPBSiteModule, IPBModuleConfig>((configuration, env) =>
                {
                    if (!Uri.TryCreate(configuration["BE_IPB_URL"], UriKind.Absolute, out var ipbUrl))
                    {
                        throw new ArgumentException($"Can't parse IPB url; {configuration["BE_IPB_URL"]}");
                    }

                    return new IPBModuleConfig(ipbUrl)
                    {
                        ApiClientId = configuration["BE_IPB_OAUTH_CLIENT_ID"],
                        ApiClientSecret = configuration["BE_IPB_OAUTH_CLIENT_SECRET"],
                        CallbackPath = "/login/ipb",
                        AuthorizationEndpoint = configuration["BE_IPB_AUTHORIZATION_ENDPOINT"],
                        TokenEndpoint = configuration["BE_IPB_TOKEN_ENDPOINT"],
                        ApiReadonlyKey = configuration["BE_IPB_API_READONLY_KEY"]
                    };
                })
                .AddModule<SiteModule, SiteModuleConfig>((configuration, env) =>
                    new SiteModuleConfig(Guid.Parse(configuration["BE_SITE_ID"])))
                .AddModule<AdsModule>();

            bioEngine.ConfigureServices((context, collection) =>
            {
                if (context.HostingEnvironment.IsDevelopment())
                {
                    collection.AddScoped<IUserDataProvider, TestUserDataProvider>();
                }
            });

            return bioEngine;
        }
    }
}
