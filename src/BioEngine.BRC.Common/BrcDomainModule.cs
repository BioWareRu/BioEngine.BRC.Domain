using System;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Properties;
using BioEngine.BRC.Common.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sitko.Core.App;
using Sitko.Core.Search;

namespace BioEngine.BRC.Common
{
    public class BrcDomainModule : BaseApplicationModule
    {
        public BrcDomainModule(BaseApplicationModuleConfig config, Application application) : base(config,
            application)
        {
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.AddScoped<PropertiesProvider>();
            services.RegisterSearchProvider<DevelopersSearchProvider, Developer, Guid>();
            services.RegisterSearchProvider<GamesSearchProvider, Game, Guid>();
            services.RegisterSearchProvider<TopicsSearchProvider, Topic, Guid>();
            services.RegisterSearchProvider<PostsSearchProvider, Post, Guid>();
            services.RegisterSearchProvider<PagesSearchProvider, Page, Guid>();
        }
    }
}
