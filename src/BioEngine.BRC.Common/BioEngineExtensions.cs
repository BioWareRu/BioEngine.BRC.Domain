using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BioEngine.BRC.Domain;
using BioEngine.BRC.Migrations;
using BioEngine.Core.DB;
using BioEngine.Core.Db.PostgreSQL;
using BioEngine.Core.Pages;
using BioEngine.Core.Posts;
using BioEngine.Core.Search.ElasticSearch;
using BioEngine.Core.Storage.S3;
using BioEngine.Core.Users;
using BioEngine.Extra.Ads;
using BioEngine.Extra.IPB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;

namespace BioEngine.BRC.Common
{
    public static class BioEngineExtensions
    {
        public static Core.BioEngine AddPostgresDb(this Core.BioEngine bioEngine, bool enablePooling = true)
        {
            return bioEngine
                .AddEntities()
                .AddModule<PostgresDatabaseModule<BioContext>, PostgresDatabaseModuleConfig>(
                    (configuration, env) => new PostgresDatabaseModuleConfig(configuration["BE_POSTGRES_HOST"],
                        configuration["BE_POSTGRES_USERNAME"], configuration["BE_POSTGRES_DATABASE"],
                        configuration["BE_POSTGRES_PASSWORD"], int.Parse(configuration["BE_POSTGRES_PORT"]),
                        typeof(MigrationsManager).Assembly) {EnableNpgsqlPooling = env.IsDevelopment()})
                .ConfigureServices(
                    collection =>
                    {
                        collection.AddHealthChecks().AddDbContextCheck<BioContext>();
                    });
        }

        public static string GetPostgresConnectionString(this IConfiguration configuration)
        {
            var connBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = configuration["BE_POSTGRES_HOST"],
                Port = int.Parse(configuration["BE_POSTGRES_PORT"]),
                Username = configuration["BE_POSTGRES_USERNAME"],
                Password = configuration["BE_POSTGRES_PASSWORD"],
                Database = configuration["BE_POSTGRES_DATABASE"],
                Pooling = false
            };

            return connBuilder.ConnectionString;
        }

        public static Core.BioEngine AddElasticSearch(this Core.BioEngine bioEngine)
        {
            return bioEngine.AddModule<ElasticSearchModule, ElasticSearchModuleConfig>((configuration, env) =>
                new ElasticSearchModuleConfig(configuration["BE_ELASTICSEARCH_PREFIX"],
                    configuration["BE_ELASTICSEARCH_URI"], enableClientLogging: env.IsDevelopment()));
        }

        public static Core.BioEngine AddBrcDomain(this Core.BioEngine bioEngine)
        {
            return bioEngine.AddModule<BrcDomainModule>();
        }

        public static Core.BioEngine AddS3Storage(this Core.BioEngine bioEngine)
        {
            return bioEngine.AddModule<S3StorageModule, S3StorageModuleConfig>((configuration, env) =>
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

                return new S3StorageModuleConfig(publicUri, serverUri, configuration["BE_STORAGE_S3_BUCKET"],
                    configuration["BE_STORAGE_S3_ACCESS_KEY"], configuration["BE_STORAGE_S3_SECRET_KEY"])
                {
                    LargeThumbnailHeight = 578, LargeThumbnailWidth = 800
                };
            });
        }

        public static Core.BioEngine AddS3Client(this Core.BioEngine bioEngine)
        {
            return bioEngine.AddModule<S3ClientModule, S3ClientModuleConfig>((configuration, env) =>
            {
                var serverUriStr = configuration["BE_STORAGE_S3_SERVER_URI"];
                var success = Uri.TryCreate(serverUriStr, UriKind.Absolute, out var serverUri);
                if (!success)
                {
                    throw new ArgumentException($"S3 server URI {serverUri} is not proper URI");
                }

                return new S3ClientModuleConfig(serverUri, configuration["BE_STORAGE_S3_BUCKET"],
                    configuration["BE_STORAGE_S3_ACCESS_KEY"], configuration["BE_STORAGE_S3_SECRET_KEY"]);
            });
        }

        public static Core.BioEngine
            AddIpbUsers<TUsersModule, TConfig, TCurrentUserProvider>(this Core.BioEngine bioEngine)
            where TUsersModule : IPBUsersModule<TConfig, TCurrentUserProvider>, new()
            where TConfig : IPBUsersModuleConfig, new()
            where TCurrentUserProvider : class, ICurrentUserProvider<string>
        {
            return bioEngine.AddModule<TUsersModule, TConfig>((configuration, env) =>
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

                var config = new TConfig
                {
                    DevMode = devMode,
                    AdminGroupId = adminGroupId,
                    AdditionalGroupIds = additionalGroupIds.Distinct().ToArray(),
                    CallbackPath = "/login/ipb",
                    ApiClientId = configuration["BE_IPB_OAUTH_CLIENT_ID"],
                    ApiClientSecret = configuration["BE_IPB_OAUTH_CLIENT_SECRET"],
                    AuthorizationEndpoint = configuration["BE_IPB_AUTHORIZATION_ENDPOINT"],
                    TokenEndpoint = configuration["BE_IPB_TOKEN_ENDPOINT"],
                    DataProtectionPath = configuration["BE_IPB_DATA_PROTECTION_PATH"]
                };

                foreach (var policy in policies)
                {
                    config.Policies.Add(policy.Key, policy.Value);
                }

                return config;
            });
        }
    }
}
