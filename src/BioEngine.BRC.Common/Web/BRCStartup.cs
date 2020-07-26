using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace BioEngine.BRC.Common.Web
{
    public class BRCStartup : Sitko.Core.App.Web.BaseStartup<BRCApplication>
    {
        public BRCStartup(IConfiguration configuration, IHostEnvironment environment) : base(configuration, environment)
        {
            SetDefaultCulture("ru-RU");
        }
    }
}
