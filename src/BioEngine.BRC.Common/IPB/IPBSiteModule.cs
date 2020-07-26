using BioEngine.BRC.Common.Comments;
using BioEngine.BRC.Common.IPB.Comments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sitko.Core.App;

namespace BioEngine.BRC.Common.IPB
{
    public class IPBSiteModule : IPBModule<IPBSiteModuleConfig>
    {
        public IPBSiteModule(IPBSiteModuleConfig config, Application application) : base(config, application)
        {
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.AddScoped<ICommentsProvider, IPBCommentsProvider>();
        }
    }

    public class IPBSiteModuleConfig : IPBModuleConfig
    {
    }
}
