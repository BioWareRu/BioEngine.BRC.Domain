using BioEngine.BRC.Domain.Repository;
using BioEngine.Core.Modules;
using BioEngine.Core.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.BRC.Domain
{
    public class BrcDomainModule : BioEngineModule
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.AddSingleton<IMainSiteSelectionPolicy, BRCMainSiteSelectionPolicy>();
        }
    }
}
