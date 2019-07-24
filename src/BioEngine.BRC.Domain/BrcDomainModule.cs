using BioEngine.BRC.Domain.Entities;
using BioEngine.BRC.Domain.Search;
using BioEngine.Core.Modules;
using BioEngine.Core.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
        }
    }
}
