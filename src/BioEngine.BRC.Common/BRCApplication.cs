using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BioEngine.BRC.Common.IPB;
using BioEngine.BRC.Common.Policies;
using BioEngine.BRC.Common.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
using Sitko.Core.App.Web;
using Sitko.Core.Db.Postgres;
using Sitko.Core.ElasticStack;
using Sitko.Core.Repository.EntityFrameworkCore;
using Sitko.Core.Search.ElasticSearch;
using Sitko.Core.Storage;
using Sitko.Core.Storage.S3;

namespace BioEngine.BRC.Common
{
    public class BRCApplication : WebApplication<BRCApplication>
    {
        public BRCApplication(string[] args) : base(args)
        {
        }

        public BRCApplication AddElasticStack()
        {
            if (!string.IsNullOrEmpty(Configuration["BE_ELASTIC_ES_URI"]) &&
                !string.IsNullOrEmpty(Configuration["BE_ELASTIC_APM_URI"]))
            {
                LoggingEnableConsole = Environment.IsDevelopment() ||
                                       !string.IsNullOrEmpty(Configuration["BE_LOGS_CONSOLE"]) &&
                                       bool.TryParse(Configuration["BE_LOGS_CONSOLE"],
                                           out var forceConsoleLogging) && forceConsoleLogging;
                AddModule<ElasticStackModule, ElasticStackModuleConfig>((configuration, environment, moduleConfig) =>
                    moduleConfig.EnableLogging(new Uri(configuration["BE_ELASTIC_ES_URI"]))
                        .EnableApm(new Uri(configuration["BE_ELASTIC_APM_URI"])));
            }
            else
            {
                LoggingEnableConsole = true;
            }

            return this;
        }


        public BRCApplication AddPostgresDb(bool enablePooling = true)
        {
            return AddModule<PostgresModule<BioContext>, PostgresDatabaseModuleConfig<BioContext>>(
                    (configuration, env, moduleConfig) =>
                    {
                        moduleConfig.Host = configuration["BE_POSTGRES_HOST"];
                        moduleConfig.Port = int.Parse(configuration["BE_POSTGRES_PORT"]);
                        moduleConfig.Database = configuration["BE_POSTGRES_DATABASE"];
                        moduleConfig.Username = configuration["BE_POSTGRES_USERNAME"];
                        moduleConfig.Password = configuration["BE_POSTGRES_PASSWORD"];
                        moduleConfig.MigrationsAssembly = typeof(MigrationsManager).Assembly;
                        moduleConfig.EnableNpgsqlPooling = env.IsDevelopment();
                    }
                )
                .AddModule<EFRepositoriesModule<BRCApplication>, EFRepositoriesModuleConfig>();
        }

        public BRCApplication AddElasticSearch()
        {
            return AddModule<ElasticSearchModule, ElasticSearchModuleConfig>((configuration, env, moduleConfig) =>
            {
                moduleConfig.Prefix = configuration["BE_ELASTICSEARCH_PREFIX"];
                moduleConfig.Url = configuration["BE_ELASTICSEARCH_URI"];
                moduleConfig.EnableClientLogging = env.IsDevelopment();
            });
        }

        public BRCApplication AddBrcDomain()
        {
            return AddModule<BrcDomainModule>();
        }

        public BRCApplication AddS3Storage()
        {
            return AddModule<S3StorageModule<BRCStorageConfig>, BRCStorageConfig>((configuration, env, moduleConfig) =>
            {
                var uri = configuration["BE_STORAGE_PUBLIC_URI"];
                var success = Uri.TryCreate(uri, UriKind.Absolute, out var publicUri);
                if (!success)
                {
                    throw new ArgumentException($"URI {uri} is not proper URI");
                }

                var serverUriStr = configuration["BE_STORAGE_S3_SERVER_URI"];
                success = Uri.TryCreate(serverUriStr, UriKind.Absolute, out var serverUri);
                if (!success)
                {
                    throw new ArgumentException($"S3 server URI {serverUriStr} is not proper URI");
                }

                moduleConfig.PublicUri = publicUri;
                moduleConfig.Server = serverUri;
                moduleConfig.Bucket = configuration["BE_STORAGE_S3_BUCKET"];
                moduleConfig.SecretKey = configuration["BE_STORAGE_S3_SECRET_KEY"];
                moduleConfig.AccessKey = configuration["BE_STORAGE_S3_ACCESS_KEY"];
            });
        }

        public BRCApplication
            AddIpbUsers<TUsersModule, TConfig, TCurrentUserProvider>()
            where TUsersModule : IPBUsersModule<TConfig, TCurrentUserProvider>
            where TConfig : IPBUsersModuleConfig, new()
            where TCurrentUserProvider : class, ICurrentUserProvider
        {
            return AddModule<TUsersModule, TConfig>((configuration, env, moduleConfig) =>
            {
                bool.TryParse(configuration["BE_IPB_API_DEV_MODE"] ?? "", out var devMode);
                int.TryParse(configuration["BE_IPB_API_ADMIN_GROUP_ID"], out var adminGroupId);
                int.TryParse(configuration["BE_IPB_API_SITE_TEAM_GROUP_ID"], out var siteTeamGroupId);

                var additionalGroupIds = new List<int> {siteTeamGroupId};
                if (!string.IsNullOrEmpty(configuration["BE_IPB_API_ADDITIONAL_GROUP_IDS"]))
                {
                    var ids = configuration["BE_IPB_API_ADDITIONAL_GROUP_IDS"].Split(',');
                    foreach (var id in ids)
                    {
                        if (int.TryParse(id, out var parsedId))
                        {
                            additionalGroupIds.Add(parsedId);
                        }
                    }
                }

                var adminPolicy = new AuthorizationPolicyBuilder().RequireClaim(ClaimTypes.Role, "admin").Build();
                var siteTeamPolicy = new AuthorizationPolicyBuilder()
                    .RequireClaim(ClaimTypes.GroupSid, siteTeamGroupId.ToString(), adminGroupId.ToString())
                    .Build();
                var policies = new Dictionary<string, AuthorizationPolicy>
                {
                    {BioPolicies.Admin, adminPolicy},
                    {BrcPolicies.SiteTeam, siteTeamPolicy},
                    // sections
                    {BioPolicies.Sections, siteTeamPolicy},
                    {BioPolicies.SectionsAdd, adminPolicy},
                    {BioPolicies.SectionsEdit, adminPolicy},
                    {BioPolicies.SectionsPublish, adminPolicy},
                    {BioPolicies.SectionsDelete, adminPolicy},
                    // posts
                    {PostsPolicies.Posts, siteTeamPolicy},
                    {PostsPolicies.PostsAdd, siteTeamPolicy},
                    {PostsPolicies.PostsEdit, siteTeamPolicy},
                    {PostsPolicies.PostsDelete, siteTeamPolicy},
                    {PostsPolicies.PostsPublish, siteTeamPolicy},
                    // pages
                    {PagesPolicies.Pages, adminPolicy},
                    {PagesPolicies.PagesAdd, adminPolicy},
                    {PagesPolicies.PagesEdit, adminPolicy},
                    {PagesPolicies.PagesDelete, adminPolicy},
                    {PagesPolicies.PagesPublish, adminPolicy},
                    // ads
                    {AdsPolicies.Ads, adminPolicy},
                    {AdsPolicies.AdsAdd, adminPolicy},
                    {AdsPolicies.AdsEdit, adminPolicy},
                    {AdsPolicies.AdsDelete, adminPolicy},
                    {AdsPolicies.AdsPublish, adminPolicy}
                };

                moduleConfig.DevMode = devMode;
                moduleConfig.AdminGroupId = adminGroupId;
                moduleConfig.AdditionalGroupIds = additionalGroupIds.Distinct().ToArray();
                moduleConfig.CallbackPath = "/login/ipb";
                moduleConfig.ApiClientId = configuration["BE_IPB_OAUTH_CLIENT_ID"];
                moduleConfig.ApiClientSecret = configuration["BE_IPB_OAUTH_CLIENT_SECRET"];
                moduleConfig.AuthorizationEndpoint = configuration["BE_IPB_AUTHORIZATION_ENDPOINT"];
                moduleConfig.TokenEndpoint = configuration["BE_IPB_TOKEN_ENDPOINT"];
                moduleConfig.DataProtectionPath = configuration["BE_IPB_DATA_PROTECTION_PATH"];

                foreach (var policy in policies)
                {
                    moduleConfig.Policies.Add(policy.Key, policy.Value);
                }
            });
        }
    }

    public class BRCStorageConfig : StorageOptions, IS3StorageOptions
    {
        public Uri Server { get; set; }
        public string Bucket { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
    }
}
