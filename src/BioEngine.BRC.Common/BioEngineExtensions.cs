using System;
using BioEngine.BRC.Domain;
using BioEngine.BRC.Migrations;
using BioEngine.Core.DB;
using BioEngine.Core.Db.PostgreSQL;
using BioEngine.Core.Logging.Graylog;
using BioEngine.Core.Search.ElasticSearch;
using BioEngine.Core.Storage.S3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using Serilog;
using Serilog.Events;

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
                        enablePooling, typeof(MigrationsManager).Assembly)).ConfigureServices(collection =>
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
                    configuration["BE_ELASTICSEARCH_URI"],
                    configuration["BE_ELASTICSEARCH_LOGIN"], configuration["BE_ELASTICSEARCH_PASSWORD"],
                    env.IsDevelopment()));
        }

        public static Core.BioEngine AddBrcDomain(this Core.BioEngine bioEngine)
        {
            return bioEngine.AddModule<BrcDomainModule>();
        }

        public static Core.BioEngine AddLogging(this Core.BioEngine bioEngine,
            LogEventLevel devLevel = LogEventLevel.Debug, LogEventLevel prodLevel = LogEventLevel.Information,
            Action<LoggerConfiguration> configure = null)
        {
            return bioEngine.AddModule<GraylogLoggingModule, GraglogModuleConfig>((configuration, environment) =>
                new GraglogModuleConfig(configuration["BE_GRAYLOG_HOST"],
                    int.Parse(configuration["BE_GRAYLOG_PORT"]), environment.ApplicationName)
                {
                    DevLevel = devLevel, ProdLevel = prodLevel, Configure = configure
                });
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
                    configuration["BE_STORAGE_S3_ACCESS_KEY"], configuration["BE_STORAGE_S3_SECRET_KEY"]);
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
    }
}
