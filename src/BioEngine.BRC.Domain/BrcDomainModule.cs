using BioEngine.BRC.Domain.Entities;
using BioEngine.BRC.Domain.Entities.Blocks;
using BioEngine.BRC.Domain.Search;
using BioEngine.Core.DB;
using BioEngine.Core.Modules;
using BioEngine.Core.Search;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Logging;

namespace BioEngine.BRC.Domain
{
    public class BrcDomainModule : BaseBioEngineModule
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.RegisterSearchProvider<DevelopersSearchProvider, Developer>();
            services.RegisterSearchProvider<GamesSearchProvider, Game>();
            services.RegisterSearchProvider<TopicsSearchProvider, Topic>();
            services.AddSingleton<ILoggerFactory>(_ => new SerilogLoggerFactory());

            var loggerConfiguration = new LoggerConfiguration();
            loggerConfiguration.MinimumLevel.Is(environment.IsDevelopment()
                ? LogEventLevel.Debug
                : LogEventLevel.Information);
            loggerConfiguration
                .Enrich.FromLogContext()
                .Enrich.WithMachineName();

            loggerConfiguration
                .WriteTo.Console(
                    outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3} {SourceContext}]{NewLine}\t{Message:lj}{NewLine}{Exception}");

            if (environment.IsProduction())
            {
                loggerConfiguration.MinimumLevel.Override("System.Net.Http.HttpClient.health-checks",
                    LogEventLevel.Error);
                loggerConfiguration.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);
            }

            Log.Logger = loggerConfiguration.CreateLogger();
        }
    }

    public class BrcBioContextModelConfigurator : IBioContextModelConfigurator
    {
        public void Configure(ModelBuilder modelBuilder, ILogger<BioContext> logger)
        {
            modelBuilder.RegisterSection<Developer, DeveloperData>(logger);
            modelBuilder.RegisterSection<Game, GameData>(logger);
            modelBuilder.RegisterSection<Topic, TopicData>(logger);
            modelBuilder.RegisterContentBlock<TwitchBlock, TwitchBlockData>(logger);
        }
    }
}
