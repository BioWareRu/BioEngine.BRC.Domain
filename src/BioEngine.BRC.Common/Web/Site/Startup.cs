using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.BRC.Common.Web.Site
{
    public abstract class BRCSiteStartup : BRCStartup
    {
        protected BRCSiteStartup(IConfiguration configuration, IHostEnvironment environment) : base(configuration,
            environment)
        {
        }

        protected override IMvcBuilder ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            return base.ConfigureMvc(mvcBuilder).AddMvcOptions(options =>
            {
                options.CacheProfiles.Add("SiteMapCacheProfile",
                    new CacheProfile {Duration = 600});
            });
        }

        protected override void ConfigureBeforeRoutingMiddleware(IApplicationBuilder app)
        {
            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseMiddleware<CurrentSiteMiddleware>();
        }
    }
}
