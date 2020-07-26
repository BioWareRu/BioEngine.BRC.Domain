using System;
using BioEngine.BRC.Common;
using BioEngine.BRC.Common.Ads.Site;
using BioEngine.BRC.Common.IPB;
using BioEngine.BRC.Common.IPB.Auth;
using BioEngine.BRC.Common.Seo;
using BioEngine.BRC.Common.Web.Site;

namespace BioEngine.BRC.Site
{
    public class BRCSiteApplication : BRCApplication
    {
        public BRCSiteApplication(string[] args) : base(args)
        {
            AddPostgresDb()
                .AddBrcDomain()
                .AddElasticSearch()
                .AddElasticStack()
                .AddS3Storage()
                .AddModule<SeoModule>()
                .AddModule<IPBSiteModule, IPBSiteModuleConfig>((configuration, env, moduleConfig) =>
                {
                    if (!Uri.TryCreate(configuration["BE_IPB_URL"], UriKind.Absolute, out var ipbUrl))
                    {
                        throw new ArgumentException($"Can't parse IPB url; {configuration["BE_IPB_URL"]}");
                    }

                    moduleConfig.Url = ipbUrl;
                    moduleConfig.ApiReadonlyKey = configuration["BE_IPB_API_READONLY_KEY"];
                })
                .AddIpbUsers<IPBSiteUsersModule, IPBSiteUsersModuleConfig, IPBSiteCurrentUserProvider>()
                .AddModule<SiteModule, SiteModuleConfig>((configuration, env, moduleConfig) =>
                {
                    if (!string.IsNullOrEmpty(configuration["BE_SITE_ID"]))
                    {
                        moduleConfig.SiteId = Guid.Parse(configuration["BE_SITE_ID"]);
                    }
                })
                .AddModule<AdsSiteModule>()
                .AddModule<BrcSiteModule, BrcSiteModuleConfig>(
                    (configuration, env, moduleConfig) =>
                    {
                        if (!string.IsNullOrEmpty(configuration["BE_PATREON_SERVICE_URL"]))
                        {
                            moduleConfig.PatreonServiceUrl = configuration["BE_PATREON_SERVICE_URL"];
                        }
                    });
        }
    }
}
